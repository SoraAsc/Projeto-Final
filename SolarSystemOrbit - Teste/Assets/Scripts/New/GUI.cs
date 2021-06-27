using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Globalization;

public class GUI : MonoBehaviour
{
    CameraFollow cameraOrbitFollow;
    GameManager gameManager;
    [SerializeField] private int i = 0;
    //public GameObject[] allInformationBtns;
    public Image[] allInformationImages;
    public TextMeshProUGUI[] allInformationTexts;
    public TMP_InputField[] allInformationInputs;

    public GameObject bodyPrefab;
    public Transform bodiesHolder;

    #region Env
    [SerializeField] Sprite[] allSkinsSprites;
    [SerializeField] int SkinIndex=0;
    public GameObject informationMenu;
    #endregion

    #region MainMenu
    public GameObject baseMenuHolder;
    public GameObject creditsPanel;
    public Slider[] mainMenuSlider;
    public float incrementValueToAppearButtonInMainMenu;
    public Camera menuCamera;
    public Camera creditsCamera;
    public Camera cameraAround;
    public GameObject menuMenu;
    #endregion



    private void Start()
    {
        allSkinsSprites = Resources.LoadAll<Sprite>("SkinsSprites");
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        cameraOrbitFollow = Camera.main.GetComponent<CameraFollow>();
        cameraOrbitFollow.target = gameManager.BodyManager.allBodies[i].transform;
        cameraOrbitFollow.distanceMin = gameManager.BodyManager.allBodies[i].transform.localScale.x;
        cameraOrbitFollow.distanceMax = gameManager.BodyManager.allBodies[i].transform.localScale.x * 5;
        cameraOrbitFollow.distance = cameraOrbitFollow.distanceMax;
        cameraOrbitFollow.xSpeed = 20f / gameManager.BodyManager.allBodies[i].transform.localScale.x;
        RefreshAllGuiComponents();
        //inicializa todos as variaveis e funções necessárias.        
        
        cameraOrbitFollow.gameObject.SetActive(false);
        StartCoroutine(ButtonAppearOneByOne(mainMenuSlider,newIncrementValue: incrementValueToAppearButtonInMainMenu));
    }


    #region MainMenuFunction

    /// <summary>
    /// Ao apertar em iniciar a simulação.
    /// </summary>
    public void Iniciar()
    {
        menuCamera.gameObject.SetActive(false);
        menuMenu.SetActive(false);
        cameraOrbitFollow.gameObject.SetActive(true);
        informationMenu.SetActive(true);
    }

    /// <summary>
    /// Faz o botão aparecer um de cada vez.
    /// </summary>
    /// <returns></returns>
    IEnumerator ButtonAppearOneByOne(Slider[] allsliders, bool newShowButtons = true, float newIncrementValue = 0.1f)
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

    public void OpenCredits()
    {
        creditsCamera.gameObject.SetActive(true);
        menuCamera.gameObject.SetActive(false);
        baseMenuHolder.SetActive(false);
        creditsPanel.SetActive(true);
        baseMenuHolder.transform.root.GetComponent<Canvas>().worldCamera = creditsCamera;
    }
    #endregion

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


    public void BodyChoose(int signal=1)
    {
        if (gameManager.BodyManager.GetNumOfBodies() > 0)
        {
            i += signal;
            if (i > gameManager.BodyManager.GetNumOfBodies()-1) i = 0;
            else if (i < 0) i = gameManager.BodyManager.GetNumOfBodies() - 1;
            RefreshAllGuiComponents();
            cameraOrbitFollow.target = gameManager.BodyManager.allBodies[i].transform;
            cameraOrbitFollow.distanceMin = gameManager.BodyManager.allBodies[i].transform.localScale.x;
            cameraOrbitFollow.distanceMax = gameManager.BodyManager.allBodies[i].transform.localScale.x*5;
            cameraOrbitFollow.distance = cameraOrbitFollow.distanceMax;
            cameraOrbitFollow.xSpeed= 20f / gameManager.BodyManager.allBodies[i].transform.localScale.x;
        }
    }

