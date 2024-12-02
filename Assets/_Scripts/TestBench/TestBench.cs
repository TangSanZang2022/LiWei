using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
using System;
/// <summary>
/// 验证台
/// </summary>
public class TestBench : OperationalObj
{
    /// <summary>
    /// 装子物体的容器
    /// </summary>
    private List<IUpdateHandle> childTestBenchList = new List<IUpdateHandle>();
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void OnInit()
    {
        childTestBenchList.AddRange(transform.GetComponentsExceptParentAndChildedChild<IUpdateHandle>());
    }
    /// <summary>
    /// 还原为初始状态
    /// </summary>
    public override void Reduction()
    {
        base.Reduction();
    }
    /// <summary>
    /// 更新状态
    /// </summary>
    /// <param name="data"></param>
    public override void UpdateObj(object data)
    {
        TestBenchData testBenchData = data as TestBenchData;
        foreach (IUpdateHandle item in childTestBenchList)
        {
            item.UpdateHandle(testBenchData);
        }
    }
}

[Serializable]
public class TestBenchDataList
{
    public List<TestBenchData> data = new List<TestBenchData>();
}
[Serializable]
/// <summary>
/// 检验台数据类
/// </summary>
public class TestBenchData
{
    /// <summary>
    /// 检验台的ID
    /// </summary>
    public string id;
    /// <summary>
    /// 状态
    /// </summary>
    public string state;
}