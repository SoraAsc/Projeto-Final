using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    List<Planet> allPlanets;
    Transform focus1;
    private void Awake()
    {
        allPlanets = GetComponent<GameManager>().planets;
        focus1 = GameObject.FindGameObjectWithTag("Sun").transform;
        foreach (Planet planet in allPlanets)
        {
            if(planet.planetName!="Sol") planet.orbitLine.GetComponent<VisualizeOrbit>().Initialize(planet.elipseAValue, planet.elipseBValue, focus1);
            if (planet.maxSateliteNatural > 0 && planet.SateliteNatural.Count > 0)
            {
                for (int i = 0; i < planet.maxSateliteNatural; i++)
                {
                    float size = Random.value * 0.03f;
                    float value = Random.Range(0.68f, 3f);

                    float time = Random.Range(35000, 165000);
                    GameObject satellitePoint = Instantiate(planet.holderSatelite);
                    Satellite satellite = satellitePoint.transform.GetChild(0).GetComponent<Satellite>();
                    satellite.satelliteTimeToRotate = time;
                    satellite.satelliteTimeToTranslate = time;
                    satellite.satelliteTranslateObject = planet.SateliteNatural[0].satelliteTranslateObject;
                    satellite.satelliteRotateObject = satellite.gameObject;
                    satellite.transform.localScale = new Vector3(size, size, size);
                    satellite.elipseAValue = value;
                    satellite.elipseBValue = value;
                    satellite.yValue = Random.Range(0.2f, 1);
                    satellite.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
                        Random.Range(0.0f, 1.0f), 1.0f);
                    satellitePoint.transform.SetParent(planet.SateliteNatural[0].satelliteTranslateObject.transform);
                    satellitePoint.transform.eulerAngles = new Vector3(0, 0,planet.SateliteNatural[0].transform.parent.eulerAngles.z);
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
            if (planet.planetName == "Sol") continue;
            //Colocando valores para a realização da orbita eliptica em todos os planetas
            if (planet.planetTranslateObject)
            {
                //envia os valores para o movimento e retorna valores necessários para posteriormente serem enviados novamente para a orbita.
                (planet.c, planet.alpha) = OrbitMotion(focus1, planet.elipseAValue, planet.elipseBValue, 0, planet.planetTimeToRotate,
                     planet.planetTimeToTranslate, planet.c, planet.planetTranslateObject, planet.alpha, planet.speedMultiply);
                foreach (Satellite satelite in planet.SateliteNatural)
                {
                    if (satelite.satelliteTimeToRotate > 0 && satelite.satelliteTimeToTranslate > 0)
                    {
                        (satelite.c, satelite.alpha) = OrbitMotion(planet.planetRotateObject.transform, satelite.elipseAValue, satelite.elipseBValue, 0, satelite.satelliteTimeToRotate, satelite.satelliteTimeToTranslate,
                            satelite.c, satelite.satelliteRotateObject, satelite.alpha,planet.speedMultiply);
                    }
                }
            }
        }
    }

    public (float, float) OrbitMotion(Transform focus, float a, float b, float y, float timeToRotate,
        float timeToTranslate, float c, GameObject translateObject, float alpha, float speedMultiply)
    {
        Vector3 center = new Vector3(focus.transform.position.x + c, 0, focus.position.z);

        translateObject.transform.position = new Vector3(center.x + a * Mathf.Cos((alpha/360f) ), y, center.z + b * Mathf.Sin((alpha / 360f) ));
        translateObject.transform.parent.position = translateObject.transform.position;
        translateObject.transform.RotateAround(translateObject.transform.parent.position, translateObject.transform.up, 360f * Time.deltaTime / ReduceTime(timeToRotate, speedMultiply));

        alpha += 360* Time.deltaTime / ReduceTime(timeToTranslate,speedMultiply);

        c = Mathf.Sqrt(a * a - b * b);
        return (c, alpha);
    }

    /// <summary>
    /// Reduz o tempo de translação e rotação
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public float ReduceTime(float value,float multiply)
    {
        return value / multiply;
        //return value / 86400f;
        //return value / 1440f;
    }
}
