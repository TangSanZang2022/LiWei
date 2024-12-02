using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 更新自助通道请求
/// </summary>
public class UpdateAutomatedChannelsRequest : BaseRequest
{
    /// <summary>
    /// 是否异步更新自助通道状态
    /// </summary>
    private bool isSyncUpdateAutomatedChannels;
    /// <summary>
    /// 接收到的数据
    /// </summary>
    private string data;
    protected override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.UpdateAutomatedChannels;
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSyncUpdateAutomatedChannels)
        {
            isSyncUpdateAutomatedChannels = false;
            gameFacade.UpdateAllAutomatedChannels(data);
        }
    }
     /// <summary>
     /// 接收到消息之后的响应
     /// </summary>
     /// <param name="data"></param>
    public override void OnResponce(string data)
    {
        this.data = data;
        isSyncUpdateAutomatedChannels = true;
    }
}
