using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Equipment;
using System;
using Cigarette;
/// <summary>
/// 设备管理器
/// </summary>
public class EquipmentController : BaseController
{
    /// <summary>
    /// 当前所在最佳视角的设备
    /// </summary>
    private BaseEquipment currentBestViewEquipment;
    public EquipmentController(GameFacade gameFacade) : base(gameFacade)
    {
        UpdateCigarettesEquipmentRequest UpdateCigarettesEquipmentRequest = new GameObject("UpdateCigarettesEquipmentRequest").AddComponent<UpdateCigarettesEquipmentRequest>();
    }
    /// <summary>
    /// 存放所有设备的字典
    /// </summary>
    private Dictionary<string, BaseEquipment> allEquipmentDict = new Dictionary<string, BaseEquipment>();
    private BaseEquipment[] equipments;
    public override void OnInit()
    {
        SetAllEquipmentController();
    }

    public void SetAllEquipmentController()
    {
        BaseEquipment[] baseEquipments = GameObject.FindObjectsOfType<BaseEquipment>();
        foreach (BaseEquipment item in baseEquipments)
        {
            if (!allEquipmentDict.ContainsKey(item.GetID()))
            {
                allEquipmentDict.Add(item.GetID(), item);
            }
            else
            {
                Debug.LogError(string.Format("allEquipmentDict中已经存在Key为{0}的键", item.GetID()));
            }
        }
        equipments = GameObject.FindObjectsOfType<BaseEquipment>();
    }
    /// <summary>
    /// 将设备添加到字典中
    /// </summary>
    /// <param name="baseEquipment"></param>
    public void AddBaseEquipment(BaseEquipment baseEquipment)
    {
        if (!allEquipmentDict.ContainsKey(baseEquipment.GetID()))
        {
            allEquipmentDict.Add(baseEquipment.GetID(), baseEquipment);
        }
        else
        {
            Debug.LogError(string.Format("allEquipmentDict中已经存在Key为{0}的键", baseEquipment.GetID()));
        }
    }
    /// <summary>
    /// 根据ID查找设备
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BaseEquipment GetBaseEquipmentForID(string id)
    {
        BaseEquipment baseEquipment;
        if (!allEquipmentDict.TryGetValue(id, out baseEquipment))
        {
            Debug.LogError(string.Format("allEquipmentDict中不经存在Key为{0}的键", id));
        }
        return baseEquipment;
    }
    /// <summary>
    /// 根据设备ID，前往该设备的最佳视角位置
    /// </summary>
    /// <param name="id"></param>
    /// <param name="moveTrans"></param>
    public void GoToEquipmentBestViewPosForID(string id, Transform moveTrans)
    {
        //if (currentBestViewEquipment != null)
        //{
        //    currentBestViewEquipment.isAtBestViewPos = false;
        //}
        //BaseEquipment baseEquipment = GetBaseEquipmentForID(id);
        //baseEquipment.GoToBestViewPos(moveTrans);
        //currentBestViewEquipment = baseEquipment;
        //facade.Set_isRotAroundTarget(true);
        //facade.Set_canRot(true);
        //facade.Set_rotTarget(baseEquipment.transform.position);
        //facade.Set_lock_rotTarget(true);
        //facade.Set_canZoom(true);
        //facade.Set_moveForZoom(false);
    }
    /// <summary>
    /// 重置所有isAtBestViewPos
    /// </summary>
    public void ResetAll_isAtBestViewPos()
    {
        //foreach (BaseEquipment item in allEquipmentDict.Values)
        //{
        //    if (item.isAtBestViewPos)
        //    {
        //        item.isAtBestViewPos = false;
        //    }
        //}
        //facade.Set_isRotAroundTarget(true);
        //facade.Set_canRot(true);
        //facade.Set_lock_rotTarget(false);
        //facade.Set_canZoom(false);
        //facade.Set_moveForZoom(true);
    }
    /// <summary>
    /// 根据设备所在房间，获取设备
    /// </summary>
    /// <param name="equipmentRoom"></param>
    /// <returns></returns>
    //public List<BaseEquipment> GetBaseEquipmentForEquipmentRoom(EquipmentRoom equipmentRoom)
    //{
    //    List<BaseEquipment> baseEquipmentList = new List<BaseEquipment>();
    //    foreach (var item in allEquipmentDict.Values)
    //    {
    //        if (item.equipmentRoom==equipmentRoom)
    //        {
    //            baseEquipmentList.Add(item);
    //        }
    //    }
    //    return baseEquipmentList;
    //}
    /// <summary>
    /// 得到最近的设备,然后自动点击
    /// </summary>
    /// <returns></returns>
    public void GetNearestEquipmentAndClick()
    {
        //BasePos basePos = GameFacade.Instance.GetCurrentCamPos();
        //if (basePos!=null&&basePos.GetID()!=GameObjIDTool.HeavyEquipmentRoamtPos)//不在固定路线漫游下，就不执行
        //{
        //    return;
        //}
        //BasePanel basePanel = facade.GetTopPanel();
        //BaseEquipment[] baseEquipmentCanSee = equipments.FindAll((b) => b.isCanSee);
        //if (baseEquipmentCanSee.Length == 0 && basePanel.panelType == UIPanelType.HeavyEquipmentDataPanel)
        //{
        //    GameFacade.Instance.PopPanel();
        //}
        //else if (basePanel.panelType == UIPanelType.HeavyEquipmentRoamtPanel)
        //{
        //    HeavyEquipmentRoamtPanel heavyEquipmentRoamtPanel = basePanel as HeavyEquipmentRoamtPanel;
        //    if (heavyEquipmentRoamtPanel.GetCamMode() != CamMode.Normal)
        //    {
        //        BaseEquipment baseEquipmentNearest = baseEquipmentCanSee.GetMin((b) => b.GetComponent<ObjDictance>().distanceFromTargetTrans);
        //        if (baseEquipmentNearest != null)
        //        {
        //            baseEquipmentNearest.AutoClick();
        //        }
        //    }
        //}
        //else if (basePanel.panelType == UIPanelType.HeavyEquipmentDataPanel)
        //{
        //    BaseEquipment baseEquipmentNearest = baseEquipmentCanSee.GetMin((b) => b.GetComponent<ObjDictance>().distanceFromTargetTrans);
        //    if (baseEquipmentNearest != null)
        //    {
        //        baseEquipmentNearest.AutoClick();
        //    }
        //}


    }
    /// <summary>
    /// 停止所有设备实时数据
    /// </summary>
    public void StopAllEquipmentRealTimeDataFromServer()
    {
        //for (int i = 0; i < equipments.Length; i++)
        //{
        //    equipments[i].StopRealTimeData();
        //}

    }
    /// <summary>
    /// 传入object类型数据解析
    /// </summary>
    /// <param name="dataObj"></param>
    public void SyncUpdateCigarettesEquipmentData_Object(object dataObj)
    {
        DataForLaserCodingMachineData dataForLaserCodingMachine = dataObj as DataForLaserCodingMachineData;
        switch (dataForLaserCodingMachine.data.laserBase.name)
        {

            case "激光打印机":
                LaserCodingMachine laserCodingMachine = GetBaseEquipmentForID("LaserCodingMachine").GetComponent<LaserCodingMachine>();
                laserCodingMachine.Set_laserBase(dataForLaserCodingMachine.data.laserBase);
                laserCodingMachine.Set_signal(dataForLaserCodingMachine.data.signal);
                CigaretteWorldUIIconData cigaretteWorldUIIconData=new CigaretteWorldUIIconData();
                cigaretteWorldUIIconData.name = dataForLaserCodingMachine.data.laserBase.name;
                cigaretteWorldUIIconData.startUpTime = dataForLaserCodingMachine.data.laserBase.startUpTime;
                cigaretteWorldUIIconData.onlineTime = dataForLaserCodingMachine.data.laserBase.onlineTime;
                cigaretteWorldUIIconData.separateEfficiency = dataForLaserCodingMachine.data.laserBase.separateEfficiency;
                cigaretteWorldUIIconData.separateProgress = dataForLaserCodingMachine.data.laserBase.separateProgress;
                cigaretteWorldUIIconData.hangUpCount = dataForLaserCodingMachine.data.laserBase.hangUpCount;
                cigaretteWorldUIIconData.stateText = dataForLaserCodingMachine.data.signal.GetSatate();
                laserCodingMachine.Set_equipmentWorldIconObjData(cigaretteWorldUIIconData);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 传入object类型数据解析
    /// </summary>
    /// <param name="dataObj"></param>
    public void SyncUpdateCigarettesEquipmentData_String(string dataStr)
    {

    }
    public override void OnUpdate()
    {

    }
    public override void OnDestory()
    {

    }
}
