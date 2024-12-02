using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMonitor;
using MouseSelectObjs;
using ShowHideObj;
using DFDJ;
using Common;
using DG.Tweening;
using Cigarette;
using System;
using Cigarettes;
using IndustrialPlatform;
using MyPos;
using LiWei;
using UnityEngine.Events;

public class GameFacade : MonoSingleton<GameFacade>
{
    /// <summary>
    /// 配置控制器
    /// </summary>
    private XmlController xmlController;
    /// <summary>
    /// 材质球控制器
    /// </summary>
    private MaterialsCntroller materialsCntroller;
    /// <summary>
    /// socket客户端控制器
    /// </summary>
   // private ClientController clientController;
    /// <summary>
    /// 皮带控制器
    /// </summary>
    private BeltController beltController;
    /// <summary>
    /// 摄像头播放器控制器
    /// </summary>
    //private MonitorPlayerController monitorPlayerController;
    /// <summary>
    /// 响应控制器
    /// </summary>
    private RequestController requestController;
    /// <summary>
    /// http客户端控制器
    /// </summary>
    private HttpClientController httpClientController;
    /// <summary>
    /// GPS与Vector3之间转换类
    /// </summary>
    private GisPointTo3DPointController gisPointTo3DPointController;
    /// <summary>
    /// 音频控制器
    /// </summary>
    private AudioController audioController;
    /// <summary>
    /// UI面板控制器
    /// </summary>
    private UIController uiController;
    /// <summary>
    /// 内存池
    /// </summary>
    private MemoryPoolController poolController;
    /// <summary>
    /// 鼠标多选物体中鼠标移动控制
    /// </summary>
    //private MouseMoveController mouseMoveController;
    /// <summary>
    /// 可移动物体控制器
    /// </summary>
    private MoveObjController moveObjController;
    /// <summary>
    /// 检验台控制
    /// </summary>
    private TestBenchController testBenchController;
    /// <summary>
    /// 自助通道控制器
    /// </summary>
    private AutomatedChannelsController automatedChannelsController;
    /// <summary>
    /// 旅客控制
    /// </summary>
    private PassengerController passengerController;
    /// <summary>
    /// 显示隐藏物体控制器
    /// </summary>
    private ShowHideObjController showHideObjController;
    /// <summary>
    /// 相机位置控制器
    /// </summary>
    private PosController camPosController;
    /// <summary>
    /// 相机移动控制
    /// </summary>
    private CameraMoveController cameraMoveController;

    /// <summary>
    /// 设备管理器
    /// </summary>
    private EquipmentController equipmentController;
    /// <summary>
    /// 数据接口控制器
    /// </summary>
    private DataInterfaceController dataInterfaceController;

    /// <summary>
    /// 香烟控制器
    /// </summary>
    private CigaretteController cigaretteController;
    /// <summary>
    /// WebSocketController
    /// </summary>
    //private WebSocketController webSocketController;

    private TruckSpaceController truckSpaceController;

    private CarController carController;
    /// <summary>
    /// 天气，时间切换控制器
    /// </summary>
    private WeatherController weatherController;
    /// <summary>
    /// 游戏状态控制器
    /// </summary>
    private GameStateController gameStateController;
    /// <summary>
    /// 设备控制器
    /// </summary>
    private DevicesController devicesController;
    /// <summary>
    /// 是否已经初始化
    /// </summary>
    private bool isInit = false;


    // Start is called before the first frame update
    void Start()
    {
        InitController();
    }

