using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    public static PlayerCanvas instance;

    #region Variables
    Image fillBar;
    [System.NonSerialized] public Transform title;
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
        fillBar = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        title = transform.GetChild(1);
    }
    public void ChangeFillAmount(float amount)
    {
        fillBar.fillAmount += (amount) / 60f;
    }
}
