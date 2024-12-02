using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 更新检验台请求
/// </summary>
public class UpdateTestBenchRequest : BaseRequest
{
    /// <summary>
    /// 是否异步更新检验台状态数据
    /// </summary>
    private bool isSyncUpdateTestBench = false;
    /// <summary>
    /// 接收到的消息，用于异步更新
    /// </summary>
    private string data;


    protected override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.UpdateTestBench;
        base.Awake();
    }

    private void Update()
    {
        if (isSyncUpdateTestBench)
        {
            //TODO 这里更新检验台数据
            isSyncUpdateTestBench = false;
            gameFacade.UpdateAllTestBench(data);
        }
    }
    public override void OnResponce(string data)
    {
        base.OnResponce(data);
        this.data = data;
        isSyncUpdateTestBench = true;
    }


}
