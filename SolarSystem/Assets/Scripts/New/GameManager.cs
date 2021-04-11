using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //responsável por administrar maioria do componentes no jogo, seja os planetas, estrelas entre outros.

    public List<Planet> planets;
    [SerializeField] GameObject prefabAster; //prefab da estrela, basicamente um gameobject padrão da estrela para ser usado a qualquer mommento.
    [SerializeField] float chance = 0.2f, delay = 5f; 
    [SerializeField] float radius = 45000f;


    private void Start()
    {
        Application.targetFrameRate = 60;
        OrganizeAlpha();
        StartCoroutine(DelaySpawn()); //Ao iniciar é chamado a chance de aparecer uma estrela.
    }

    public void OrganizeAlpha()
    {
        for(int i = 0; i < planets.Count; i++)
        {
            planets[i].alpha = GetAlphaValue(planets[i].planetTimeToTranslate);

            for(int j = 0; j < planets[i].SateliteNatural.Count; j++)
            {
                planets[i].SateliteNatural[j].alpha = GetAlphaValue(planets[i].SateliteNatural[j].satelliteTimeToTranslate);
            }
        }
    }

    public float GetAlphaValue(float duration)
    {
        float alpha = (GetComponent<Timer>().theTime / 1440f); /// 3.154e+7f)* 360; //22000
        //Debug.Log(alpha);
        return alpha;
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(delay);
        if (Random.Range(0.0f, 1.0f) < chance)
        {
            Vector3 spawnPos = Vector3.zero + Random.onUnitSphere * radius;
            GameObject newStar = Instantiate(prefabAster, spawnPos, Quaternion.identity); //as GameObject;
            newStar.transform.LookAt(Vector3.zero);
        }
        //No final é chamado novamente a função para chamar uma estrela.
        StartCoroutine(DelaySpawn());
    }
}
