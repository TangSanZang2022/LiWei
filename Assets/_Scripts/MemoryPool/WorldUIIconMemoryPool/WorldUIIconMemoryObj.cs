using IntroductionIcon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 世界UIicon，可以存放到内存池
/// </summary>
public class WorldUIIconMemoryObj : BaseMemoryObj
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="obj"></param>
    protected override void Init(object[] obj = null)
    {
        base.Init(obj);
        GetComponent<WorldUIIcon>().UpdateNameText((string)obj[0]);
        transform.parent = (Transform)obj[1];
        transform.localPosition = Vector3.zero;
    }
    /// <summary>
    /// 从内存池拿出物体
    /// </summary>
    /// <param name="obj"></param>
    public override void OutPool(object[] obj = null)
    {
        base.OutPool(obj);
    }
     /// <summary>
     /// 将物体放入内存池
     /// </summary>
    public override void InPool()
    {
        base.InPool();
    }
}
