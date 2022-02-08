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
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        holdDetection = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
