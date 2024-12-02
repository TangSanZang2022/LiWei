using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 警报灯内存池
/// </summary>
public class AlarmLightMemoryPool : BaseMemoryPool
{
    public AlarmLightMemoryPool(string memoryName, MemoryPoolType poolType) : base(memoryName, poolType)
    { }
    public override void Init()
    {
        base.Init();
    }
}
