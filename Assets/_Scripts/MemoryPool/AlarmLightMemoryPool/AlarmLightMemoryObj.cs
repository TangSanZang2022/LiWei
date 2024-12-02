using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 挂载在警报灯上，删除时存入内存池
/// </summary>
public class AlarmLightMemoryObj : BaseMemoryObj
{
    /// <summary>
    /// 需要旋转的警灯
    /// </summary>
    Transform spotLight;
    private void Start()
    {
        spotLight = transform.Find("Spot Light");
    }
    private void Update()
    {
        spotLight.Rotate(Vector3.right, 10,Space.Self);//警报灯旋转
    }
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="obj"></param>
    protected override void Init(object[] obj = null)
    {
      
    }
    /// <summary>
    /// 放入内存池
    /// </summary>
    public override void InPool()
    {
        base.InPool();
    }
    /// <summary>
    /// 出内存池
    /// </summary>
    /// <param name="obj"></param>
    public override void OutPool(object[] obj = null)
    {
        base.OutPool(obj);

    }
}
