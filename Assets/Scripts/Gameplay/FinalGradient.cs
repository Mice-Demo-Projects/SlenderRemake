using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGradient : MonoBehaviour
{
    public Gradient finalGradient;
    private void Start()
    {
        finalGradient.Evaluate(10);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().material.color = finalGradient.Evaluate(i);
        }
    }
}
