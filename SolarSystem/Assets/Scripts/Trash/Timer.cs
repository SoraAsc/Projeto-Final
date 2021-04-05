using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float theTime = 0;

    [SerializeField]
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
    }
}
