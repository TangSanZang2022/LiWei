using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 更新烟草设备的Request
/// </summary>
public class UpdateCigarettesEquipmentRequest : BaseRequest
{
    /// <summary>
    /// 对应面板
    /// </summary>
    private BasePanel basePanel;
    private bool isSyncUpdateCigarettesEquipment = false;

    private bool isSyncUpdateCigarettesEquipment_object = false;
    private string data;

    private object dataObj;
    protected override void Awake()
    {
        requestCode = RequestCode.Cigarettes;
        actionCode = ActionCode.UpdateCigarettesEquipment;
        Debug.Log(string.Format("创建{0}成功", actionCode.ToString()));
        base.Awake();
    }

    private void Update()
    {
        if (isSyncUpdateCigarettesEquipment)
        {
            SyncUpdateCigarettesEquipmentData_String();
            isSyncUpdateCigarettesEquipment = false;
        }

        if (isSyncUpdateCigarettesEquipment_object)
        {
            SyncUpdateCigarettesEquipmentData_Object();
            isSyncUpdateCigarettesEquipment_object = false;
        }
    }
    public override void OnResponce(string data)
    {
        this.data = data;
        isSyncUpdateCigarettesEquipment = true;
    }

    public override void OnResponce(object data)
    {
        dataObj = data;
        isSyncUpdateCigarettesEquipment_object = true;
    }
    /// <summary>
    /// 异步更新所有皮带的状态
    /// </summary>
    private void SyncUpdateCigarettesEquipmentData_String()
    {
        //gameFacade.UpdateAllBelt(data);
        Debug.Log("接收到更新香烟主界面数据" + data);


    }

    /// <summary>
    /// 异步更新所有皮带的状态
    /// </summary>
    private void SyncUpdateCigarettesEquipmentData_Object()
    {
        //gameFacade.UpdateAllBelt(data);
        Debug.Log("接收到更新香烟主界面数据" + dataObj);
        gameFacade.SyncUpdateCigarettesEquipmentData_Object(dataObj);

        //basePanel.UpdatePanelData(dataObj);
    }
    /// <summary>
    /// 设置对应的面板
    /// </summary>
    /// <param name="basePanel"></param>
    public void Set_basePanel(BasePanel basePanel)
    {
        this.basePanel = basePanel;
    }
}