    private void Update()
    {
        UpdateController();
    }
    private void InitController()
    {
        xmlController = new XmlController(this);
        materialsCntroller = new MaterialsCntroller(this);
        // clientController = new ClientController(this);
        beltController = new BeltController(this);
        requestController = new RequestController(this);
        httpClientController = new HttpClientController(this);
        audioController = new AudioController(this);
        // gisPointTo3DPointController = new GisPointTo3DPointController(this);
        uiController = new UIController(this);
        poolController = new MemoryPoolController(this);
        // mouseMoveController = new MouseMoveController(this);
        moveObjController = new MoveObjController(this);
        testBenchController = new TestBenchController(this);
        automatedChannelsController = new AutomatedChannelsController(this);
        passengerController = new PassengerController(this);
        showHideObjController = new ShowHideObjController(this);
        camPosController = new PosController(this);
        cameraMoveController = new CameraMoveController(this);
        equipmentController = new EquipmentController(this);
        //dataInterfaceController = new DataInterfaceController(this);

        //cigaretteController = new CigaretteController(this);

        //webSocketController = new WebSocketController(this);

        truckSpaceController = new TruckSpaceController(this);
        carController = new CarController(this);
        weatherController = new WeatherController(this);

        gameStateController = new GameStateController(this);
        devicesController = new DevicesController(this);



        xmlController.OnInit();
        materialsCntroller.OnInit();
        audioController.OnInit();
        //clientController.OnInit();
        beltController.OnInit();
        requestController.OnInit();
        httpClientController.OnInit();
        //gisPointTo3DPointController.OnInit();
        uiController.OnInit();
        poolController.OnInit();
        // mouseMoveController.OnInit();
        moveObjController.OnInit();
        testBenchController.OnInit();
        automatedChannelsController.OnInit();
        passengerController.OnInit();
        showHideObjController.OnInit();
        camPosController.OnInit();
        cameraMoveController.OnInit();
        equipmentController.OnInit();
        //dataInterfaceController.OnInit();

        //cigaretteController.OnInit();
        //webSocketController.OnInit();

        truckSpaceController.OnInit();
        carController.OnInit();

        weatherController.OnInit();
        gameStateController.OnInit();
        devicesController.OnInit();
       isInit = true;
    }
    /// <summary>
    /// 更新所有Controller
    /// </summary>
    private void UpdateController()
    {
        xmlController.OnUpdate();
        materialsCntroller.OnUpdate();
        //clientController.OnUpdate();
        beltController.OnUpdate();
        requestController.OnUpdate();
        httpClientController.OnUpdate();
        uiController.OnUpdate();
        // mouseMoveController.OnUpdate();
        audioController.OnUpdate();
        moveObjController.OnUpdate();
        testBenchController.OnUpdate();
        automatedChannelsController.OnUpdate();
        passengerController.OnUpdate();
        showHideObjController.OnUpdate();
        camPosController.OnUpdate();
        cameraMoveController.OnUpdate();
        equipmentController.OnUpdate();
        //dataInterfaceController.OnUpdate();

        //cigaretteController.OnUpdate();
        truckSpaceController.OnUpdate();
        carController.OnUpdate();
        weatherController.OnUpdate();
        gameStateController.OnUpdate();
        devicesController.OnUpdate();
    }
    /// <summary>
    /// 删除所有Controller
    /// </summary>
    private void DestoryController()
    {
        if (!isInit) //如果为多个场景，在本场景第一帧直接切换到第一个场景时，可能会报空
        {
            return;
        }
        xmlController.OnDestory();
        materialsCntroller.OnDestory();
        //clientController.OnDestory();
        beltController.OnDestory();
        requestController.OnDestory();
        httpClientController.OnDestory();
        uiController.OnDestory();
        // mouseMoveController.OnDestory();
        audioController.OnDestory();
        moveObjController.OnDestory();
        testBenchController.OnDestory();
        automatedChannelsController.OnDestory();
        passengerController.OnDestory();
        showHideObjController.OnDestory();
        camPosController.OnDestory();
        cameraMoveController.OnDestory();
        equipmentController.OnDestory();
        //dataInterfaceController.OnDestory();

        //cigaretteController.OnDestory();

        truckSpaceController.OnDestory();
        carController.OnDestory();
        weatherController.OnDestory();
        gameStateController.OnDestory();
        devicesController.OnDestory();
    }
    /// <summary>
    /// 处理从服务器接收的消息
    /// </summary>
    /// <param name="msg"></param>
    public void HandleMsg(string msg)
    {
        Debug.Log(string.Format("接收到数据：{0}", msg));
    }
    /// <summary>
    /// 添加ActionCode的时候处理消息
    /// </summary>
    /// <param name="actionCode"></param>
    /// <param name="data"></param>
    public void HandleMsg(ActionCode actionCode, string data)
    {
        requestController.HandleResponse(actionCode, data);
    }
    /// <summary>
    /// 传入object
    /// </summary>
    /// <param name="actionCode"></param>
    /// <param name="data"></param>
    public void HandleMsg(ActionCode actionCode, object data)
    {
        requestController.HandleResponse(actionCode, data);
    }
    /// <summary>
    /// 获取XmlController中NetConfig
    /// </summary>
    /// <returns></returns>
    public NetConfig GetNetConfig()
    {
        return xmlController.NetConfig;
    }
    /// <summary>
    /// 读取警察UI展示数据
    /// </summary>
    public void ReadPoliceInfos()
    {
        xmlController.ReadPoliceInfos();
    }

