using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
/// <summary>
/// X光机
/// </summary>
public class XRayMachine : BaseBelt   
{
    /// <summary>
    /// 装子物体的容器
    /// </summary>
    private List<IUpdateHandle> childRodList = new List<IUpdateHandle>();
   
    protected override void OnInit()
    {
        childRodList.AddRange(transform.GetComponentsExceptParentAndChildedChild<IUpdateHandle>());
    }

    /// <summary>
    /// 更新状态
    /// </summary>
    /// <param name="data"></param>
    public override void UpdateObj(object data)
    {
        BeltData beltData = data as BeltData;
        foreach (IUpdateHandle item in childRodList)
        {
            item.UpdateHandle(beltData);

        }
    }
    /// <summary>
    /// 还原为原状
    /// </summary>
    public override void Reduction()
    {
        foreach (IUpdateHandle item in childRodList)
        {
            item.ReductionNormalState();
        }
    }
}
