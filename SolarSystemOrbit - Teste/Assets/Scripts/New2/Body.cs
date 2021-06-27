using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Body : MonoBehaviour
{
    public new string name;
    public float mass;
    public Vector3 initialSpeed;
    public Vector3 currentVelocity;
    public Sprite sprite;
    public Material material;
    public TrailRenderer trail;
    public Vector3 initialPos;
}
