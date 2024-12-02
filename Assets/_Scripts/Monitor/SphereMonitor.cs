using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMonitor;
/// <summary>
/// 球形摄像头
/// </summary>
public class SphereMonitor : BaseMonitor
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }
    /// <summary>
    /// 打开监控
    /// </summary>
    public override void MonitorOn()
    {
        Debug.Log(string.Format("播放的视频地址为：{0}", GetRtspURL()));
        GameFacade.Instance.PlayMonitor(this);
    }
    /// <summary>
    /// 关闭摄像头
    /// </summary>
    public override void MonitorOff()
    {
        base.MonitorOff();
    }
}
