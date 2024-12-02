using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 乘客
/// </summary>
public class Passenger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    /// <summary>
    /// 隐藏方法
    /// </summary>
    public void Hide()
    {
        //TODO 放入内存池
        GetComponent<PassengerMemoryObj>().InPool();
    }

}
[Serializable]
/// <summary>
/// 旅客信息列表
/// </summary>
public class PassengerDataList
{
    public List<PassengerData> passengerDatas = new List<PassengerData>();
}
[Serializable]
/// <summary>
/// 旅客信息
/// </summary>
public class PassengerData
{
    /// <summary>
    /// 游客的区域
    /// </summary>
    public string area;
    /// <summary>
    /// 性别
    /// </summary>
    public string sex;
    /// <summary>
    /// 籍贯
    /// </summary>
    public string birthPlace;
    /// <summary>
    /// 数量
    /// </summary>
    public string num;
}
