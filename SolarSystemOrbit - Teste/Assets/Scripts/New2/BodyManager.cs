using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    public List<Body> allBodies;
    public float gravity;
    bool canMove = false;
    private void Awake()
    {
        canMove = false;
        allBodies.AddRange(GameObject.FindObjectsOfType(typeof(Body)) as Body[]);
        for (int i = 0; i < allBodies.Count; i++)
        {
            allBodies[i].currentVelocity = allBodies[i].initialSpeed;
            allBodies[i].material = allBodies[i].GetComponent<MeshRenderer>().material;
            allBodies[i].trail = allBodies[i].GetComponentInChildren<TrailRenderer>();
        }
    }
    private void FixedUpdate()
    {
        if (canMove)
        {

            for (int i = 0; i < allBodies.Count; i++)
            {
                for (int j = 0; j < allBodies.Count; j++)
                {
                    if (i != j && allBodies[j].initialSpeed.magnitude != 0)
                    {
                        float dir = (allBodies[i].transform.position - allBodies[j].transform.position).magnitude;
                        Vector3 forceDir = (allBodies[i].transform.position - allBodies[j].transform.position).normalized;
                        Vector3 acceleration = forceDir * gravity * allBodies[i].mass / (dir * dir);
                        allBodies[j].currentVelocity += acceleration;
                    }
                }
            }
        }
        for (int i = 0; i < allBodies.Count; i++)
        {
            allBodies[i].transform.position += allBodies[i].currentVelocity;
        }

    }

    public void GiveMovement()
    {
        for (int i = 0; i < allBodies.Count; i++)
        {
            allBodies[i].currentVelocity = allBodies[i].initialSpeed;
            allBodies[i].initialPos = allBodies[i].transform.position;
            allBodies[i].trail.Clear();
        }
        canMove = true;
    }

    public void BackToOrigin()
    {
        canMove = false;
        for (int i = 0; i < allBodies.Count; i++)
        {
            allBodies[i].currentVelocity = Vector3.zero;
            allBodies[i].transform.position = allBodies[i].initialPos;
            allBodies[i].trail.Clear();
        }        
    }

    public int GetNumOfBodies()
    {
        return allBodies.Count;
    }

    public Sprite GetSprite(int index)
    {
        return allBodies[index].sprite;
    }

    public void AddNewBody(Body body)
    {
        allBodies.Add(body);
    }

    public void RemoveBody(Body body)
    {
        allBodies.Remove(body);
        Destroy(body.gameObject);
    }
}
