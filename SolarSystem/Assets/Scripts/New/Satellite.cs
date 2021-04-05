using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Satellite : MonoBehaviour
{
    //classe de inicialização das estrelas, cada estrela tem uma dessa.

    public string satelliteName;
    public float satelliteTimeToRotate;
    public float satelliteTimeToTranslate;
    public GameObject satelliteTranslateObject;
    public GameObject satelliteRotateObject;
    public float elipseAValue;
    public float elipseBValue;
    public float yValue;
    public float c;
    public float alpha;
    public Satellite(string newsatelliteName, float newsatelliteTimeToRotate, float newsatelliteTimeToTranslate,
        GameObject newsatelliteTranslateObject, GameObject newsatelliteRotateObject, float newElipseAValue,
        float newElipseBValue, float newYValue,float newC,float newAlpha)
    {
        satelliteName = newsatelliteName;
        satelliteTimeToRotate = newsatelliteTimeToRotate;
        satelliteTimeToTranslate = newsatelliteTimeToTranslate;
        satelliteTranslateObject = newsatelliteTranslateObject;
        satelliteRotateObject = newsatelliteRotateObject;
        elipseAValue = newElipseAValue;
        elipseBValue = newElipseBValue;
        yValue = newYValue;
        c = newC;
        alpha = newAlpha;
    }

    private void LateUpdate()
    {
        if(satelliteName== "Lua"||transform.childCount>0)
        {

            //transform.GetChild(0).LookAt(transform);
            //transform.GetChild(0).Rotate(0, transform.GetChild(0).rotation.y* transform.rotation.y, 0);
            transform.GetChild(0).rotation = Quaternion.Euler(0.0f, 90.0f, transform.rotation.z * -1.0f);

            //Debug.Log(Vector3.Distance(transform.position, satelliteTranslateObject.transform.position));
/*            if (Physics.Raycast(transform.position, Vector3.left, 10))
            {
                //transform.GetChild(0).Rotate(0, 0, 0);
                //transform.GetChild(0).rotation = Quaternion.Euler(0,0,0);
                //Debug.Log("estou vendo algo");
            }
            else
            {
                //transform.GetChild(0).Rotate(0, 90, 0);
                //transform.GetChild(0).rotation = Quaternion.Euler(0, 90, 0);
                //Debug.Log("Não estou vendo");
            }*/
        }
    }
}
