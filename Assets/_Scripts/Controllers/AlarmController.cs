using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 警报控制器
/// </summary>
public class AlarmController : BaseController
{

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="gameFacade"></param>
    public AlarmController(GameFacade gameFacade) : base(gameFacade)
    {

    }

    /// <summary>
    /// 存放所有有报警属性的物体
    /// </summary>
    private List<BaseAlarmObj> alarmObjList = new List<BaseAlarmObj>();
    /// <summary>
    /// 将报警物体添加到列表
    /// </summary>
    /// <param name="baseAlarmObj"></param>
    public void AddAlarmObj(BaseAlarmObj baseAlarmObj)
    {
        if (!alarmObjList.Contains(baseAlarmObj))
        {
            alarmObjList.Add(baseAlarmObj);
        }
    }


}
