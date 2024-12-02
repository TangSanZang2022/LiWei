using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// 报警详情UI内存池
 /// </summary>
public class AlarmUIMemoryPool : BaseMemoryPool
{
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="memoryName"></param>
    /// <param name="poolType"></param>
    public AlarmUIMemoryPool(string memoryName, MemoryPoolType poolType) : base(memoryName, poolType)
    { }
}
