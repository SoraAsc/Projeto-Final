using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    //Essa classe é executada apenas uma vez no inicio do jogo.

    [SerializeField] GameObject starPrefab;
    [SerializeField] int starMax = 50;
    [SerializeField] float distanceMax = 25000f;
    [SerializeField] float distanceMin = 20000f;
    [SerializeField] float chanceSpawn=0.2f;
    readonly Color[] allColor = new Color[4];
    [SerializeField] Transform starFather;
    private void Awake()
    {
        //Color 0 - branco | 1 - red | 2 - blue 3 - amarelo
        allColor[0] = new Color32(247, 249, 248,255);

        allColor[1] = new Color32(254, 138, 96, 255);

        allColor[2] = new Color32(211, 215, 250, 255);

        allColor[3] = new Color32(250, 209, 82, 255);


        //Todas as estrelas são colocadas em um GameObject vazio para manter a organização.
        for(int i = 0; i < starMax; i++) //Roda isso até atingir o máximo de estrelas definidas.
        {
            //spawna a estrela em um angulo de 360 e em uma direção afastada do centro.
            Vector3 spawnPosition = Random.onUnitSphere * (Random.Range(distanceMin,distanceMax) + 20f * 0.5f) + Vector3.zero; 
            
            GameObject newStar = Instantiate(starPrefab, spawnPosition, Quaternion.identity); //as GameObject; //cria o gameobject da estrela.
            newStar.transform.parent = starFather; //torna a estrelha filha do gameobject vazio.
            newStar.transform.LookAt(Vector3.zero); //faz a estrela olhar para o centro, assim não importa a direção que o jogador esteja, sempre irá
            //ver a estrela.
            
            newStar.GetComponent<SpriteRenderer>().color = allColor[Random.Range(0, 4)]; //escolhe entre as 4 cores disponiveis para a estrela.
            if (Random.Range(0.0f, 1.0f)<chanceSpawn)
            {
                newStar.AddComponent<StarDo>(); //tem chance de adicionar uma classe na estrela que é responsável por fazer ela piscar.
            }
        }
    }

}
