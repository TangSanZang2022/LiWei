using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Http;
using System.Web;
using System;
using System.Net;
using UnityHttpServer;
using UnityEngine.UI;
/// <summary>
/// 连接服务器基类
/// </summary>
public class BaseNetConnect : MonoBehaviour, IHandleReceivedMsg
{
    [SerializeField]
    /// <summary>
    /// 服务器URL，
    /// </summary>
    protected string url;
    /// <summary>
    /// HttpServer
    /// </summary>
    private HttpServer httpServer;
    /// <summary>
    /// 从服务器得到的信息
    /// </summary>
    private string getMsgStr;
    /// <summary>
    /// 是否从服务器得到了数据
    /// </summary>
    private bool isGetMsgFromServer = false;
    /// <summary>
    /// 从服务器得到的信息
    /// </summary>
    public string receivedMsg { get; set; }

    // Start is called before the first frame update
  protected virtual void Start()
    {
        if (httpServer!=null)
        {
            return;
        }
        httpServer = new HttpServer(url);
        Debug.Log(string.Format("监听的服务器URL为：{0}",url));
       
        httpServer.Start();
    }

    // Update is called once per frame
   protected virtual void Update()
    {
        if (isGetMsgFromServer)
        {
            HandleInformation(getMsgStr);
            getMsgStr = null;
            isGetMsgFromServer = false;
        }
    }

    /// <summary>
    /// 处理服务器传功来的Json信息
    /// </summary>
    /// <param name="infoStr"></param>
    public virtual void HandleInformation(string infoStr)
    {
        Debug.Log(infoStr);
       
    }
    /// <summary>
    /// 实现IHandleReceivedMsg中处理接收到的信息的方法
    /// </summary>
    public void HandleMsg()
    {
        getMsgStr = receivedMsg;
        isGetMsgFromServer = true;
        Debug.Log(getMsgStr);
    }

    private void OnApplicationQuit()
    {
        if (httpServer!=null)
        {
            httpServer.Stop();
        }
    }

}
