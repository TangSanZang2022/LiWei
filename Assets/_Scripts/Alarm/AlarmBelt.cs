using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 皮带的警报
/// </summary>
public class AlarmBelt : BaseAlarmObj
{
    AlarmLightMemoryObj alarm;
    // Start is called before the first frame update
    protected override void Start()
    {

    }
    /// <summary>
    /// 正在警报
    /// </summary>
    public override void Alarming()
    {
       
        if (alarmState==AlarmState.Alarming)
        {
            return;
        }
        Debug.Log("执行");
        alarm =(AlarmLightMemoryObj) GameFacade.Instance.GetObjForObjTypeInPool(MemoryPoolObjType.AlarmLight);//创建警报灯
        alarm.OutPool();
        alarm.transform.localPosition = transform.position + Vector3.up;
        GameFacade.Instance.PlayNormalSound("Alarm",true); //播放报警音效
        base.Alarming();
    }
    /// <summary>
    /// 处理警报
    /// </summary>
    public override void AlarmHandle()
    {
        GetComponent<RodBelt>().Reduction();
        BackToOriginalState();
        base.AlarmHandle();

    }
    /// <summary>
    /// 回到原来状态
    /// </summary>
    public override void BackToOriginalState()
    {
        
        if (alarmState==AlarmState.Original)
        {
            return;
        }
        if (alarm!=null)
        {
            alarm.InPool();
            alarm = null; 
        }
        base.BackToOriginalState();

    }
}
