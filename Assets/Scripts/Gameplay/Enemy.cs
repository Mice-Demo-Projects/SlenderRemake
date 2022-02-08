using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    Transform skinHolder;
    #endregion
    private void Start()
    {
        SetValues();
    }
    void SetValues()
    {
        skinHolder = transform.parent.GetChild(0);
    }
    public void Death()
    {
        //Particle oynatýlacak.
        skinHolder.GetChild(0).gameObject.SetActive(false);
        skinHolder.GetChild(1).gameObject.SetActive(true);
    }
}