    /// <summary>
    /// 将可移动物体从字典中移除
    /// </summary>
    /// <param name="id"></param>
    public void RemoveMoveObjInDic(string id)
    {
        moveObjController.RemoveObjInDic(id);
    }
    /// <summary>
    /// 写入皮带摄像头配置
    /// </summary>
    /// <param name="json"></param>
    public void WriteConveyorBeltMonitorConfig(string json)
    {
        xmlController.WriteConveyorBeltMonitorConfig(json);
    }
    /// <summary>
    /// 获取XmlController中List<ConveyorBeltMonitorData>
    /// </summary>
    /// <returns></returns>
    public List<ConveyorBeltMonitorData> GetConveyoryBeltMonitorDataList()
    {
        return xmlController.ConveyorBeltMonitorData;
    }
    /// <summary>
    /// 更新所有摄像头的路径
    /// </summary>
    public void UpdateConveyorBeltMonitorPath()
    {
        //monitorPlayerController.UpdateConveyorBeltMonitorPath();
    }
    /// <summary>
    /// 根据材质球的名称得到
    /// </summary>
    /// <param name="materialName"></param>
    /// <returns></returns>
    public Material GetMaterialForName(string materialName)
    {
        return materialsCntroller.GetMaterialForName(materialName);
    }
    /// <summary>
    /// 根据皮带的ID来获取对应的皮带
    /// </summary>
    /// <param name="beltID"></param>
    /// <returns></returns>
    public BaseBelt GetBeltForID(string beltID)
    {
        return beltController.GetBeltForID(beltID);
    }
    /// <summary>
    /// 更新所有的皮带
    /// </summary>
    /// <param name="data"></param>
    public void UpdateAllBelt(string data)
    {
        beltController.UpdateAllBelt(data);
    }
    /// <summary>
    /// 播放点击的摄像头
    /// </summary>
    /// <param name="monitor_Click"></param>
    public void PlayMonitor(BaseMonitor monitor_Click)
    {
       // monitorPlayerController.PlayMonitor(monitor_Click);
    }
    /// <summary>
    /// 添加摄像头到列表
    /// </summary>
    /// <param name="baseMonitor"></param>
    public void AddMonitors(BaseMonitor baseMonitor)
    {
        //monitorPlayerController.AddMonitors(baseMonitor);
    }
    /// <summary>
    /// 将摄像头从列表移出
    /// </summary>
    /// <param name="baseMonitor"></param>
    public void RemoveMonitors(BaseMonitor baseMonitor)
    {
        //monitorPlayerController.RemoveMonitors(baseMonitor);
    }
    /// <summary>
    /// 播放多个摄像头
    /// </summary>
    /// <param name="monitors_Click"></param>
    public void PlayMonitors()
    {
        //monitorPlayerController.PlayMonitors();
    }
    /// <summary>
    /// 将request添加到字典
    /// </summary>
    /// <param name="actionCode"></param>
    /// <param name="baseRequest"></param>
    public void AddRequest(ActionCode actionCode, BaseRequest baseRequest)
    {
        requestController.AddRequest(actionCode, baseRequest);
    }
    /// <summary>
    /// 将Request从字典中移出
    /// </summary>
    /// <param name="actionCode"></param>
    public void RemoveRequest(ActionCode actionCode)
    {
        if (requestController == null)
        {
            return;
        }
        requestController.removeRequest(actionCode);
    }
    /// <summary>
    /// 发送请求
    /// </summary>
    public void SendRequest(string data)
    {
        // clientController.SendRequest(data);
    }
    /// <summary>
    ///播放背景音乐
    /// </summary>
    /// <param name="soundName"></param>
    public void PlayBGSound(string soundName)
    {
        audioController.PlayBGSound(soundName);
    }
    /// <summary>
    /// 播放一般音乐
    /// </summary>
    /// <param name="soundName"></param>
    public void PlayNormalSound(string soundName, bool isLoop = false)
    {
        audioController.PlayNormalSound(soundName, isLoop);
    }
    /// <summary>
    /// 面板入栈，将面板显示出来
    /// </summary>
    /// <param name="panelType"></param>
    public BasePanel PushPanel(UIPanelType panelType)
    {
        return uiController.PushPanel(panelType);
    }
    /// <summary>
    /// 面板出栈，将面板隐藏起来
    /// </summary>
    public void PopPanel()
    {
        uiController.PopPanel();
    }

