using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
/// <summary>
/// 杆子状的传送带
/// </summary>
public class RodBelt : BaseBelt
{
    /// <summary>
    /// 装子物体的容器
    /// </summary>
    private List<IUpdateHandle> childRodList = new List<IUpdateHandle>();
    protected override void OnInit()
    {
        childRodList.AddRange(transform.GetComponentsExceptParentAndChildedChild<IUpdateHandle>());
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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
        if (beltData.IsAlarm == 0)//正常
        {
            //GetComponent<BaseAlarmObj>().Alarming();
            //Debug.Log(string.Format("报警："));

            GetComponent<BaseAlarmObj>().BackToOriginalState();


        }
        else //异常
        {
            GetComponent<BaseAlarmObj>().Alarming();
            Debug.Log("报警");
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
