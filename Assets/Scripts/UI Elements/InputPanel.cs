using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [System.NonSerialized] public static InputPanel instance;

    #region Variables
    Vector3 lastPos;
    public bool holdDetection;
    #endregion

    private void Awake()
	{
        instance = this;
	}
    private void Update()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        holdDetection = true;
        PlayerAnimation.instance.PlayAnimation("Walk");

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (LevelManager.gameState == GameState.BeforeStart || LevelManager.gameState == GameState.Normal || !PlayerMovement.instance.gliding)
        {
            holdDetection = false;
            PlayerAnimation.instance.PlayAnimation("Idle");
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (LevelManager.gameState == GameState.Normal)
        {
            PlayerMovement.instance.MoveHorizontal(eventData.delta.x / Screen.width);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
