using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeOrbit : MonoBehaviour
{
    //cada planeta tem uma linha de orbita.
    LineRenderer line; 
    [SerializeField] float alpha;
    [SerializeField] float a;
    [SerializeField] float b;
    [SerializeField] float c;
    [SerializeField] Vector3 center;
    [SerializeField] Transform focus1;

    public void Initialize(float newA,float newB,Transform newFocus1)
    {
        a = newA;
        b = newB;
        focus1 = newFocus1;
    } //inicializa os valores necessários para montar a orbita.


    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>(); //pega o componente de linha presente no gameobject.
        line.useWorldSpace = false;
    }
    private void OnEnable()
    {
        Application.onBeforeRender += CreateLine;
    }    
    private void OnDisable()
    {
        Application.onBeforeRender -= CreateLine;
    }
    public void CreateLine()
    {
        center = new Vector3(focus1.transform.position.x + c, 0, focus1.position.z); //da um valor para a variavel centro, sendo o eixo x a soma entre o foco 1 que seria o sol e a metade do eixo focal
        // já o eixo y n veremos sua profundidade, logo pode se deixar 0, a profundida aqui é o eixo y, em vez do z pq a camera está posicionado em uma posição onde o eixo y vira a profundidade.
        // e o eixo z só pega a posição do eixo z do sol.

        c = Mathf.Sqrt(a * a - b * b); //usando a formula de pitagoras descobrimos o valor da metade do eixo focal.

        //O update serve para corrigir as falhas que a linha tem, tornando a quase inperceptivel para o usuário.
        //nisso é usado um for para percorrer toda a linha, que é dividida em um angulo de 360 e assim cada linha toma uma determinada posição
        // seguindo uma volta completa.
        for (int i = 0; i < line.positionCount; i++)
        {
            alpha = alpha + 360 / (line.positionCount - 1) * Mathf.Deg2Rad;
            line.SetPosition(i, new Vector3(center.x + a * Mathf.Sin(alpha), 0, center.z + b * Mathf.Cos(alpha)));
        }
        alpha = 0;
    }


    /*    void LateUpdate()
        {
            center = new Vector3(focus1.transform.position.x + c, 0, focus1.position.z); //da um valor para a variavel centro, sendo o eixo x a soma entre o foco 1 que seria o sol e a metade do eixo focal
            // já o eixo y n veremos sua profundidade, logo pode se deixar 0, a profundida aqui é o eixo y, em vez do z pq a camera está posicionado em uma posição onde o eixo y vira a profundidade.
            // e o eixo z só pega a posição do eixo z do sol.

            c = Mathf.Sqrt(a * a - b * b); //usando a formula de pitagoras descobrimos o valor da metade do eixo focal.

            //O update serve para corrigir as falhas que a linha tem, tornando a quase inperceptivel para o usuário.
            //nisso é usado um for para percorrer toda a linha, que é dividida em um angulo de 360 e assim cada linha toma uma determinada posição
            // seguindo uma volta completa.
            for (int i = 0; i < line.positionCount; i++)
            {
                alpha = alpha + 360 / (line.positionCount - 1) * Mathf.Deg2Rad;
                line.SetPosition(i, new Vector3(center.x + a * Mathf.Sin(alpha) , 0, center.z + b * Mathf.Cos(alpha)));
            }
            alpha = 0;
        }*/
}
