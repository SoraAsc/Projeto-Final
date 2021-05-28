using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //[SerializeField]
    //private float theTime = 0;
    //public float theTime = 0;

/*    [SerializeField]
    private float speed = 1f;
    public Text timeText;

    [SerializeField]
    private int anttime = 0;

    public float Speed { get { return speed; } set { speed = value; } }

    
    void Update()
    {
        theTime += Time.deltaTime*speed;
        
        string days = Mathf.Floor((theTime / 86400) % 365).ToString();
        string hours = Mathf.Floor((theTime / 3600) % 24).ToString("00");
        string minutes = Mathf.Floor((theTime / 60) % 60).ToString("00");
        string seconds = Mathf.Floor(theTime % 60).ToString("00");

        timeText.text = "Day: " + days + " - " + hours + ":" + minutes + ":" + seconds;
    }*/

/*    private void Awake()
    {
        theTime = 0;
        //Debug.Log(DateTime.UtcNow.ToString("HH:mm:ss dd MM, yyyy"));

        //Debug.Log(DateTime.UtcNow.Month); //converter em 365 dias
        theTime+= DateTime.UtcNow.Month* 2.628e+6f;

        //Debug.Log(DateTime.UtcNow.Day);
        theTime += DateTime.UtcNow.Day * 86400f;

        //Debug.Log(DateTime.UtcNow.Hour);
        theTime += DateTime.UtcNow.Hour * 3600;

        //Debug.Log(DateTime.UtcNow.Minute); // por enquanto não considerar segundo, passar tudo isso para segundo.
        theTime += DateTime.UtcNow.Minute * 60;

        theTime += DateTime.UtcNow.Second;
        //Debug.Log(theTime / 3.154e+7f);
    }*/
}
