using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 检察员Ui信息类
/// </summary>
public class FactFinderInfoUIObj : BaseInfoUIObj
{
    /// <summary>
    /// 展示检察员信息Text数组
    /// </summary>
    private Text[] infoText = new Text[6];
    /// <summary>
    /// 关闭按钮
    /// </summary>
    private Button closeBtn;
    /// <summary>
    /// 检察员信息类
    /// </summary>
    private FactFinderInfo factFinderInfo;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// 初始化，获取组件等
    /// </summary>
    protected override void Init()
    {
        Transform bgImg = transform.Find("PoliceInfoUI/Image");
        infoText = bgImg.GetComponentsInChildren<Text>();
        closeBtn = bgImg.Find("CloseButton").GetComponent<Button>();
        closeBtn.onClick.AddListener(CloseUI);//添加关闭按钮事件
    }
    /// <summary>
    /// 初始化UI展示的内容
    /// </summary>
    protected override void InitUIContent()
    {
        SetTextContent(infoText[0], factFinderInfo.name);
        SetTextContent(infoText[1], factFinderInfo.sex);
        SetTextContent(infoText[2], factFinderInfo.department);
        SetTextContent(infoText[3], factFinderInfo.personNum);
        SetTextContent(infoText[4], factFinderInfo.startTime);
        SetTextContent(infoText[5], factFinderInfo.burningTime);
    }
    /// <summary>
    /// 设置检察员信息
    /// </summary>
    /// <param name="baseInfo"></param>
    public override void SetBaseInfo(IBaseInfo baseInfo)
    {
        //TODO
        FactFinderInfo f = baseInfo as FactFinderInfo;
        factFinderInfo = new FactFinderInfo();
        factFinderInfo.name = f.name;
        factFinderInfo.sex = f.sex;
        factFinderInfo.department = f.department;
        factFinderInfo.personNum = f.personNum;
        factFinderInfo.startTime = f.startTime;
        factFinderInfo.burningTime = f.burningTime;

    }
}
public class FactFinderInfos
{
    public List<FactFinderInfo> FactFinderInfoList = new List<FactFinderInfo>();
}
/// <summary>
///检察员的信息
/// </summary>
[Serializable]
public class FactFinderInfo : IBaseInfo
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
    /// 性别
    /// </summary>
    public string sex;
    /// <summary>
    /// 部门
    /// </summary>
    public string department;
    /// <summary>
    /// 验收人员
    /// </summary>
    public string personNum;
    /// <summary>
    /// 上台时间
    /// </summary>
    public string startTime;
    /// <summary>
    /// 本次时长
    /// </summary>
    public string burningTime;

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