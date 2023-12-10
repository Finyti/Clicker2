using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour
{
    public float GradientChange = 0.05f;

    void Start()
    {
        
    }


    void Update()
    {
        if(transform.position.y >= 18 || transform.position.y <= -18)
        {
            GradientChange = -GradientChange;
        }
        transform.position += new Vector3(0, GradientChange, 0);
    }
}
