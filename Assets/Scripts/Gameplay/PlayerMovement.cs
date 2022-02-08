using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    #region Variables
    [System.NonSerialized] float playerSpeed;
    #endregion
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetValues();
    }
    private void Update()
    {
        if (InputPanel.instance.holdDetection && LevelManager.gameState == GameState.Normal)
        {
            MoveVertical();
        }
    }
    void SetValues()
    {
        playerSpeed = 10f;
    }
    public void MoveVertical()
    {
        Vector3 playerPos = transform.position;
        playerPos.z += playerSpeed * Time.deltaTime;
        transform.position = playerPos;
    }
    public void MoveHorizontal()
    {
        if (LevelManager.gameState == GameState.Normal)
        {

        }
    }
    public void GlideOn()
    {
        transform.DOMoveY(6, 0.5f);
    }
    public void GlideOff()
    {
       transform.DOMoveY(0.8f, 1);
    }
}
