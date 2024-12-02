using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// 更新摄像头响应
 /// </summary>
public class UpdateMonitorRequest : BaseRequest
{
    protected override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.UpdateMonitor;
        base.Awake();
    }

    public override void OnResponce(string data)
    {
        //这里要将data转换为BeltDataList，再转换为Json,再写入
        ConveyorBeltMonitorDataList dataList = JsonUtility.FromJson<ConveyorBeltMonitorDataList>(data);
        string json = JsonUtility.ToJson(dataList);
        gameFacade.WriteConveyorBeltMonitorConfig(json);
        gameFacade.UpdateConveyorBeltMonitorPath();
    }
}
