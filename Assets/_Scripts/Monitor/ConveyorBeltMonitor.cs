using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityMonitor;
using System;
/// <summary>
/// 传送带的摄像头
/// </summary>
public class ConveyorBeltMonitor : BaseMonitor
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    /// <summary>
    /// 打开摄像头
    /// </summary>
    public override void MonitorOn()
    {
        //测试用
        //MonitorPlayerController.PlayMonitor(this);
        // StartCoroutine(IGetPathFromServer());
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
    /// <summary>
    /// 从服务器获取对应摄像头的URLPath
    /// </summary>
    /// <returns></returns>
    IEnumerator IGetPathFromServer()
    {
        string bodyJson = GameFacade.Instance.GetNetConfig().MonitorRequestBodyJson;
        string url = GameFacade.Instance.GetNetConfig().MonitorRequestPath + bodyJson;
        Debug.Log(string.Format("摄像头请求URL为：{0}，BodyJson为：{1}", url, bodyJson));
        UnityWebRequest unityWebRequest = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJson);
        unityWebRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
        unityWebRequest.SetRequestHeader("ContentType", "Application/x-www-from-urlencoded");
        yield return unityWebRequest.SendWebRequest();
        string res = unityWebRequest.downloadHandler.text;
        Debug.Log(string.Format("接收服务器返回信息：{0}", res));
        HandleDataGetFromServer(res);
    }
    /// <summary>
    /// 处理从服务器获取的数据
    /// </summary>
    /// <param name="data"></param>
    private void HandleDataGetFromServer(string data)
    {

        //TODO处理了data之后,调用SetRtspURL()来设置视频流地址再播放
        Debug.Log(string.Format("此处应该将从服务器获取的监控地址赋值给此摄像头的URL"));
        GameFacade.Instance.PlayMonitor(this);
    }
}

/// <summary>
/// 摄像头id和播放路径配置列表
/// </summary>
[Serializable]
public class ConveyorBeltMonitorDataList
{
    public List<ConveyorBeltMonitorData> data;
}
/// <summary>
/// 摄像头id和播放路径配置
/// </summary>
[Serializable]
public class ConveyorBeltMonitorData
{
    /// <summary>
    /// 摄像头ID
    /// </summary>
    public string id;
    /// <summary>
    /// 播放地址
    /// </summary>
    public string path;

}