using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 更新皮带请求
/// </summary>
public class UpdateBeltRequest : BaseRequest
{
    private bool isSyncUpdateAllBelt = false;
    private string data;
    protected override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.UpdateBelt;
        Debug.Log(string.Format("创建{0}成功", actionCode.ToString()));
        base.Awake();
    }

    private void Update()
    {
        if (isSyncUpdateAllBelt)
        {
            SyncUpdateAllBelt();
            isSyncUpdateAllBelt = false;
        }
    }
    public override void OnResponce(string data)
    {
        this.data = data;
        isSyncUpdateAllBelt = true;
    }
     /// <summary>
     /// 异步更新所有皮带的状态
     /// </summary>
    private void SyncUpdateAllBelt()
    {
        gameFacade.UpdateAllBelt(data);
    }
}
