using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //o alvo a ser focado nesse caso os planetas.
    public float distance = 2.0f; //a distancia atual entre o planeta e a camera
    public float xSpeed = 20.0f; //a velocidade maxima de rotação ao redor do planeta no eixo x
    public float ySpeed = 20.0f; //a velocidade maxima de rotação ao redor do planeta no eixo y
    public float yMinLimit = -90f; //o máximo que se pode rodar o planeta no eixo y, tbm vale para o eixo x
    public float yMaxLimit = 90f; //o máximo que se pode rodar o planeta no eixo y, tbm vale para o eixo x
    public float distanceMin = 10f; //a distancia minima entre o planeta e a camera
    public float distanceMax = 10f; //a distancia maxima que se pode ter entre o planeta e a camera.
    public float smoothTime = 2f; //suaviza o movimento ao redor do planeta.
    float rotationYAxis = 0.0f; //angulo atual da rotação no eixo y
    float rotationXAxis = 0.0f; //angulo atual da rotação no eixo x
    float velocityX = 0.0f; //velocidade atual no eixo x.
    float velocityY = 0.0f; //velocidade atual no eixo y.
    private Touch touch; //responsável pelo touch em aparelhos moveis.

    bool isAndroid;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles; //pega a rotação atual do gameobject
        //bota os valores do mesmo nas variáveis de rotação.
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;

        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                isAndroid = false;
                break;
            default:
                isAndroid = true;
                break;
        }
    }
    //O Late Update é chamado após todos os updates serem chamados, logo os objetos movimentos dos planetas serão executados antes do movimento da camera.
    void LateUpdate()
    {
        if (target) //se o alvo existir
        {
            //escolhe o movimento do objeto de acordo com a sua plataforma seja android ou pc
            if (isAndroid && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)//caso tenha um dedo na tela e o mesmo estiver em movimento.
            {
                touch = Input.GetTouch(0); //verifica só o primeiro dedo colocado na tela.
                //pega os valores do movimento que variam de -1 a 1                          
                velocityX += touch.deltaPosition.x * xSpeed * 0.02f;
                velocityY -= touch.deltaPosition.y * ySpeed * 0.02f;
            }
            else if (Input.GetMouseButton(0)) //caso o botão esquerdo do mouse for pressionado
            {

                //o getAxis pega o movimento do mouse que varia de -1 a 1 e isso tudo é jogado na variavel de velocidade de cada posição.
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f; //o distance serve pra regular a velocidade de acordo com a distância
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;

            }
            //soma a velocidade de rotação ao angulo de rotação
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;

            //Restringe o valor colocado no caso rotationXAxis a permanecer entre o limite imposto pelo yMinLimit e yMaxLimit.
            //Essa função pode ser encontrada abaixo.
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);

            //Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            if (Physics.Linecast(target.position, transform.position, out RaycastHit hit))//<=4)//Traça uma linha entre os objetos
            {
                distance -= hit.distance; //quando a linha bate em algo, o mesmo é jogado para tras, assim impedindo que a camera fique dentro do gameobject alvo.
                //mas escolhemos não implementar essa parte.
            }
            //e por final a distancia e a rotação são colocadas na camera.
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
