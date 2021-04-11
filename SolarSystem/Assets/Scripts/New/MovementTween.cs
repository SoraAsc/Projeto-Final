using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTween : MonoBehaviour
{

    List<Planet> allPlanets;
    Transform focus1;
    private void Awake()
    {
        allPlanets = GetComponent<GameManager>().planets;
        focus1 = GameObject.FindGameObjectWithTag("Sun").transform;
        foreach (Planet planet in allPlanets)
        {
            planet.orbitLine.GetComponent<VisualizeOrbit>().Initialize(planet.elipseAValue, planet.elipseBValue, focus1);
            planet.startRot = new Quaternion(0, 1, 0, 0);
            if (planet.maxSateliteNatural > 0 && planet.SateliteNatural.Count > 0)
            {
                for (int i = 0; i < planet.maxSateliteNatural; i++)
                {
                    float size = Random.value * 0.03f;
                    float value = Random.Range(0.68f, 3f);

                    float time = Random.Range(35000, 165000);
                    Satellite satellite = Instantiate(planet.holderSatelite);
                    satellite.satelliteTimeToRotate = time;
                    satellite.satelliteTimeToTranslate = time;
                    satellite.satelliteTranslateObject = planet.SateliteNatural[0].satelliteTranslateObject;
                    satellite.satelliteRotateObject = satellite.gameObject;
                    satellite.transform.localScale = new Vector3(size, size, size);
                    satellite.elipseAValue = value;
                    satellite.elipseBValue = value;
                    satellite.startRot = new Quaternion(0, 1, 0, 0); 
                    satellite.yValue = Random.Range(0.2f, 1);
                    satellite.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
                        Random.Range(0.0f, 1.0f), 1.0f);
                    satellite.transform.parent = planet.SateliteNatural[0].satelliteTranslateObject.transform;
                    planet.SateliteNatural.Add(satellite);
                }
            }
        }
    }

    private void Update()
    {
        //Faz todos os planetas e os seus satelites se moverem.
        foreach (Planet planet in allPlanets)
        {
            //Colocando valores para a realização da orbita eliptica em todos os planetas
            if (planet.planetTranslateObject)
            {
                //envia os valores para o movimento e retorna valores necessários para posteriormente serem enviados novamente para a orbita.
                (planet.c, planet.alpha) = OrbitMotion(focus1, planet.elipseAValue, planet.elipseBValue, 0, planet.planetTimeToRotate,
                     planet.planetTimeToTranslate, planet.c, planet.planetTranslateObject, planet.alpha,planet.startRot);
                foreach (Satellite satelite in planet.SateliteNatural)
                {
                    if (satelite.satelliteTimeToRotate > 0 && satelite.satelliteTimeToTranslate > 0)
                    {
                        (satelite.c, satelite.alpha) = OrbitMotion(planet.planetRotateObject.transform, satelite.elipseAValue, satelite.elipseBValue, 0, satelite.satelliteTimeToRotate, satelite.satelliteTimeToTranslate,
                            satelite.c, satelite.satelliteRotateObject, satelite.alpha,satelite.startRot);
                    }
                }
            }
        }
    }

    public (float,float) OrbitMotion(Transform focus,float a,float b,float y,float timeToRotate,
        float timeToTranslate,float c,GameObject translateObject,float alpha,Quaternion startRot)
    {
        Vector3 center = new Vector3(focus.transform.position.x + c, 0, focus.position.z);


        // alpha = 6 translação 
        translateObject.transform.position = new Vector3(center.x + a * Mathf.Cos((alpha*6)/ OneDayInOneMinute(timeToTranslate) ), y, center.z + b * Mathf.Sin((alpha * 6) / OneDayInOneMinute(timeToTranslate) ));
        //translateObject.transform.RotateAround(translateObject.transform.position, Vector3.up, (Time.deltaTime / OneDayInOneMinute(timeToRotate) ));
        translateObject.transform.rotation = startRot * Quaternion.AngleAxis(alpha / timeToRotate * 360f, Vector3.up);

        alpha += Time.deltaTime;

        //Original
        //translateObject.transform.position = new Vector3( center.x + a * Mathf.Cos(OneDayInOneMinute(alpha) / 57.6f ), y, center.z + b * Mathf.Sin(OneDayInOneMinute(alpha)  / 57.6f ) );
        //translateObject.transform.RotateAround(translateObject.transform.position, Vector3.up, OneDayInOneMinute(Time.deltaTime) * (360 / timeToRotate)  );
        c = Mathf.Sqrt(a * a - b * b);
        //alpha += Time.deltaTime * (360f / timeToTranslate) ;
        return (c,alpha);
    }

    /// <summary>
    /// Reduz o tempo de translação e rotação
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public float OneDayInOneMinute(float value)
    {
        //return (value*60)/86400;
        return value / 1440f;
    }
}
