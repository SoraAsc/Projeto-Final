using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody rdb; //trata-se do componente que define o material como algo que recebe fisica
    Vector3 dir; //variável que possui 3 posições, que são definidas no codigo posteriormente, essa posição define para onde o asteroid irá ao spawnar.
    [SerializeField] //permite que eu veja e altere valores de variáveis privadas
    float speed = 1f; //a velocidade que o asteroid terá, ao passar

    void Start()
    {
        //todas as cores  que o traço do asteroide poderá ter no começo
        Color[] allStartColor = 
        {
            new Color32(69,152,162,255),
            new Color32(190,121,89,255),
            new Color32(127,95,167,255),
            new Color32(188,157,105,255),
            new Color32(139,29,41,255),
        };

        //todas as cores  que o traço do asteroide poderá ter no fim.
        Color[] allEndColor =
{
            new Color32(233,255,255,255),
            new Color32(255,215,190,255),
            new Color32(255,243,255,255),
            new Color32(255,235,188,255),
            new Color32(255,220,212,255),
        };


        int number = Random.Range(0, allStartColor.Length); //escolhe uma posição "aleatoria" para a cor inicial e final do asteroid
        GetComponent<TrailRenderer>().startColor = allStartColor[number]; //colocando a cor inicial escolhida "aleatoriamente" no componente de rastro.
        GetComponent<TrailRenderer>().endColor = allEndColor[number]; //colocando a cor ifinal escolhida "aleatoriamente" no componente de rastro.
        rdb = GetComponent<Rigidbody>(); //faz a variavel de fisica pegar o componente de fisica do corpo/gameobject atual.
        int value = Random.Range(-1, 1); //escolhe uma direção para o asteroid seguir.
        dir = new Vector3( value == 0 ? 1 : value, -1, value == 0 ? 1 : value); //operador ternário para decidir que valor a direção terá em todos os casos.
        
    }

    // Update is called once per frame
    void Update()
    {
        //adciona uma força ao corpo de acordo com o fps que o computador do usuário tenha
        rdb.AddForce(dir*Time.deltaTime*speed, ForceMode.Force);

        if(transform.position.y<-10000f) //ao chegar a uma determinada posição onde o asteroid está fora da vista do usuário o mesmo é destruido.
        {            
            Destroy(gameObject);
        }
    }

}