    /// <summary>
    /// 得到栈顶面板
    /// </summary>
    /// <returns></returns>
    public BasePanel GetTopPanel()
    {
        return uiController.GetTopPanel();
    }
    /// <summary>
    /// 根据物体类型的到内存池
    /// </summary>
    /// <param name="memoryPoolObjType">物体类型</param>
    /// <returns></returns>
    public BaseMemoryPool GetMemoryPool(MemoryPoolObjType memoryPoolObjType)
    {
        return poolController.GetMemoryPool(memoryPoolObjType);
    }
    /// <summary>
    /// 根据物体类型得到内存池中对应的物体
    /// </summary>
    /// <param name="memoryPoolObjType">物体类型</param>
    /// <returns></returns>
    public BaseMemoryObj GetObjForObjTypeInPool(MemoryPoolObjType memoryPoolObjType, string pathEnd = "")
    {
        return poolController.GetObjForObjType(memoryPoolObjType, pathEnd);
    }

    /// <summary>
    /// 通过所有数据来更新可移动物体位置
    /// </summary>
    /// <param name="moveObjDataList"></param>
    public void UpdateAllMoveObjPos(string data)
    {
        moveObjController.UpdateAllMoveObjPosFromStr(data);
    }

    /// <summary>
    /// 设置UI展示信息
    /// </summary>
    /// <param name="baseInfo"></param>
    public void SetBaseInfo(IBaseInfo baseInfo)
    {
        moveObjController.SetBaseInfo(baseInfo);
    }
    /// <summary>
    /// 更新所有检验台
    /// </summary>
    /// <param name="data"></param>
    public void UpdateAllTestBench(string data)
    {
        testBenchController.UpdateAllTestBench(data);
    }
    /// <summary>
    /// 更新自助通道
    /// </summary>
    /// <param name="data"></param>
    public void UpdateAllAutomatedChannels(string data)
    {
        automatedChannelsController.UpdateAllAutomatedChannels(data);
    }
    /// <summary>
    /// 根据接收的数据
    /// </summary>
    /// <param name="data"></param>
    public void UpdatePassengersForStr(string data)
    {
        passengerController.UpdatePassengersForStr(data);
    }

