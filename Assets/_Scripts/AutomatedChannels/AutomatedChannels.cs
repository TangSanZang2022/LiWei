using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
/// <summary>
/// 自助通道
/// </summary>
public class AutomatedChannels : OperationalObj
{
    /// <summary>
    /// 装子物体的容器
    /// </summary>
    private List<IUpdateHandle> childTestBenchList = new List<IUpdateHandle>();
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void OnInit()
    {
        //将子物体中实现了IUpdateHandle接口的物体添加到列表中
        childTestBenchList.AddRange(transform.GetComponentsExceptParentAndChildedChild<IUpdateHandle>());
    }
    /// <summary>
    /// 更新自助通道状态
    /// </summary>
    /// <param name="data"></param>
    public override void UpdateObj(object data)
    {
        //将接收到的数据转换为自助通道的更新数据
        AutomatedChannelsData automatedChannelsData = data as AutomatedChannelsData;
        foreach (IUpdateHandle item in childTestBenchList)
        {
            item.UpdateHandle(automatedChannelsData);
        }
        //处理报警情况
        if (automatedChannelsData.isAlarm == "1")
        {
            string[] infos = new string[] { automatedChannelsData.alarmType, automatedChannelsData.alarmContent,
                automatedChannelsData.alarmParticulars, automatedChannelsData.alarmTime };
            GetComponent<AlarmAutomatedChannels>().SetInfoStrArray(infos);
            GetComponent<AlarmAutomatedChannels>().Alarming();
        }
        else
        {
            GetComponent<AlarmAutomatedChannels>().BackToOriginalState();
        }

    }
}

[Serializable]
public class AutomatedChannelsDataList
{
    public List<AutomatedChannelsData> data = new List<AutomatedChannelsData>();
}
[Serializable]
/// <summary>
/// 自助通道数据类
/// </summary>
public class AutomatedChannelsData
{
    /// <summary>
    /// 检验台的ID
    /// </summary>
    public string id;
    /// <summary>
    /// 状态
    /// </summary>
    public string state;
    /// <summary>
    /// 是否报警,1为报警，0为没有报警
    /// </summary>
    public string isAlarm;
    /// <summary>
    /// 报警类型
    /// </summary>
    public string alarmType;
    /// <summary>
    /// 报警内容
    /// </summary>
    public string alarmContent;
    /// <summary>
    /// 报警详情
    /// </summary>
    public string alarmParticulars;
    /// <summary>
    /// 报警时间
    /// </summary>
    public string alarmTime;
}