using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Planet : IComparable<Planet>
{
    //essa classe fica em todos os planetas, serve como um inicializador para o mesmo, os valores são definidos no inspetor para cada planeta.
    public string planetName;
    public float planetTimeToRotate;
    public float planetTimeToTranslate;
    public GameObject planetTranslateObject;
    public GameObject planetRotateObject;
    public float elipseAValue;
    public float elipseBValue;

    public GameObject orbitLine;

    public float distanceMin,distanceMax;

    public List<Satellite> SateliteNatural;

    public int maxSateliteNatural;
    public GameObject holderSatelite;

    public float c;
    public float alpha;

    [TextArea (5,6)]
    public string[] informations;

    public AudioClip planetSong;

    public Planet(string newPlanetName,float newPlanetTimeToRotate,
        float newPlanetTimeToTranslate, GameObject newPlanetTranslateObject, 
        GameObject newPlanetRotateObject,float newElipseAValue, float newElipseBValue,GameObject newOrbitLine,
        float newDistanceMin,float newDistanceMax,int newMaxSateliteNatural, GameObject newHolderSatelite,float newC,
        float newAlpha)
    {
        planetName = newPlanetName;
        planetTimeToRotate = newPlanetTimeToRotate;
        planetTimeToTranslate = newPlanetTimeToTranslate;
        planetRotateObject = newPlanetRotateObject;
        planetTranslateObject = newPlanetTranslateObject;
        elipseAValue = newElipseAValue;
        elipseBValue = newElipseBValue;
        orbitLine = newOrbitLine;
        distanceMax = newDistanceMax;
        distanceMin = newDistanceMin;
        maxSateliteNatural = newMaxSateliteNatural;
        holderSatelite = newHolderSatelite;
        c = newC;
        alpha = newAlpha;
    }



    //não implementada, mas seria usada para ver qual planeta tem algo maior que o outro, Ex: qual tem o maior tempo de rotação
    public int CompareTo(Planet other)
    {
        if (other == null)
        {
            return 1;
        }

        return planetName.CompareTo(other.planetName);
    }
}