    /// <summary>
    /// 根据ID来找到显示隐藏的物体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BaseShowHideObj GetShowHideObjForID(string id)
    {
        return showHideObjController.GetShowHideObjForID(id);
    }
    /// <summary>
    /// 根据ID显示物体
    /// </summary>
    /// <param name="id"></param>
    public GameObject ShowObjForID(string id)
    {

        return showHideObjController.ShowObjForID(id);
    }
    /// <summary>
    /// 根据ID隐藏物体
    /// </summary>
    /// <param name="id"></param>
    public void HideObjForID(string id)
    {
        showHideObjController.GetShowHideObjForID(id).Hide();
    }
    /// <summary>
    /// 设置物体到目标点
    /// </summary>
    /// <param name="id"></param>
    /// <param name="targetCam"></param>
    public BasePos SetTarnsToPos(string id, Transform targetCam,float time=-1)
    {
        return camPosController.SetTarnsToPos(id, targetCam, time);
    }
    /// <summary>
    /// 设置移动DoTween
    /// </summary>
    /// <param name="newTweener"></param>
    public void Set_moveTweener(Tweener newTweener)
    {
        camPosController.Set_moveTweener(newTweener);
    }
    /// <summary>
    /// 获取当前获取当前相机所在位置
    /// </summary>
    /// <returns></returns>
    public BasePos GetCurrentCamPos()
    {
        return camPosController.GetCurrentCamPos();
    }
    /// <summary>
    /// 设置缩放速率
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetZoomRate(int zoomRate)
    {
        cameraMoveController.SetZoomRate(zoomRate);
    }

    /// <summary>
    /// 设置最远观察距离
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetMaxObservationDis(float maxObservationDis)
    {
        cameraMoveController.SetMaxObservationDis(maxObservationDis);
    }
    /// <summary>
    /// 设置最近观察距离
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetMinObservationDis(float minObservationDis)
    {
        cameraMoveController.SetMinObservationDis(minObservationDis);
    }

    /// <summary>
    /// 设置水平方向最大移动距离
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetMaxDisH(float maxDisH)
    {
        cameraMoveController.SetMaxDisH(maxDisH);
    }
    /// <summary>
    /// 设置竖直方向最大移动距离
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetMaxDisV(float maxDisV)
    {
        cameraMoveController.SetMaxDisV(maxDisV);
    }
    /// <summary>
    /// 设置水平竖直平面移动速度
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetDeltaMoveSpeed(float deltaMoveSpeed)
    {
        cameraMoveController.SetDeltaMoveSpeed(deltaMoveSpeed);
    }

    /// <summary>
    /// 设置水平转动时的速度
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetRotSpeedH(float rotSpeedH)
    {
        cameraMoveController.SetRotSpeedH(rotSpeedH);
    }
    /// <summary>
    /// 设置竖直转动时的速度
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetRotSpeedV(float rotSpeedV)
    {
        cameraMoveController.SetRotSpeedV(rotSpeedV);
    }
    /// <summary>
    /// 设置相机水平移动时的速度
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetMoveSpeed(float moveSpeed)
    {
        cameraMoveController.SetMoveSpeed(moveSpeed);
    }

    /// <summary>
    /// 设置竖直方向最大旋转角度
    /// </summary>
    /// <param name="zoomRate"></param>
    public void SetMaxRotV(float maxRotV)
    {
        cameraMoveController.SetMaxRotV(maxRotV);
    }
    /// <summary>
    /// 设置是否可以水平移动
    /// </summary>
    /// <param name="canMoveHV"></param>
    public void Set_canMoveHV(bool canMoveHV)
    {
        cameraMoveController.Set_canMoveHV(canMoveHV);
    }
    /// <summary>
    /// 设置是否可以缩放
    /// </summary>
    /// <param name="canMoveHV"></param>
    public void Set_canZoom(bool canZoom)
    {
        cameraMoveController.Set_canZoom(canZoom);
    }
    /// <summary>
    /// 设置是否可以旋转
    /// </summary>
    /// <param name="canMoveHV"></param>
    public void Set_canRot(bool canRot)
    {
        cameraMoveController.Set_canRot(canRot);
    }
    /// <summary>
    /// 设置相机是否可以旋转，平移，缩放
    /// </summary>
    /// <param name="b"></param>
    public void Set_AllCamControll(bool b)
    {
        Set_canMoveHV(b);
        Set_canRot(b);
        Set_canZoom(b);
    }
    /// <summary>
    /// 设置是否围绕目标点寻转
    /// </summary>
    /// <param name="isRotAroundTarget"></param>
    public void Set_isRotAroundTarget(bool isRotAroundTarget)
    {
        cameraMoveController.Set_isRotAroundTarget(isRotAroundTarget);
    }
    /// <summary>
    /// 设置是否锁定旋转中心
    /// </summary>
    /// <param name="isLock"></param>
    public void Set_lock_ZoomTarget(bool isLock)
    {
        cameraMoveController.Set_lock_ZoomTarget(isLock);
    }
    /// <summary>
    /// 设置相机旋转中心
    /// </summary>
    /// <param name="pos"></param>
    public void Set_rotTarget(Vector3 pos)
    {
        cameraMoveController.Set_rotTarget(pos);
    }
    /// <summary>
    /// 设置旋转中心点
    /// </summary>
    /// <param name="pos"></param>
    public void Set_zoomTarget(Vector3 pos)
    {
        cameraMoveController.Set_zoomTarget(pos);
    }
    /// <summary>
    /// 设置lock_rotTarget
    /// </summary>
    /// <param name="isLock"></param>
    public void Set_lock_rotTarget(bool isLock)
    {
        cameraMoveController.Set_lock_rotTarget(isLock);
    }
    /// <summary>
    /// 设置实现缩放的方式，如果为False,则为用设置相机Field of View来实现缩放
    /// </summary>
    /// <param name="isMoveForZoom"></param>
    public void Set_moveForZoom(bool isMoveForZoom)
    {
        cameraMoveController.Set_moveForZoom(isMoveForZoom);
    }
    /// <summary>
    /// 设置相机FieldOfView到初始状态
    /// </summary>
    public void Set_myCameraFieldOfViewToNormal()
    {
        cameraMoveController.Set_myCameraFieldOfViewToNormal();
    }
    