    public void SkinChoose(int signal=1)
    {
        if (allSkinsSprites.Length > 0)
        {
            SkinIndex += signal;
            if (SkinIndex > allSkinsSprites.Length - 1) SkinIndex = 0;
            else if (SkinIndex < 0) SkinIndex = allSkinsSprites.Length - 1;
            gameManager.BodyManager.allBodies[i].sprite = allSkinsSprites[SkinIndex];
            allInformationImages[0].sprite = allSkinsSprites[SkinIndex]; //skin
            gameManager.BodyManager.allBodies[i].material.mainTexture = allSkinsSprites[SkinIndex].texture;
        }
    }

    public void RefreshAllGuiComponents()
    {
        //allInformationTexts[0].text = "Astro: " + gameManager.BodyManager.allBodies[i].name;
        allInformationTexts[0].text = "Astro: " + (i+1); //nome do astro
        allInformationImages[0].sprite = gameManager.BodyManager.GetSprite(i); //skin

        allInformationInputs[0].text = ""+gameManager.BodyManager.allBodies[i].transform.position.x; //Posição x do astro
        allInformationInputs[1].text = ""+gameManager.BodyManager.allBodies[i].transform.position.y; //Posição x do astro
        allInformationInputs[2].text = ""+gameManager.BodyManager.allBodies[i].transform.position.z; //Posição x do astro
        allInformationInputs[3].text = ""+gameManager.BodyManager.allBodies[i].transform.localScale.x; //Tamanho do astro
        allInformationInputs[4].text = ""+gameManager.BodyManager.allBodies[i].mass; //Massa do astro
        allInformationInputs[5].text = ""+gameManager.BodyManager.allBodies[i].initialSpeed.x; //Velocidade inicial x do astro
        allInformationInputs[6].text = ""+gameManager.BodyManager.allBodies[i].initialSpeed.y; //Velocidade inicial y do astro
        allInformationInputs[7].text = ""+gameManager.BodyManager.allBodies[i].initialSpeed.z; //Velocidade inicial z do astro
        allInformationInputs[8].text = ""+gameManager.BodyManager.allBodies[i].trail.startColor.r*255; //Cor R do astro
        allInformationInputs[9].text = ""+gameManager.BodyManager.allBodies[i].trail.startColor.g * 255; //Cor G do astro
        allInformationInputs[10].text = ""+gameManager.BodyManager.allBodies[i].trail.startColor.b * 255; //Cor B do astro

    }

    public void AddBody()
    {
        GameObject newBody = Instantiate(bodyPrefab);
        Body newBodyScript = newBody.GetComponent<Body>();
        newBodyScript.mass = 10;
        newBodyScript.initialSpeed = Vector3.zero;
        newBodyScript.sprite = allSkinsSprites[SkinIndex];
        newBodyScript.material = newBodyScript.GetComponent<MeshRenderer>().material;
        newBodyScript.trail = newBodyScript.GetComponentInChildren<TrailRenderer>();
        newBody.transform.SetParent(bodiesHolder);
        gameManager.BodyManager.AddNewBody(newBodyScript);
    }

    public void RemoveBody()
    {
        if(gameManager.BodyManager.GetNumOfBodies()-1 > 0)
        {
            gameManager.BodyManager.RemoveBody(gameManager.BodyManager.allBodies[i]);
            if (i == gameManager.BodyManager.GetNumOfBodies()) i -= 1;
            RefreshAllGuiComponents();
        }
    }

    public void StartSimulation()
    {
        informationMenu.transform.GetChild(0).gameObject.SetActive(false);
        informationMenu.transform.GetChild(1).gameObject.SetActive(true);
        cameraOrbitFollow.gameObject.SetActive(false);
        cameraAround.gameObject.SetActive(true);
        cameraAround.transform.localPosition = new Vector3(gameManager.BodyManager.allBodies[i].transform.localPosition.x, gameManager.BodyManager.allBodies[i].transform.localPosition.y
            , -gameManager.BodyManager.allBodies[i].transform.localScale.z + gameManager.BodyManager.allBodies[i].transform.localPosition.z);
        cameraAround.transform.parent.eulerAngles = Vector3.zero;
        gameManager.BodyManager.GiveMovement();
    }

