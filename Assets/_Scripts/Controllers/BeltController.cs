using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltController : BaseController
{
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="gameFacade"></param>
    public BeltController(GameFacade gameFacade) : base(gameFacade) { }

    /// <summary>
    /// 存放所有皮带的字典
    /// </summary>
    private Dictionary<string, BaseBelt> allBeltDic = new Dictionary<string, BaseBelt>();

    public override void OnInit()
    {
        base.OnInit();
        UpdateBeltRequest updateBeltRequest =new UpdateBeltRequest();
        SetAllBeltDic();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    /// <summary>
    /// 从场景中得到Belt给 allBeltDic赋值
    /// </summary>
    private void SetAllBeltDic()
    {
        allBeltDic.Clear();
        BaseBelt[] belts = GameObject.FindObjectsOfType<BaseBelt>();
        foreach (BaseBelt b in belts)
        {
            allBeltDic.Add(b.GetID(), b);
        }
    }


    public override void OnDestory()
    {
        base.OnDestory();
    }

    /// <summary>
    /// 通过ID得到皮带
    /// </summary>
    /// <param name="materialName"></param>
    /// <returns></returns>
    public BaseBelt GetBeltForID(string beltID)
    {
        BaseBelt b;
        if (!allBeltDic.TryGetValue(beltID, out b))
        {
            Debug.LogError(string.Format("找不到对应ID：{0}的皮带", beltID));
        }
        return b;
    }

    /// <summary>
    /// 根据数据
    /// </summary>
    /// <param name="data"></param>
    public void UpdateAllBelt(string data)
    {
        //TODO这里要将传入的data转换为 List<BeltData>；
        BeltDataList beltDataList = JsonUtility.FromJson<BeltDataList>(data);
        List<BeltData> beltDatas = beltDataList.StateInfos;
        foreach (BeltData BD in beltDatas)
        {
            //GetBeltForID(BD.ID).UpdateObjSync(BD);
            GetBeltForID(BD.ID).UpdateObj(BD);
        }
    }
}
