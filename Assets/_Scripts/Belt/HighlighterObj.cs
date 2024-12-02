using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using System;
using UnityOprationalObj;
using Equipment;
/// <summary>
/// 当物体挂载此脚本时，鼠标放到此物体上，物体会高亮
/// </summary>
public class HighlighterObj : HighlighterBase
{
    private bool isHighLighting;
    /// <summary>
    /// 可操作物体
    /// </summary>
    private OperationalObj operationalObj;
    [SerializeField]
    /// <summary>
    /// 闪烁颜色1
    /// </summary>
    private Color color1 = Color.red;
    [SerializeField]
    /// <summary>
    /// 闪烁颜色2
    /// </summary>
    private Color color2 = Color.green;

    Highlighter _highlighter;

    Highlighter highlighter
    {
        get
        {
            if (_highlighter==null)
            {
                _highlighter = GetComponent<Highlighter>();
            }
            return _highlighter;
        }
    }

    protected override void Start()
    {
        base.Start();
        //operationalObj = GetComponent<OperationalObj>();
        //if (operationalObj == null)
        //{
        //    Debug.Log(string.Format("{0}物体的HighlighterObj无法获取OperationalObj，已自动添加", name));
        //    operationalObj = gameObject.AddComponent<OperationalObj>();
        //}
        //operationalObj.MouseEnterHandleAction += () => { GetComponent<Highlighter>().FlashingOn(color1, color2); isHighLighting = true; };
        //operationalObj.MouseExitHandleAction += () => { GetComponent<Highlighter>().FlashingOff(); isHighLighting = false; };
        //operationalObj.MouseOverHandleAction += () =>
        //{
            //if (!isHighLighting)
            //{
            //    GetComponent<Highlighter>().FlashingOn(color1, color2); isHighLighting = true;
            //}
            //else
            //{

            //    GetComponent<Highlighter>().FlashingOff();
            //    isHighLighting = false;

            //}
       // };
    }
    protected override void OnValidate()
    {
        base.OnValidate();
    }

    public bool IsHighLighting()
    {
        return isHighLighting;
    }
    /// <summary>
    /// 设置高亮颜色
    /// </summary>
    /// <param name="color1"></param>
    /// <param name="color2"></param>
    public void Set_Color(Color color1, Color color2)
    {
        this.color1 = color1;
        this.color2 = color2;
    }
    /// <summary>
    /// 开始高亮
    /// </summary>
    public void StartHighLighting()
    {
        if (highlighter!=null)
        {
            highlighter.FlashingOn(color1, color2);
            isHighLighting = true;
        }
       
    }

    /// <summary>
    /// 停止高亮
    /// </summary>
    public void StopHighLighting()
    {
        if (highlighter != null)
        {
            highlighter.FlashingOff();
            isHighLighting = false;
        }
            
    }

}