    /// <summary>
    /// 根据ID查找设备
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Equipment.BaseEquipment GetBaseEquipmentForID(string id)
    {
        return equipmentController.GetBaseEquipmentForID(id);

    }
    /// <summary>
    /// 传入object类型数据解析
    /// </summary>
    /// <param name="dataObj"></param>
    public void SyncUpdateCigarettesEquipmentData_Object(object dataObj)
    {
        equipmentController.SyncUpdateCigarettesEquipmentData_Object(dataObj);
    }
    /// <summary>
    /// 传入object类型数据解析
    /// </summary>
    /// <param name="dataObj"></param>
    public void SyncUpdateCigarettesEquipmentData_String(string dataStr)
    {
        equipmentController.SyncUpdateCigarettesEquipmentData_String(dataStr);
    }

    /// <summary>
    /// 根据设备ID，前往该设备的最佳视角位置
    /// </summary>
    /// <param name="id"></param>
    /// <param name="moveTrans"></param>
    public void GoToEquipmentBestViewPosForID(string id, Transform moveTrans)
    {
        equipmentController.GoToEquipmentBestViewPosForID(id, moveTrans);
    }
    /// <summary>
    /// 重置所有isAtBestViewPos
    /// </summary>
    public void ResetAll_isAtBestViewPos()
    {
        equipmentController.ResetAll_isAtBestViewPos();
    }
    
    /// <summary>
    /// 得到最近的设备,然后自动点击
    /// </summary>
    /// <returns></returns>
    public void GetNearestEquipmentAndClick()
    {
        equipmentController.GetNearestEquipmentAndClick();
    }
    /// <summary>
    /// 停止所有设备实时数据
    /// </summary>
    public void StopAllEquipmentRealTimeDataFromServer()
    {
        equipmentController.StopAllEquipmentRealTimeDataFromServer();
    }
    /// <summary>
    /// 读取到的数据接口
    /// </summary>
    public DataInterfaceConfig GetDataInterfaceConfig()
    {
        return dataInterfaceController.DataInterfaceConfig;
    }
    /// <summary>
    /// 获取HTTPRequest地址
    /// </summary>
    /// <param name="hTTPRequestType">HTTPRequest类型</param>
    /// <param name="sign">签名</param>
    /// <param name="device">设备编号</param>
    /// <param name="item">设备采集码编号</param>
    /// <param name="start">开始时间</param>
    /// <param name="end">结束时间</param>
    /// <returns></returns>
    public string GetHTTPRequestPath(HTTPRequestType hTTPRequestType, string sign, string device, string item, string start, string end)
    {
        return dataInterfaceController.GetHTTPRequestPath(hTTPRequestType, sign, device, item, start, end);
    }

