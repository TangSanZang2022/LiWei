using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeeObjText : MonoBehaviour
{
    private bool isRender;
    private bool IsRender
    {
        set
        {
            if (!isRender&&value)
            {
                See();
            }
            else if(isRender&&!value)
            {
                Miss();
            }
            isRender = value;
        }
    }
    private float lastTime;
    private float currentTime;
    /// <summary>
    /// controlUpdate 控制update内isRender为false时的开关
    /// </summary>
    private bool controlUpdate;

    private void Start()
    {
        Init();
    }
    void Init()
    {
        controlUpdate = false;
        IsRender = true;
        lastTime = 0;
        currentTime = 0;
    }

    void OnWillRenderObject()
    {

        //if (Camera.current.name == Camera.main.name)//是需要渲染的摄像机
        //{
        //    currentTime = Time.time;
        //}
        currentTime = Time.time;
    }

    void Update()
    {
       if (!controlUpdate && currentTime != 0)
        {
            IsRender = currentTime != lastTime ? true : false;
            lastTime = currentTime;
           // if (!isRender)
            {
              //  controlUpdate = true;
                //TODO:
            }
        }

    }

    public void See()
    {
        Debug.Log("看见物体");
    }

    public void Miss()
    {
        Debug.Log("看不见物体");
    }

}
