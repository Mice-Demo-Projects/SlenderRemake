using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    #region Variables
    [System.NonSerialized] float playerSpeed;
    [System.NonSerialized] float sensitivity;
    [System.NonSerialized] public bool gliding;
    [System.NonSerialized] public Vector3 playerPos;

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
        sensitivity = 4f;
        gliding = false;
    }
    public void MoveVertical()
    {
        playerPos = transform.position;
        playerPos.z += playerSpeed * Time.deltaTime;
        transform.position = playerPos;
    }
    public void MoveHorizontal(float x)
    {
        if (LevelManager.gameState == GameState.Normal)
        {
            Vector3 temp = new Vector3(x, 0, 0);
            transform.localPosition += temp * sensitivity;
            Vector3 clamp = transform.localPosition;
            clamp.x = Mathf.Clamp(clamp.x, -3.31f, 3.31f);
            transform.localPosition = clamp;
        }
    }
    public void GlideOn()
    {
        gliding = true;
        PlayerAnimation.instance.PlayAnimation("Jumping");
        transform.DOMoveY(6, 0.5f);
    }
    public void GlideOff()
    {
        gliding = false;
        PlayerAnimation.instance.PlayAnimation("Landing");
        transform.DOMoveY(0, 0.6f);
    }
    public void FinalWalk()
    {
        PlayerAnimation.instance.PlayAnimation("Walk");
        transform.DOLocalMove(new Vector3(Final.instance.coffins.position.x, 0, Final.instance.coffins.position.z+13f), 1.5f).OnComplete(() =>
        {
            PlayerAnimation.instance.transform.Rotate(new Vector3(0,180,0));
            PlayerAnimation.instance.PlayAnimation("Sit");
            gliding = true;
            FinalRise();
        }); ;
    }
    public void FinalRise()
    {
        Final.instance.coffins.SetParent(transform);
        float riseAmount;
        switch (Player.instance.state)
        {
            case Player.EvolveStates.Freaky:
                riseAmount = 3f;
                break;
            case Player.EvolveStates.Horrible:
                riseAmount = 10f;
                break;
            case Player.EvolveStates.Monster:
                riseAmount = 16f;
                break;
            default:
                riseAmount = 0f;
                break;
        }
        transform.DOLocalMoveY(riseAmount,5f).OnComplete(() =>
        {
            StartCoroutine(Win());
        }); ; ;
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        CompletePanel.instance.Activator(true);
    }
}
