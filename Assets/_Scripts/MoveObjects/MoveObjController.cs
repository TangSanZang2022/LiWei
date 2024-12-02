using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 场景中可移动物体控制器
/// </summary>
public class MoveObjController : BaseController
{

    /// <summary>
    /// 存放所有
    /// </summary>
    private Dictionary<string, BaseMoveObject> allMoveObjDict = new Dictionary<string, BaseMoveObject>();

    public MoveObjController(GameFacade facade) : base(facade)
    { }
    public override void OnInit()
    {
        UpdateObjPosRequest updateObjPosRequest = new UpdateObjPosRequest();
    }

    public override void OnUpdate()
    {

    }

    public override void OnDestory()
    {

    }
    /// <summary>
    /// 添加可移动物体到字典
    /// </summary>
    /// <param name="baseMoveObject"></param>
    private void AddMoveObjDic(BaseMoveObject baseMoveObject)
    {
        allMoveObjDict.Add(baseMoveObject.GetID(), baseMoveObject);
    }
    /// <summary>
    /// 根据ID，将物体从字典中移出
    /// </summary>
    /// <param name="id"></param>
    public void RemoveObjInDic(string id)
    {
        allMoveObjDict.Remove(id);
    }

    /// <summary>
    /// 从字典中获取
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool TryGetMoveObj(string id, out BaseMoveObject baseMoveObject)
    {
        bool isFound = false;
        if (allMoveObjDict.TryGetValue(id, out baseMoveObject))
        {
            isFound = true;
        }
        return isFound;
    }
    /// <summary>
    ///  通过String类型数据来更新所有物体位置
    /// </summary>
    /// <param name="data"></param>
    public void UpdateAllMoveObjPosFromStr(string data)
    {
        MoveObjDataList moveObjDatas = XmlController.ReadJson<MoveObjDataList>(data);
        UpdateAllMoveObjPos(moveObjDatas.moveObjDatas);
    }
    /// <summary>
    /// 同步位置的时候，当场景中物体没有获取同步数据的时候就删除
    /// </summary>
    /// <param name="moveObjDatas"></param>

    /// <summary>
    /// 通过所有数据(string类型)来更新可移动物体位置
    /// </summary>
    /// <param name="moveObjDataList"></param>
    private void UpdateAllMoveObjPos(List<MoveObjData> moveObjDataList)
    {
        foreach (MoveObjData moveObjData in moveObjDataList)
        {
            UpdateMoveObjPos(moveObjData);
        }

        facade.ReadPoliceInfos();
    }

    /// <summary>
    /// 设置UI展示信息
    /// </summary>
    /// <param name="baseInfo"></param>
    public void SetBaseInfo(IBaseInfo baseInfo)
    {
        foreach (string id in allMoveObjDict.Keys)
        {
            if (id == baseInfo.ID)
            {
                allMoveObjDict[id].SetBaseInfo(baseInfo);
                break;
            }
        }
    }
    /// <summary>
    /// 通过单个数据来更新特定的物体的位置
    /// </summary>
    /// <param name="moveObjData"></param>
    public void UpdateMoveObjPos(MoveObjData moveObjData)
    {
        BaseMoveObject baseMoveObject;
        Vector3 tragetPos = new Vector3((float)moveObjData.x, (float)moveObjData.y, (float)moveObjData.z);
        if (!TryGetMoveObj(moveObjData.ID, out baseMoveObject)) //无法得到ID对应的物体
        {
            //创建可移动的物体
            baseMoveObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MoveObjs/" + moveObjData.objType), tragetPos, new Quaternion(0, 0, 0, 0)).GetComponent<BaseMoveObject>();
            //baseMoveObject.transform.position = tragetPos;
            baseMoveObject.Init(moveObjData);
            AddMoveObjDic(baseMoveObject);//将此可移动物体添加到字典
        }
        baseMoveObject.UpdateObjSync(tragetPos);
    }

}
