using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
/// <summary>
/// 警察详细信息UI界面
/// </summary>
public class PoliceInfoUIObj : BaseInfoUIObj
{
    /// <summary>
    /// 展示信息的Text列表
    /// </summary>
    private Text[] infoText = new Text[8];
    /// <summary>
    /// 关闭界面按钮
    /// </summary>
    private Button closeBtn;
    /// <summary>
    /// 警员的信息
    /// </summary>
    private PoliceInfo policeInfo;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }
    /// <summary>
    /// 初始化,获取组件等
    /// </summary>
    protected override void Init()
    {
        Transform bgImg = transform.Find("PoliceInfoUI/Image");
        infoText = bgImg.GetComponentsInChildren<Text>();
        closeBtn = bgImg.Find("CloseButton").GetComponent<Button>();
        closeBtn.onClick.AddListener(CloseUI);
    }
    /// <summary>
    /// 初始化UI展示的内容
    /// </summary>
    protected override void InitUIContent()
    {
        SetTextContent(infoText[0], policeInfo.name);
        SetTextContent(infoText[1], policeInfo.policeNum);
        SetTextContent(infoText[2], policeInfo.sex);
        SetTextContent(infoText[3], policeInfo.tel);
        SetTextContent(infoText[4], policeInfo.department);
        SetTextContent(infoText[5], policeInfo.job);
        SetTextContent(infoText[6], policeInfo.polickRank);
        SetTextContent(infoText[7], policeInfo.post);
    }

   
    /// <summary>
    /// 设置要展示在Ui上的信息字段
    /// </summary>
    /// <param name="baseInfo"></param>
    public override void SetBaseInfo(IBaseInfo baseInfo)
    {
        PoliceInfo p = baseInfo as PoliceInfo;
        policeInfo = new PoliceInfo();
        this.policeInfo.id = p.id;
        this.policeInfo.name = p.name;
        this.policeInfo.policeNum = p.policeNum;
        this.policeInfo.sex = p.sex;
        this.policeInfo.tel = p.tel;
        this.policeInfo.department = p.department;
        this.policeInfo.job = p.job;
        this.policeInfo.polickRank = p.polickRank;
        this.policeInfo.post = p.post;
    }

    /// <summary>
    /// 获取金叉信息
    /// </summary>
    /// <returns></returns>
    public PoliceInfo GetPliceInfo()
    {
        return policeInfo;
    }
}
public class PoliceInfos
{
    public List<PoliceInfo> PoliceInfoList = new List<PoliceInfo>();
}
/// <summary>
/// 警察的信息
/// </summary>
[Serializable]
public class PoliceInfo : IBaseInfo
{
    /// <summary>
    /// ID
    /// </summary>
    public string id;
    /// <summary>
    /// 姓名
    /// </summary>
    public string name;
    /// <summary>
    /// 警号
    /// </summary>
    public string policeNum;
    /// <summary>
    /// 性别
    /// </summary>
    public string sex;
    /// <summary>
    /// 电话
    /// </summary>
    public string tel;
    /// <summary>
    /// 部门
    /// </summary>
    public string department;
    /// <summary>
    /// 职务
    /// </summary>
    public string job;
    /// <summary>
    /// 警衔
    /// </summary>
    public string polickRank;
    /// <summary>
    /// 岗位
    /// </summary>
    public string post;

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
}

