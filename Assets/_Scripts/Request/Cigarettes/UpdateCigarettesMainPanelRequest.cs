using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 更新烟草主页面Request
/// </summary>
public class UpdateCigarettesMainPanelRequest : BaseRequest
{
    /// <summary>
    /// 对应面板
    /// </summary>
    private BasePanel basePanel;
    private bool isSyncUpdateAllBelt = false;

    private bool isSyncUpdateCigarettesMainPanel_object = false;
    private string data;

    private object dataObj;
    protected override void Awake()
    {
        requestCode = RequestCode.Cigarettes;
        actionCode = ActionCode.UpdateCigarettesMainPanel;
        Debug.Log(string.Format("创建{0}成功", actionCode.ToString()));
        base.Awake();
    }

    private void Update()
    {
        if (isSyncUpdateAllBelt)
        {
            SyncUpdateCigarettesMainPanelData_String();
            isSyncUpdateAllBelt = false;
        }

        if (isSyncUpdateCigarettesMainPanel_object)
        {
            SyncUpdateCigarettesMainPanelData_Object();
            isSyncUpdateCigarettesMainPanel_object = false;
        }
    }
    public override void OnResponce(string data)
    {
        this.data = data;
        isSyncUpdateAllBelt = true;
    }

    public override void OnResponce(object data)
    {
        dataObj = data;
        isSyncUpdateCigarettesMainPanel_object = true;
    }
    /// <summary>
    /// 异步更新所有皮带的状态
    /// </summary>
    private void SyncUpdateCigarettesMainPanelData_String()
    {
        //gameFacade.UpdateAllBelt(data);
        Debug.Log("接收到更新香烟主界面数据" + data);


        basePanel.UpdatePanelData(data);
    }

    /// <summary>
    /// 异步更新所有皮带的状态
    /// </summary>
    private void SyncUpdateCigarettesMainPanelData_Object()
    {
        //gameFacade.UpdateAllBelt(data);
        Debug.Log("接收到更新香烟主界面数据" + dataObj);


        basePanel.UpdatePanelData(dataObj);
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