    public void BackToSimulationInformation()
    {
        informationMenu.transform.GetChild(0).gameObject.SetActive(true);
        informationMenu.transform.GetChild(1).gameObject.SetActive(false);
        cameraAround.gameObject.SetActive(false);
        cameraOrbitFollow.gameObject.SetActive(true);
        gameManager.BodyManager.BackToOrigin();
    }

    public void ChangeInputAndBodyValue(int which)
    {
        TMP_InputField inputField = null;
        if (EventSystem.current.currentSelectedGameObject)
            inputField = EventSystem.current.currentSelectedGameObject.GetComponent<TMP_InputField>();
        if (inputField && (inputField.text.Length>1 || inputField.text.IndexOf("-") != 0))
        {
            if (inputField.text.IndexOf(".") == 0) inputField.text = inputField.text.Insert(0, "0");
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            float value = inputField.text.Length < 1 ? 1 : float.Parse(inputField.text, culture);
            GameConstant.AllFieldType fieldType = (GameConstant.AllFieldType)which;
            switch (fieldType)
            {
                case GameConstant.AllFieldType.PosX:
                    gameManager.BodyManager.allBodies[i].transform.position = Vector3.right * value;
                    break;
                case GameConstant.AllFieldType.PosY:
                    gameManager.BodyManager.allBodies[i].transform.position = Vector3.up * value;
                    break;
                case GameConstant.AllFieldType.PosZ:
                    gameManager.BodyManager.allBodies[i].transform.position = Vector3.forward * value;
                    break;
                case GameConstant.AllFieldType.Size:
                    gameManager.BodyManager.allBodies[i].transform.localScale = Vector3.one * value;
                    cameraOrbitFollow.distanceMin = gameManager.BodyManager.allBodies[i].transform.localScale.x;
                    cameraOrbitFollow.distanceMax = gameManager.BodyManager.allBodies[i].transform.localScale.x * 5;
                    cameraOrbitFollow.distance = cameraOrbitFollow.distanceMax;
                    cameraOrbitFollow.xSpeed = 20f / gameManager.BodyManager.allBodies[i].transform.localScale.x;
                    break;
                case GameConstant.AllFieldType.Mass:
                    gameManager.BodyManager.allBodies[i].mass = value;
                    break;
                case GameConstant.AllFieldType.InitialSpeedX:
                    gameManager.BodyManager.allBodies[i].initialSpeed = Vector3.right * value;
                    break;
                case GameConstant.AllFieldType.InitialSpeedY:
                    gameManager.BodyManager.allBodies[i].initialSpeed = Vector3.up * value;
                    break;
                case GameConstant.AllFieldType.InitialSpeedZ:
                    gameManager.BodyManager.allBodies[i].initialSpeed = Vector3.forward * value;
                    break;
                case GameConstant.AllFieldType.TrailRedColor:
                    if (value > 255 || value < 0) { value = 255; inputField.text = "255"; }
                    Color colR = gameManager.BodyManager.allBodies[i].trail.startColor;
                    gameManager.BodyManager.allBodies[i].trail.startColor = new Color(value / 255f, colR.g, colR.b);
                    gameManager.BodyManager.allBodies[i].trail.endColor = new Color(value / 255f, colR.g, colR.b);
                    break;
                case GameConstant.AllFieldType.TrailGreenColor:
                    if (value > 255 || value < 0) { value = 255; inputField.text = "255"; }
                    Color colG = gameManager.BodyManager.allBodies[i].trail.startColor;
                    gameManager.BodyManager.allBodies[i].trail.startColor = new Color(colG.r, value / 255f, colG.b);
                    gameManager.BodyManager.allBodies[i].trail.endColor = new Color(colG.r, value / 255f, colG.b);
                    break;
                case GameConstant.AllFieldType.TrailBlueColor:
                    if (value > 255 || value < 0) { value = 255; inputField.text = "255"; }
                    Color colB = gameManager.BodyManager.allBodies[i].trail.startColor;
                    gameManager.BodyManager.allBodies[i].trail.startColor = new Color(colB.r, colB.g, value / 255f);
                    gameManager.BodyManager.allBodies[i].trail.endColor = new Color(colB.r, colB.g, value / 255f);
                    break;
                default:
                    break;
            }
        }
    }
}
