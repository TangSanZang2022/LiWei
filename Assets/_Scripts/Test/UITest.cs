using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using System;
using UnityEngine.EventSystems;

namespace Test
{
    public class UITest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
          Transform button=  transform.FindChildForName("Button");
           UIEventListener.GetUIEventListener(button).pointClickHandler += OnButtonClick;
        }

        private void OnButtonClick(PointerEventData eventData)
        {
            Debug.Log(eventData.pointerPress);
            if (eventData.clickCount==2)
            {
                Debug.Log("双击");
            }
        }


       
    }
}
