using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// 旅客内存池
 /// </summary>
public class PassengerMemoryPool : BaseMemoryPool
{

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="memoryName"></param>
    /// <param name="poolType"></param>
    public PassengerMemoryPool(string memoryName, MemoryPoolType poolType) : base(memoryName, poolType)
    { }
    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();
    }
}
