using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 可放入内存池的报警介绍UI
/// </summary>
public class AlarmUIMemoryObj : BaseMemoryObj
{
    private Text[] alarmInfoTextArray;
    /// <summary>
    /// 展示报警信息的Text数组
    /// </summary>
    private Text[] AlarmInfoTextArray
    {
        get
        {
            if (alarmInfoTextArray==null)
            {
                alarmInfoTextArray = transform.GetChild(0).GetChild(0).GetComponentsExceptParentAndChildedChild<Text>();
            }
            return alarmInfoTextArray;
        }
    }
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="obj"></param>
    protected override void Init(object[] obj = null)
    {
        base.Init(obj);
        SetAlarmInfo(obj as string[]);
    }
    /// <summary>
    /// 出内存池
    /// </summary>
    /// <param name="obj"></param>
    public override void OutPool(object[] obj = null)
    {
        base.OutPool(obj);
    }
    /// <summary>
    /// 设置报警信息
    /// </summary>
    /// <param name="infoArray"></param>
    private void SetAlarmInfo(string[] infoArray)
    {
        for (int i = 0; i < AlarmInfoTextArray.Length; i++)
        {
            AlarmInfoTextArray[i].text = infoArray[i];
        }
    }
}
