using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public static Final instance;

    #region Variables
    [System.NonSerialized] public Transform coffins;
    [System.NonSerialized] public Transform chair;
    [System.NonSerialized] public Transform finishCubes;
    #endregion
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetValues();
    }
    void SetValues()
    {
        coffins = transform.GetChild(1);
        finishCubes = transform.GetChild(0);
        chair = transform.GetChild(2);
    }

}
