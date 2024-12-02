using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
public enum AlarmState
{
    /// <summary>
    /// 初始状态
    /// </summary>
    Original,
    /// <summary>
    /// 正在警报
    /// </summary>
    Alarming,
    /// <summary>
    /// 警报处理
    /// </summary>
    AlarmHandle
}
public class BaseAlarmObj : OperationalObj
{
    protected AlarmState alarmState;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        alarmState = AlarmState.Original;
    }

    // Update is called once per frame
    protected override  void Update()
    {

    }
    /// <summary>
    /// 正在警报
    /// </summary>
    public virtual void Alarming()
    {
        if (alarmState==AlarmState.Alarming)
        {
            Debug.Log("返回");
            return;
        }
        alarmState = AlarmState.Alarming;
    }
    /// <summary>
    /// 警报中的时候点击之后的处理
    /// </summary>
    public virtual void AlarmHandle()
    {
        if (alarmState==AlarmState.AlarmHandle)
        {
            return;
        }
        alarmState = AlarmState.AlarmHandle;

    }
    /// <summary>
    /// 回到原来状态
    /// </summary>
    public virtual void BackToOriginalState()
    {
        if (alarmState==AlarmState.Original)
        {
            return;
        }
        alarmState = AlarmState.Original;
    }
    /// <summary>
    /// 鼠标点击之后处理警报
    /// </summary>
    protected override void MouseDownHandle()
    {
        base.MouseDownHandle();
        if (alarmState==AlarmState.Alarming)
        {
            AlarmHandle();
        }
    }
}
