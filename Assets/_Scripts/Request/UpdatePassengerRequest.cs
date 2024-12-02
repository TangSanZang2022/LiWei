using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 更新旅客信息请求
/// </summary>
public class UpdatePassengerRequest : BaseRequest
{
    /// <summary>
    /// 是否异步更新
    /// </summary>
    private bool isSynsUpdatePassenger = false;
    private string data;
    protected override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.UpdatePassenger;
        base.Awake();
    }

    private void Update()
    {
        if (isSynsUpdatePassenger)
        {
            gameFacade.UpdatePassengersForStr(data);
            isSynsUpdatePassenger = false;
        }
    }
    /// <summary>
    /// 接收到信息之后的响应
    /// </summary>
    /// <param name="data"></param>
    public override void OnResponce(string data)
    {
        this.data = data.Trim();
        isSynsUpdatePassenger = true;
    }
}
