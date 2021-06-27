using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDo : MonoBehaviour
{
    float duration = 1f;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(WaitBright());
    }
    IEnumerator WaitBright()
    {
        yield return new WaitForSeconds(duration);
        sr.enabled = !sr.enabled;
        StartCoroutine(WaitBright());
    }
}
