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

}
