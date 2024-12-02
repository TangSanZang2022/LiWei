using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
using UnityEngine.AI;
using System;
/// <summary>
/// 场景中可移动物体基类
/// </summary>
public class BaseMoveObject : OperationalObj
{
    /// <summary>
    /// 存放轨迹点的列表
    /// </summary>
    protected List<Vector3> trackPpintsList = new List<Vector3>();
    /// <summary>
    /// 寻路组件
    /// </summary>
    protected NavMeshAgent meshAgent;
    /// <summary>
    /// 轨迹回放控制器
    /// </summary>
   protected ReplayController replayController;

    /// <summary>
    /// 子物体中UI介绍的物体
    /// </summary>
    private BaseInfoUIObj UIObj
    {
        get
        {
            //获得子物体中第一个物体身上的 BaseInfoUIObj组件，用于初始化此物体的具体信息
            return transform.GetChild(0).GetComponent<BaseInfoUIObj>();

        }
    }
    [SerializeField]
    /// <summary>
    /// 寻路的速度
    /// </summary>
    private float moveSpeed;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.speed = moveSpeed;

        replayController = GameObject.Find("ReplayController").GetComponent<ReplayController>();
       // uIObj = 
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

       
    }
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init(MoveObjData moveObjData)
    {
        SetID(moveObjData.ID);//设置ID，用于下次更新位置
    }
     /// <summary>
     /// 设置介绍UI信息
     /// </summary>
     /// <param name="baseInfo"></param>
    public void SetBaseInfo(IBaseInfo baseInfo)
    {
        Debug.Log(transform.name);
        //设置在UI上展示的信息
        UIObj.SetBaseInfo(baseInfo);
    }
    /// <summary>
    /// 鼠标按下
    /// </summary>
    protected override void MouseDownHandle()
    {
        base.MouseDownHandle();
        //按住Ctrl键点击鼠标，创建人物的具体信息UI
        if (Input.GetKey(KeyCode.LeftControl))
        {
            CreateIntroductionUI(); 
        }
        //测试用，鼠标点击回访轨迹
       
    }
    /// <summary>
    /// 将接收的数据转换为Vector3之后，更新位置
    /// </summary>
    /// <param name="data"></param>
    public override void UpdateObj(object data)
    {
        base.UpdateObj(data);
        Vector3 targetPos = (Vector3)receivedData;//目标点坐标
        UpdatePos(targetPos);
    }
    /// <summary>
    /// 点击物体之后创建介绍UI
    /// </summary>
    protected virtual void CreateIntroductionUI()
    {
        //打开Ui界面
        UIObj.OpenUI();
    }
    /// <summary>
    /// 更新位置
    /// </summary>
    /// <param name="targetPos"></param>
    private void UpdatePos(Vector3 targetPos)
    {
        trackPpintsList.Add(transform.position);//将物体当前坐标存入列表，后面物体移动轨迹回放使用
        meshAgent.SetDestination(targetPos);
    }
  

}
[Serializable]
public class MoveObjDataList
{
    public List<MoveObjData> moveObjDatas;
}
/// <summary>
/// 可移动物体的数据
/// </summary>
[Serializable]
public class MoveObjData : IMoveObjData
{
    /// <summary>
    /// 物体ID
    /// </summary>
    public string ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    /// <summary>
    /// GPS 设备ID 
    /// </summary>
    public string id;
    /// <summary>
    /// X轴坐标
    /// </summary>
    public double x;
    /// <summary>
    /// Y轴坐标
    /// </summary>
    public double y;
    /// <summary>
    /// Z轴坐标
    /// </summary>
    public double z;
    /// <summary>
    /// 看我移动物体的类型，用于创建可移动物体时区分
    /// </summary>
    public string objType;
}
