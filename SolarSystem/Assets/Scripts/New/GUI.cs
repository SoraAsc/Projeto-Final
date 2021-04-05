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
    bool[] showVisualChildrens = new bool[2];
    bool[] waitShowVisualChildrens = new bool[2];


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
        showVisualChildrens[0] = false;
        showVisualChildrens[1] = false;
        waitShowVisualChildrens[0] = false;
        waitShowVisualChildrens[1] = false;
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
        Vector3 desiredPos = gameManager.planets[i].planetRotateObject.transform.localPosition + offset;
        while (Vector3.Distance(cameraOrbitFollow.transform.localPosition, desiredPos) >= gameManager.planets[i].distanceMax)
        {
            //Debug.Log(Vector3.Distance(cameraOrbitFollow.transform.localPosition, desiredPos));
            desiredPos = gameManager.planets[i].planetRotateObject.transform.localPosition + offset;
            Vector3 smoothedPos = Vector3.Lerp(cameraOrbitFollow.transform.localPosition, desiredPos, smoothSpeed);
            cameraOrbitFollow.transform.localPosition = smoothedPos;
            cameraOrbitFollow.transform.LookAt(2* cameraOrbitFollow.transform.position - gameManager.planets[i].planetRotateObject.transform.position);
            //transform.LookAt(2 * transform.position - stareat.position);
            //transform.rotation = Quaternion.LookRotation(transform.position - target.position);
            //cameraOrbitFollow.transform.LookAt(gameManager.planets[i].planetTranslateObject.transform);
            yield return new WaitForSeconds(Time.deltaTime);
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
    IEnumerator MenuShowDelay(Transform child)
    {
        bool actual, wait = false;
        if (child.name.Contains("Opt"))
        {
            actual = showVisualChildrens[0]; //0 opções 1-navegação
            wait = waitShowVisualChildrens[0];
        }
        else
        {
            actual = showVisualChildrens[1];
            wait = waitShowVisualChildrens[1];
        }
        if (!wait)
        {
            actual = !actual;
            if (child.name.Contains("Opt"))
            {
                showVisualChildrens[0] = actual; //0 opções 1-navegação
                waitShowVisualChildrens[0] = !wait;
            }
            else
            {
                showVisualChildrens[1] = actual;
                waitShowVisualChildrens[1] = !wait;
            }
            int cont = actual == true ? 0 : child.childCount - 1;
            for (int i = 0; i < child.childCount; i++)
            {
                child.GetChild(Mathf.Abs(cont - i)).gameObject.SetActive(actual); //Abs transforma -1 em 1
                yield return new WaitForSeconds(0.04f);
            }
            if (child.name.Contains("Opt"))
            {
                waitShowVisualChildrens[0] = !waitShowVisualChildrens[0];
            }
            else
            {
                waitShowVisualChildrens[1] = !waitShowVisualChildrens[1];
            }
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
        baseMenuHolder.transform.root.GetComponent<Canvas>().worldCamera = creditsCamera;
    }

    private void Update()
    {
        if (creditsPanel.activeSelf&&Input.GetKey(KeyCode.Escape)) 
        {
            menuCamera.gameObject.SetActive(true);
            creditsCamera.gameObject.SetActive(false);
            creditsPanel.SetActive(false); baseMenuHolder.SetActive(true); 
            baseMenuHolder.transform.root.GetComponent<Canvas>().worldCamera = menuCamera; 
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



/*    public void Left()
    {
        MoveBetween(gameManager.planets.Count - 1,-1);
    }
    public void Right()
    {
        MoveBetween(gameManager.planets.Count - 1);
    }
    public void MoveBetween(int max, int j = 1, int min = 0)
    {
        i += j;
        i = i > max ?  min : i<min ? max : i;
        cameraOrbitFollow.distanceMin = gameManager.planets[i].distanceMin;
        cameraOrbitFollow.distanceMax = gameManager.planets[i].distanceMax;
        StartCoroutine(CameraFollowPlanet());

    }*/

/*    /// <summary>
    /// Faz os botões aparecem tudo ao mesmo tempo.
    /// </summary>
    /// <returns></returns>
    IEnumerator ButtonAppearSameTime()
    {
        int cont = 0;
        while (mainMenuSlider[0].value < mainMenuSlider[0].maxValue)
        {
            while (mainMenuSlider.Length > cont)
            {
                mainMenuSlider[cont].value+= 0.1f;
                cont++;
            }
            yield return new WaitForSeconds(0.00001f);
            cont=0;
        }

    }*/