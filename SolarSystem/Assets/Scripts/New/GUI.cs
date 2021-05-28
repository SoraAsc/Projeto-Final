using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GUI : MonoBehaviour
{
    CameraFollow cameraOrbitFollow;
    GameManager gameManager;
    [SerializeField]
    private int i = 2;
    bool showbuttons;
    bool canShowInformation;
    [SerializeField]
    TextMeshProUGUI planetNameText;
    [SerializeField] Text informationText;
    [SerializeField] Sprite showSprite, hideSprite;
    ParticleSystem sunPa;
    bool[] showVisualChildrens = new bool[3];
    bool[] waitShowVisualChildrens = new bool[3];


    #region MainMenu
    public GameObject baseMenuHolder;
    public GameObject creditsPanel;
    public Slider[] mainMenuSlider;
    public float incrementValueToAppearButtonInMainMenu;
    public Camera menuCamera;
    public Camera creditsCamera;
    public GameObject menuMenu;
    public GameObject defaultMenu;
    #endregion

    public Slider[] buttonsSlider;
    public Camera orbitCamera;

    #region EnvVar
    Coroutine lastFade=null;
    Coroutine lastHideOrShowButtons = null;
    Coroutine lastInformationShow = null;
    int informationIndex = 0;
    public Vector3 offset;
    public float smoothSpeed=0.125f;
    #endregion

    private void Start()
    {
        //inicializa todos as variaveis e funções necessárias.
        showbuttons = false;
        canShowInformation = true;
        for(int i = 0; i < showVisualChildrens.Length; i++)
        {
            showVisualChildrens[i] = false;
            waitShowVisualChildrens[i] = false;
        }

        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        cameraOrbitFollow = Camera.main.GetComponent<CameraFollow>();
        cameraOrbitFollow.gameObject.SetActive(false);
        sunPa = gameManager.planets[8].planetRotateObject.GetComponentInChildren<ParticleSystem>();
        //StartCoroutine(ButtonAppearSameTime());
        StartCoroutine(ButtonAppearOneByOne(mainMenuSlider,newIncrementValue: incrementValueToAppearButtonInMainMenu));
    }

    #region DefaultMenuFunction
    public void VisualizeOrbit(bool visualState)
    {
        ChangeColorOfToggle(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>(),visualState);
        cameraOrbitFollow.gameObject.SetActive(!visualState);
        orbitCamera.gameObject.SetActive(visualState);
        ShowDesactiveOrbit();
    }

    public void ShowInformationState(bool showState)
    {
        canShowInformation = showState;
        ChangeColorOfToggle(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>(), showState);
    }

    public void ChangeColorOfToggle(Image image, bool state)
    {
        //FF0047 vermelho
        //9400D3 roxo
        Color32 color = new Color32(0x94, 0x00, 0xDE, 0xFF);
        if (state) color = new Color32(0xFF, 0x00, 0x47, 0xFF);

        image.color = color;
    }

    public void ShowDesactiveOrbit()
    {
        sunPa.gameObject.SetActive(!sunPa.gameObject.activeSelf);
        for(int i = 0; i < gameManager.planets.Count; i++)
        {
           if(i!=8) gameManager.planets[i].orbitLine.SetActive(!gameManager.planets[i].orbitLine.activeSelf);
        }
    }

    public void PlanetMove(int newI)
    {
        i = newI;
        cameraOrbitFollow.distanceMin = gameManager.planets[i].distanceMin;
        cameraOrbitFollow.distanceMax = gameManager.planets[i].distanceMax;
        StartCoroutine(CameraFollowPlanet());
    }

    public void PlanetChangeSpeed(int newI)
    {
        gameManager.planets[newI].speedIndex++;
        if(gameManager.planets[newI].reduceSpeed.Length <= gameManager.planets[newI].speedIndex)
        {
            gameManager.planets[newI].speedIndex = 0;
        }
        gameManager.planets[newI].speedMultiply = gameManager.planets[newI].reduceSpeed[gameManager.planets[newI].speedIndex];
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = gameManager.planets[newI].speedMultiply+"X";
    }
    public void HideAndShowButtons(Image btnImage)
    {
        showbuttons = !showbuttons;
        if(lastHideOrShowButtons!=null) StopCoroutine(lastHideOrShowButtons);
        if (showbuttons)
        {
            btnImage.sprite = hideSprite;
        }
        else
        {
            btnImage.sprite = showSprite;
        }
        lastHideOrShowButtons = StartCoroutine(ButtonAppearOneByOne(buttonsSlider,showbuttons));
    }
    public void PlanetNameAppear()
    {
        if(lastFade!=null) StopCoroutine(lastFade);        
        planetNameText.color = new Color32(255, 255, 255, 255);
        planetNameText.text = gameManager.planets[i].planetName;
        lastFade = StartCoroutine(FadeText());
    }
    public void VisualMenuOpen(Transform toOpenChildren)
    {
       StartCoroutine(MenuShowDelay(toOpenChildren));
    }

    #endregion

    #region MainMenuFunction

    /// <summary>
    /// Ao apertar em iniciar a simulação.
    /// </summary>
    public void Iniciar()
    {
        menuCamera.gameObject.SetActive(false);
        menuMenu.SetActive(false);
        cameraOrbitFollow.gameObject.SetActive(true);
        defaultMenu.SetActive(true);
        StartCoroutine(CameraFollowPlanet());
    }
    #endregion

    /// <summary>
    /// Efeito da camera seguir o planeta, assim dando um efeito progressivo em vez de instantâneo.
    /// </summary>
    /// <returns></returns>
    IEnumerator CameraFollowPlanet()
    {
        AudioSource source = cameraOrbitFollow.GetComponent<AudioSource>();
        if (gameManager.planets[i].planetSong) { source.clip = gameManager.planets[i].planetSong; source.Play(); }
        else source.Stop();
        cameraOrbitFollow.target = null;
        Vector3 desiredPos = gameManager.planets[i].planetRotateObject.transform.parent.localPosition + offset;
        while (Vector3.Distance(cameraOrbitFollow.transform.localPosition, desiredPos) >= gameManager.planets[i].distanceMin+.2f)
        {
            //Debug.Log(Vector3.Distance(cameraOrbitFollow.transform.localPosition, desiredPos));
            desiredPos = gameManager.planets[i].planetRotateObject.transform.parent.localPosition + offset;
            Vector3 smoothedPos = Vector3.Lerp(cameraOrbitFollow.transform.localPosition, desiredPos, smoothSpeed);
            cameraOrbitFollow.transform.localPosition = smoothedPos;
            cameraOrbitFollow.transform.LookAt(gameManager.planets[i].planetRotateObject.transform.parent.position);
            //cameraOrbitFollow.transform.LookAt(2* cameraOrbitFollow.transform.position - gameManager.planets[i].planetRotateObject.transform.position);
            //transform.rotation = Quaternion.LookRotation(transform.position - gameManager.planets[i].planetRotateObject.transform.position);
            yield return new WaitForSeconds(Time.deltaTime * (1/gameManager.planets[i].speedMultiply) );
        }
        cameraOrbitFollow.target = gameManager.planets[i].planetRotateObject.transform;
        PlanetNameAppear();
        yield return null;
    }


    /// <summary>
    /// Faz o botão aparecer um de cada vez.
    /// </summary>
    /// <returns></returns>
    IEnumerator ButtonAppearOneByOne(Slider[] allsliders, bool newShowButtons=true,float newIncrementValue=0.1f)
    {
        int cont = newShowButtons == true ? 0 : allsliders.Length - 1; //operador ternário para decidir a quantidade de botoes aparecendo.
        float value = newShowButtons == true ? newIncrementValue : -newIncrementValue;
        for (int i = 0; i < allsliders.Length; i++)
        {
            while (newShowButtons == true ? allsliders[Mathf.Abs(cont - i)].value < 1 :
                allsliders[Mathf.Abs(cont - i)].value > 0)
            {
                allsliders[Mathf.Abs(cont - i)].value += value;
                yield return new WaitForSeconds(0.0001f * Time.deltaTime);
            }
        }
    }


    /// <summary>
    /// Delay para aparecer ou sumir com o menu.
    /// </summary>
    /// <param name="child"></param>
    /// <returns></returns>
    IEnumerator MenuShowDelay(Transform father)
    {
        //0 opções 1-navegação 2 - velocidade
        int index = father.name.Contains("Opt") ? 0 : father.name.Contains("Nav") ? 1 : 2;

        if (!waitShowVisualChildrens[index])
        {
            waitShowVisualChildrens[index] = !waitShowVisualChildrens[index];
            showVisualChildrens[index] = !showVisualChildrens[index];
            int total = showVisualChildrens[index] ? 0 : father.childCount - 1;
            for(int i = 0; i < father.childCount; i++)
            {
                father.GetChild(Mathf.Abs(total - i)).gameObject.SetActive(showVisualChildrens[index]); //Abs transforma -1 em 1
                yield return new WaitForSeconds(0.03f);
            }
            waitShowVisualChildrens[index] = !waitShowVisualChildrens[index];
        }
    }

    /// <summary>
    /// Faz o texto sumir após um tempo
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeText()
    {
        if (lastInformationShow != null) StopCoroutine(lastInformationShow);

        informationText.transform.parent.gameObject.SetActive(false);
        planetNameText.gameObject.SetActive(true);
        //o a(alha) 0.01 = 4 segundos aproximadamente
        byte a = 255;
        while (planetNameText.color.a > 0)
        {
            a -= 1;
            planetNameText.color = new Color32(255, 255, 255, a);
            yield return new WaitForSeconds(0.012500f); //5 segundos = 0.012500f, 255 vezes
        }
        planetNameText.gameObject.SetActive(false);
        informationText.transform.parent.gameObject.SetActive(true);
        informationText.text = "";
        informationIndex = 0;

        lastInformationShow = StartCoroutine(ShowInformation());
        
    }
    
    public void OpenCredits()
    {
        creditsCamera.gameObject.SetActive(true);
        menuCamera.gameObject.SetActive(false);
        baseMenuHolder.SetActive(false);
        creditsPanel.SetActive(true);
        baseMenuHolder.transform.parent.GetComponent<Canvas>().worldCamera = creditsCamera;
    }

    private void Update()
    {
        if (creditsPanel.activeSelf&&Input.GetKey(KeyCode.Escape)) 
        {
            menuCamera.gameObject.SetActive(true);
            creditsCamera.gameObject.SetActive(false);
            creditsPanel.SetActive(false); baseMenuHolder.SetActive(true); 
            baseMenuHolder.transform.parent.GetComponent<Canvas>().worldCamera = menuCamera; 
        }
    }

    IEnumerator ShowInformation()
    {
        while (informationText.text.Length > 0)
        {
            informationText.text = informationText.text.Remove(informationText.text.Length-1);
            yield return new WaitForSeconds(0.010f);

        }
        informationText.text = "";
        if (informationIndex == gameManager.planets[i].informations.Length) informationIndex = 0;

        if (gameManager.planets[i].informations.Length > 0)
        {
            if (canShowInformation)
            {
                foreach (char word in gameManager.planets[i].informations[informationIndex])
                {
                    informationText.text += word;
                    yield return new WaitForSeconds(0.010f);
                }
                for (int i = 0; i < 3; i++) informationText.text += ".";

            }
            yield return new WaitForSeconds(4f);
            informationIndex++;
            lastInformationShow = StartCoroutine(ShowInformation());
        }
    }

    public void ActiveOrDesactiveSong(bool state)
    {
        cameraOrbitFollow.GetComponent<AudioSource>().enabled = state;
        ChangeColorOfToggle(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>(), state);
    }
}
