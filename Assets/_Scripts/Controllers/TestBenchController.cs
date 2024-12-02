using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 验证台控制
/// </summary>
public class TestBenchController : BaseController
{
    /// <summary>
    /// 存放所有检验台的字典
    /// </summary>
    private Dictionary<string, TestBench> allTestBenchDict = new Dictionary<string, TestBench>();
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="facade"></param>
    public TestBenchController(GameFacade facade) : base(facade)
    {

    }
    /// <summary>
    /// 初始化
    /// </summary>
    public override void OnInit()
    {
        base.OnInit();
        SetAllTestBenchDict();
        UpdateTestBenchRequest updateTestBenchRequest = new UpdateTestBenchRequest();
    }

    /// <summary>
    /// 从场景中得到Belt给 allBeltDic赋值
    /// </summary>
    private void SetAllTestBenchDict()
    {
        allTestBenchDict.Clear();
        TestBench[] testBenchs = GameObject.FindObjectsOfType<TestBench>();
        foreach (TestBench t in testBenchs)
        {
            allTestBenchDict.Add(t.GetID(), t);
        }
    }

    /// <summary>
    /// 通过ID得到皮带
    /// </summary>
    /// <param name="materialName"></param>
    /// <returns></returns>
    public TestBench GetTestBenchForID(string testBenchID)
    {
        TestBench b;
        if (!allTestBenchDict.TryGetValue(testBenchID, out b))
        {
            Debug.LogError(string.Format("找不到对应ID：{0}的检验台", testBenchID));
        }
        return b;
    }

    /// <summary>
    /// 根据数据
    /// </summary>
    /// <param name="data"></param>
    public void UpdateAllTestBench(string data)
    {
        TestBenchDataList testBenchDataList = JsonUtility.FromJson<TestBenchDataList>(data);
        List<TestBenchData> testBenchDatas = testBenchDataList.data;
        foreach (TestBenchData TBD in testBenchDatas)
        {
            GetTestBenchForID(TBD.id).UpdateObj(TBD);
        }
    }
}
