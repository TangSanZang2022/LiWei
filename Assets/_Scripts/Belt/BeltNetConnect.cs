using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取皮带数据的网络连接
/// </summary>
public class BeltNetConnect : BaseNetConnect
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
    /// 处理获取的信息
    /// </summary>
    /// <param name="infoStr"></param>
    public override void HandleInformation(string infoStr)
    {
        base.HandleInformation(infoStr);
        //TODO将接收到的字符串转换为BeltData类型然后进行更新状态
        BeltData beltData = new BeltData();
        UpDateBeltState(beltData);
    }
    /// <summary>
    /// 更新皮带状态
    /// </summary>
    private void UpDateBeltState(BeltData beltData)
    {
      GameFacade.Instance.GetBeltForID(beltData.ID).UpdateObjSync(new object[] {beltData});
    }
}

