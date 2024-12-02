using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/// <summary>
/// 游客管理器
/// </summary>
public class PassengerController : BaseController
{
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="gameFacade"></param>
    public PassengerController(GameFacade gameFacade) : base(gameFacade)
    { }
    /// <summary>
    /// 存放所有游客列表
    /// </summary>
    private List<Passenger> allPassengerList = new List<Passenger>();

    /// <summary>
    /// 存放所有区域对应游客的列表
    /// </summary>
    private Dictionary<string, List<Passenger>> allPassengerDic = new Dictionary<string, List<Passenger>>();
    /// <summary>
    /// 初始化
    /// </summary>
    public override void OnInit()
    {
        UpdatePassengerRequest updatePassengerRequest = new UpdatePassengerRequest();

    }
    /// <summary>
    /// 更新
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    /// <summary>
    /// 将创建出来的游客存入字典
    /// </summary>
    /// <param name="passenger"></param>
    private void AddAllPassengerList(Passenger passenger)
    {
        if (!allPassengerList.Contains(passenger))
        {
            allPassengerList.Add(passenger);
        }
        else
        {
            Debug.Log(string.Format("allPassengerList中已存在passenger：{0}", passenger.name));
        }
    }
    /// <summary>
    /// 将区域添加到字典中
    /// </summary>
    /// <param name="areaStr"></param>
    private void AddKey(string areaStr)
    {
        if (!allPassengerDic.ContainsKey(areaStr))
        {
            allPassengerDic.Add(areaStr, new List<Passenger>());
        }
    }
    /// <summary>
    /// 将对应区域的人员添加到列表中
    /// </summary>
    /// <param name="areaStr"></param>
    /// <param name="passenger"></param>
    private void AddAllPassengerDic(string areaStr, Passenger passenger)
    {
        if (!allPassengerDic[areaStr].Contains(passenger))
        {
            allPassengerDic[areaStr].Add(passenger);
        }
        else
        {
            Debug.Log(string.Format("allPassengerList中已存在passenger：{0}", passenger.name));
        }
    }

    /// <summary>
    /// 根据string数据来更新旅客信息
    /// </summary>
    /// <param name="data"></param>
    public void UpdatePassengersForStr(string data)
    {
        PassengerDataList passengerDatas = JsonUtility.FromJson<PassengerDataList>(data);
        UpdatePassengers(passengerDatas.passengerDatas);
    }
    /// <summary>
    /// 根据旅客信息来
    /// </summary>
    /// <param name="passengerDatas"></param>
    private void UpdatePassengers(List<PassengerData> passengerDatas)
    {
        //这里要分区域
        foreach (PassengerData pd in passengerDatas)
        {
            int newNum = int.Parse(pd.num); //新数据中旅客数量
            string area = pd.area;//区域
            AddKey(area);
            if (newNum < allPassengerDic[area].Count) //当旅客人数减少时
            {
                ReMovePassengerInDic(area, newNum, allPassengerDic[area].Count - newNum);
               // ReMovePassenger(newNum, allPassengerList.Count - newNum);//直接移出即可
            }
            else//当旅客人数大于现在展示的人数时，需要创建旅客
            {
                // int count = allPassengerList.Count;
                int count = allPassengerDic[area].Count;
                for (int i = 0; i < newNum - count; i++)
                {
                    CreatePassenger(area);
                }
            }
        }

    }
    /// <summary>
    /// 在场景中创建游客
    /// </summary>
    private void CreatePassenger(string areaStr)
    {
        Vector3 pos;
        switch (areaStr)
        {
            case "area1":
                pos = new Vector3(Random.Range(-29.0f, -27.5f), 0.5f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area2":
                pos = new Vector3(Random.Range(-34.0f, -32.0f), 0.5f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area3":
                pos = new Vector3(Random.Range(-38.5f, -37.0f), 0.5f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area4":
                pos = new Vector3(Random.Range(-43.5f, -41.5f), 0.5f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area5":  //在此只有5个通道可以排队
                pos = new Vector3(Random.Range(-48.0f, -46.0f), 0.5f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area6":
                pos = new Vector3(Random.Range(-47.0f, -18.0f), 0.57f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area7":
                pos = new Vector3(Random.Range(-47.0f, -18.0f), 0.57f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area8":
                pos = new Vector3(Random.Range(-47.0f, -18.0f), 0.57f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area9":
                pos = new Vector3(Random.Range(-47.0f, -18.0f), 0.57f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            case "area10":
                pos = new Vector3(Random.Range(-47.0f, -18.0f), 0.57f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
            default:
                pos = new Vector3(Random.Range(-47.0f, -18.0f), 0.57f, Random.Range(84.0f, 89.0f));//在场景内获取随机位置
                break;
        }

        PassengerMemoryObj p = (PassengerMemoryObj)facade.GetObjForObjTypeInPool(MemoryPoolObjType.Passenger);
        p.OutPool(new object[] { pos });

        AddAllPassengerList(p.GetComponent<Passenger>());
        //添加到字典，2021.07.2添加
        AddAllPassengerDic(areaStr, p.GetComponent<Passenger>());

    }
    /// <summary>
    /// 将游客从列表中移出
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    private void ReMovePassenger(int index, int count)
    {
        //TODO这里应该先获取需要移出的游客，对游客做放入内存池隐藏惭怍，然后再将游客从列表中移除
        for (int i = 0; i < count; i++)
        {
            allPassengerList[i + index].Hide();
        }
        allPassengerList.RemoveRange(index, count);
    }
     /// <summary>
     /// 从字典中移出游客
     /// </summary>
     /// <param name="area"></param>
     /// <param name="index"></param>
     /// <param name="count"></param>
    private void ReMovePassengerInDic(string area, int index, int count)
    {
        for (int i = 0; i < count; i++)
        {
            allPassengerDic[area][i + index].Hide();
        }
        allPassengerDic[area].RemoveRange(index, count);
    }
    /// <summary>
    /// 删除
    /// </summary>
    public override void OnDestory()
    {
        base.OnDestory();
    }
}
