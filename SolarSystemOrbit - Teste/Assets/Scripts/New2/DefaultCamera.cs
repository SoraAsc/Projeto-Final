using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCamera : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotationSpeed = 30f;
    Transform father;
    bool isAndroid = false;
    Touch touch;

    private void Start()
    {
        father = transform.parent;
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

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        if (isAndroid)
        {
            if(Input.touchCount==1 && Input.GetTouch(0).phase == TouchPhase.Moved)//caso tenha um dedo na tela e o mesmo estiver em movimento.
            {
                touch = Input.GetTouch(0); //verifica só o primeiro dedo colocado na tela.
                //pega os valores do movimento que variam de -1 a 1
                pos += transform.forward * touch.deltaPosition.y * Time.deltaTime * moveSpeed;
                pos += transform.right * touch.deltaPosition.x * Time.deltaTime * moveSpeed;
            }
            else if(Input.touchCount==2 && Input.GetTouch(1).phase == TouchPhase.Moved)//caso tenha dois dedos na tela e o segundo estiver em movimento.
            {                
                touch = Input.GetTouch(1); //verifica só o segundo dedo colocado na tela.
                //pega os valores do movimento que variam de -1 a 1
                father.eulerAngles += new Vector3(touch.deltaPosition.y * Time.deltaTime * -rotationSpeed, touch.deltaPosition.x * Time.deltaTime * rotationSpeed, 0);
            }

        }
        else if (!isAndroid)
        {
            float horizontalMove = Input.GetAxis("Horizontal");
            float verticalMove = Input.GetAxis("Vertical");

            pos += transform.forward * verticalMove * Time.deltaTime * moveSpeed;
            pos += transform.right * horizontalMove * Time.deltaTime * moveSpeed;

            if (Input.GetMouseButton(0))
            {
                father.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * Time.deltaTime * -rotationSpeed, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, 0);
            }
        }

        transform.position = pos;
    }

}
