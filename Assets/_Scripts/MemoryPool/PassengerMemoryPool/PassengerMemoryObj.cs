using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 ///  旅客，可放入内存池
 /// </summary>
public class PassengerMemoryObj : BaseMemoryObj
{
    protected override void Init(object[] obj = null)
    {
        base.Init(obj);
        Vector3 pos = (Vector3)obj[0];
        transform.localPosition = pos;
    }

    public override void InPool()
    {
        base.InPool();
    }

    public override void OutPool(object[] obj = null)
    {
        base.OutPool(obj);
    }
}
