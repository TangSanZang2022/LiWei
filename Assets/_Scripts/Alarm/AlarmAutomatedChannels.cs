using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
/// <summary>
/// 自助通道的报警
/// </summary>
public class AlarmAutomatedChannels : BaseAlarmObj
{
    /// <summary>
    /// 高亮组件
    /// </summary>
    Highlighter highlighter;
    /// <summary>
    /// 报警详情UI物体
    /// </summary>
    AlarmUIMemoryObj alarmUIMemoryObj;
    /// <summary>
    /// UI展示信息
    /// </summary>
    private string[] infoStrArray;
    protected override void Start()
    {
        base.Start();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void OnInit()
    {
        highlighter = GetComponent<Highlighter>();
        if (highlighter == null)
        {
            highlighter = gameObject.AddComponent<Highlighter>();
        }
    }
    /// <summary>
    /// 警报中
    /// </summary>
    public override void Alarming()
    {

        if (alarmState == AlarmState.Alarming)
        {
            return;
        }
        highlighter.FlashingOn(Color.red, Color.red);//高亮
                                                     //TODO，创建报警详情UI
        alarmUIMemoryObj = (AlarmUIMemoryObj)GameFacade.Instance.GetObjForObjTypeInPool(MemoryPoolObjType.AlarmUI);
        alarmUIMemoryObj.OutPool(infoStrArray);
        alarmUIMemoryObj.transform.localPosition = transform.position + Vector3.up;

        base.Alarming();
    }
    /// <summary>
    /// 警报处理
    /// </summary>
    public override void AlarmHandle()
    {

        if (alarmState == AlarmState.AlarmHandle)
        {
            return;
        }
        highlighter.FlashingOff();
        base.AlarmHandle();
    }
    /// <summary>
    /// 还原为原来状态
    /// </summary>
    public override void BackToOriginalState()
    {
        if (alarmState == AlarmState.Original)
        {
            return;
        }
        highlighter.FlashingOff();
        alarmUIMemoryObj.InPool();
        base.BackToOriginalState();
    }
    /// <summary>
    /// 设置报警UI信息数组
    /// </summary>
    /// <param name="infoStrArray"></param>
    public void SetInfoStrArray(string[] infoStrArray)
    {
        this.infoStrArray = infoStrArray;
    }
}