    /// <summary>
    /// 根据ID查找香烟
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BaseCigarette GetBaseCigaretteForID(string id)
    {
        return cigaretteController.GetBaseCigaretteForID(id);
    }
    /// <summary>
    /// 从字典中移除对应ID的香烟
    /// </summary>
    /// <param name="id"></param>
    public void RemoveBaseCigaretteForID(string id)
    {
        cigaretteController.RemoveBaseCigaretteForID(id);
    }
    /// <summary>
    /// 从字典中移除对应香烟
    /// </summary>
    /// <param name="id"></param>
    public void RemoveBaseCigarette(BaseCigarette baseCigarette)
    {
        cigaretteController.RemoveBaseCigarette(baseCigarette);
    }




    /// <summary>
    /// 暂停所有香烟的移动
    /// </summary>
    public void PauseAllCigaretteMove()
    {
        cigaretteController.PauseAllCigaretteMove();

    }
    /// <summary>
    /// 暂停所有香烟的移动
    /// </summary>
    public void PlayAllCigaretteMove()
    {
        cigaretteController.PlayAllCigaretteMove();

    }
    /// <summary>
    /// 随机创建香烟
    /// </summary>
    public void CreateBaseCigarette()
    {
        cigaretteController.CreateBaseCigarette();

    }

    /// <summary>
    /// 获取月台数据
    /// </summary>
    /// <returns></returns>
    public int[] Get_TruckSpaceNum()
    {
        return truckSpaceController.Get_TruckSpaceNum();
    }
    /// <summary>
    /// 得到所有月台空闲时间数据
    /// </summary>
    /// <returns></returns>
    public List<FreePlatformItemData> GetFreePlatformItemDatas()
    {
        return truckSpaceController.GetFreePlatformItemDatas();
    }
    /// <summary>
    /// 更新车辆和空闲月台
    /// </summary>
    public void Update_CarNum()
    {
        BasePanel basePanel = GetTopPanel();
        IndustrialPlatformMainPanel industrialPlatformMainPanel = basePanel as IndustrialPlatformMainPanel;
        industrialPlatformMainPanel.UpdateCarNum(Get_TruckSpaceNum());
        industrialPlatformMainPanel.UpdateOrderNum(new int[] { industrialPlatformMainPanel.OrderNum[0]++, industrialPlatformMainPanel.OrderNum[1]++ });
    }

    /// <summary>
    /// 得到所有车辆实时信息
    /// </summary>
    /// <returns></returns>
    public List<RealTimeCarItemData> GetRealTimeCarItemDatas()
    {
       return carController.GetRealTimeCarItemDatas();
    }
    /// <summary>
    /// 更新车辆和空闲月台
    /// </summary>
    public void UpdateRealTimeCarContent()
    {
        BasePanel basePanel = GetTopPanel();
        IndustrialPlatformMainPanel industrialPlatformMainPanel = basePanel as IndustrialPlatformMainPanel;
        industrialPlatformMainPanel.UpdateRealTimeCarContent(GetRealTimeCarItemDatas());
    }

    /// <summary>
    /// 设置天气
    /// </summary>
    /// <param name="weather">"sun":晴天，"cloudy":阴天，"rain":雨天，"snow":雪天</param>
    public void SetWeather(string weather)
    {
        weatherController.SetWeather(weather);
    }
    /// <summary>
    /// 设置时间
    /// </summary>
    /// <param name="timeString">"morning":早上,"noon":中午,"afternoon":下午,"night":晚上</param>
    public void SetTime(string timeString)
    {
        weatherController.SetTime(timeString);
    }
    /// <summary>
    /// 开启雪的覆盖效果
    /// </summary>
    public void Start_globalSnow()
    {
        weatherController.Start_globalSnow();

    }
    /// <summary>
    /// 停止雪的覆盖效果
    /// </summary>
    public void Stopt_globalSnow()
    {
        weatherController.Stop_globalSnow();

    }
    /// <summary>
    /// 设置到上一个天气和时间
    /// </summary>
    public void WeatherTime_Back()
    {
        weatherController.WeatherTime_Back();
    }
    /// <summary>
    /// 设置为最佳天气和时间
    /// </summary>
    public void SetBestWeatherAndTime()
    {
        weatherController.SetBestWeatherAndTime();
    }
    /// <summary>
    /// 获取相机状态
    /// </summary>
    /// <returns></returns>
    public GameState Get_gameState()
    {
        return gameStateController.Get_gameState();
    }
    /// <summary>
    /// 设置游戏状态
    /// </summary>
    /// <param name="state"></param>
    public void Set_gameState(GameState state, UnityAction unityAction = null)
    {
        gameStateController.Set_gameState(state, unityAction);
    }

