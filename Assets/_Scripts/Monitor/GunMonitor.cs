using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMonitor;
/// <summary>
/// 枪型摄像头
/// </summary>
public class GunMonitor : BaseMonitor
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
    private void CreateScreenUIIcon()
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

    public override void MonitorOff()
    {
        base.MonitorOff();
    }
   
}
