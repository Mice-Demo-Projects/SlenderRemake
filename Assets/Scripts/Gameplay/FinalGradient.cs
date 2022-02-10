using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGradient : MonoBehaviour
{
    public static FinalGradient instance;
    public Gradient finalGradient;
    public List<GameObject> coloredList = new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    public void Paint(Collider other)
    {
        coloredList.Add(other.gameObject);
        for (int i = 0; i < coloredList.Count; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().material.color = finalGradient.colorKeys[i].color;

        }
    }
}