    /// <summary>
    /// 添加部件到字典
    /// </summary>
    /// <param name="baseDevicesPart"></param>
    public void AddBaseDevices(LiWeiBaseDevices baseDevicesPart)
    {
        devicesController.AddBaseDevices(baseDevicesPart);
    }
    /// <summary>
    /// 根据ID从字典中获取部件
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public LiWeiBaseDevices Get_BaseDevicesInDict(string key)
    {
        return devicesController.Get_BaseDevicesInDict(key);
    }
    /// <summary>
    /// 设置当前选中的设备
    /// </summary>
    /// <param name="baseDevices"></param>
    public void Set_currentDevices(LiWeiBaseDevices baseDevices)
    {
        devicesController.Set_currentDevices(baseDevices);
    }

    /// <summary>
    /// 设置当前选中的设备,只改变值，不做任何其他操作
    /// </summary>
    /// <param name="baseDevices"></param>
    public void Set_currentDevicesOnlyChangeValue(LiWeiBaseDevices baseDevices)
    {
        devicesController.Set_currentDevicesOnlyChangeValue(baseDevices);
    }
    /// <summary>
    /// 得到当前部件
    /// </summary>
    /// <returns></returns>
    public LiWeiBaseDevices Get_currentDevices()
    {
        return devicesController.Get_currentDevices();
    }
    /// <summary>
    /// 仅仅显示当前模型
    /// </summary>
    public void ShowCurrentDevices()
    {
        devicesController.ShowCurrentDevices();
    }
    /// <summary>
    /// 设置场景其他模型的显示隐藏
    /// </summary>
    /// <param name="active"></param>
    public void Set_SceneOtherModel_Active(bool active)
    {
        devicesController.Set_SceneOtherModel_Active(active);
    }
    /// <summary>
    /// 设置相机背景图片的显示隐藏状态
    /// </summary>
    /// <param name="active"></param>
    public void Set_CamTransCanvas_Active(bool active)
    {
        devicesController.Set_CamTransCanvas_Active(active);
    }
    /// <summary>
    /// 根据设备ID到设备视角
    /// </summary>
    /// <param name="id"></param>
    public void GoToDevicesForID(string id = "")
    {
        devicesController.GoToDevicesForID(id);
    }
    /// <summary>
    /// 回到当前设备
    /// </summary>
    public void BackToCurrentDevices()
    {
        devicesController.BackToCurrentDevices();
    }
    /// <summary>
    /// 回到设备的最佳视角
    /// </summary>
    public void SetCamToCurrentDevicesBestViewPos()
    {
        devicesController.SetCamToCurrentDevicesBestViewPos();
    }
    /// <summary>
    /// 透视模式
    /// </summary>
    public void SetToFadeMode(float alpha = 0.01f, float fadeTime = 5f)
    {
        devicesController.SetToFadeMode(alpha, fadeTime);
    }
    /// <summary>
    /// 爆炸模式
    /// </summary>
    public void SetToBombMode()
    {
        devicesController.SetToBombMode();
    }
    /// <summary>
    /// 到默认设备的默认部件位置
    /// </summary>
    /// <param name="id"></param>
    public void GoToPartForID(string id = "")
    {
        devicesController.GoToPartForID(id);
    }
    private void OnDestroy()
    {
        DestoryController();
    }
}
