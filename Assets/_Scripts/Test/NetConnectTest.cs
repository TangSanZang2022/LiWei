using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 测试与HTTP服务器连接
/// </summary>
public class NetConnectTest : BaseNetConnect
{
    protected override void Start()
    {
        url = GameFacade.Instance.GetNetConfig().HttpServerPath;
        base.Start();

    }
    protected override void Update()
    {
        base.Update();
    }
   /// <summary>
   /// 处理服务器传过来的信息
   /// </summary>
   /// <param name="infoStr"></param>
    public override void HandleInformation(string infoStr)
    {
        base.HandleInformation(infoStr);
        Text informationText = GameObject.Find("Canvas/InformationText").GetComponent<Text>();
        informationText.text = infoStr;
    }
}
