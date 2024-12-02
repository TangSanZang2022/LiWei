using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MySlider : Slider, IBeginDragHandler, IEndDragHandler
{
    /// <summary>
    /// 是否在拖动滑块
    /// </summary>
    public bool IsDraging
    {
        get;
        private set;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        IsDraging = false;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
       IsDraging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        IsDraging = false;
    }
   

}
