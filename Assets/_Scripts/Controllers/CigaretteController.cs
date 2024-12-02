using MoveObjTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UVAin;

namespace Cigarette
{
    /// <summary>
    /// 香烟控制器
    /// </summary>
    public class CigaretteController : BaseController
    {
        //private int stopNum = 0;
        /// <summary>
        /// 香烟创建的时候父物体
        /// </summary>
        Transform cigaretteStartPoint;

       // private bool cigaretteState;
        public CigaretteController(GameFacade gameFacade) : base(gameFacade)
        {

        }
        /// <summary>
        /// 存放所有香烟的字典
        /// </summary>
       // private Dictionary<string, BaseCigarette> allBaseCigaretteDict = new Dictionary<string, BaseCigarette>();
        /// <summary>
        /// 存放香烟的列表
        /// </summary>
        private List<BaseCigarette> allBaseCigaretteList = new List<BaseCigarette>();
        /// <summary>
        /// 皮带UV动画的物体
        /// </summary>
        private List<BaseUVAniObj> allBaseUVAniObjList = new List<BaseUVAniObj>();
      


        public override void OnInit()
        {
            cigaretteStartPoint = GameObject.Find("CigaretteStartPoint").transform;
            SetAllBaseUVAniObjList();
            SetAllBaseCigaretteList();
           //Set_machineLight();
            //PlayAllCigaretteMove();
           
        }
       
        /// <summary>
        /// 设置所有UV动画的物体
        /// </summary>
        public void SetAllBaseUVAniObjList()
        {
            BaseUVAniObj[] baseUVAniObj = GameObject.FindObjectsOfType<BaseUVAniObj>();
            allBaseUVAniObjList.AddRange(baseUVAniObj);
        }
        public void SetAllBaseCigaretteList()
        {
            BaseCigarette[] baseEquipments = GameObject.FindObjectsOfType<BaseCigarette>();
            allBaseCigaretteList.AddRange(baseEquipments);
            //foreach (BaseCigarette item in baseEquipments)
            //{
            //    if (!allBaseCigaretteDict.ContainsKey(item.GetID()))
            //    {
            //        allBaseCigaretteDict.Add(item.GetID(), item);
            //    }
            //    else
            //    {
            //        Debug.LogError(string.Format("allEquipmentDict中已经存在Key为{0}的键", item.GetID()));
            //    }
            //}
        }
        /// <summary>
        /// 将设备添加到字典中
        /// </summary>
        /// <param name="baseCigarette"></param>
        public void AddBaseCigarette(BaseCigarette baseCigarette)
        {
            
            //if (!allBaseCigaretteDict.ContainsKey(baseCigarette.GetID()))
            //{
            //    allBaseCigaretteDict.Add(baseCigarette.GetID(), baseCigarette);
            //}
            //else
            //{
            //    Debug.LogError(string.Format("allBaseCigaretteDict中已经存在Key为{0}的键", baseCigarette.GetID()));
            //}
            allBaseCigaretteList.Add(baseCigarette);
        }
        /// <summary>
        /// 根据ID查找香烟
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseCigarette GetBaseCigaretteForID(string id)
        {
            BaseCigarette baseCigarette=null;
            //if (!allBaseCigaretteDict.TryGetValue(id, out baseCigarette))
            //{
            //    Debug.LogError(string.Format("allEquipmentDict中不经存在Key为{0}的键", id));
            //}

            foreach (var item in allBaseCigaretteList)
            {
                if (item.GetID()==id)
                {
                    baseCigarette = item;
                    break;
                }
            }
            return baseCigarette;
        }
        /// <summary>
        /// 从字典中移除对应ID的香烟
        /// </summary>
        /// <param name="id"></param>
        public void RemoveBaseCigaretteForID(string id)
        {
            for (int i = 0; i < allBaseCigaretteList.Count; i++)
            {
                int index = i;
                if (allBaseCigaretteList[index].GetID()==id)
                {
                    allBaseCigaretteList.Remove(allBaseCigaretteList[index]);
                }
            }
        }
        /// <summary>
        /// 从字典中移除对应香烟
        /// </summary>
        /// <param name="id"></param>
        public void RemoveBaseCigarette(BaseCigarette baseCigarette)
        {
            allBaseCigaretteList.Remove(baseCigarette);
        }
        /// <summary>
        /// 根据设备ID，前往该香烟的最佳视角位置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moveTrans"></param>
        public void GoToCigaretteBestViewPosForID(string id, Transform moveTrans)
        {
            //if (currentBestViewEquipment != null)
            //{
            //    currentBestViewEquipment.isAtBestViewPos = false;
            //}
            //BaseEquipment baseEquipment = GetBaseEquipmentForID(id);
            //baseEquipment.GoToBestViewPos(moveTrans);
            //currentBestViewEquipment = baseEquipment;
            //facade.Set_isRotAroundTarget(true);
            //facade.Set_canRot(true);
            //facade.Set_rotTarget(baseEquipment.transform.position);
            //facade.Set_lock_rotTarget(true);
            //facade.Set_canZoom(true);
            //facade.Set_moveForZoom(false);
        }
        /// <summary>
        /// 重置所有isAtBestViewPos
        /// </summary>
        public void ResetAll_isAtBestViewPos()
        {
            //foreach (BaseEquipment item in allBaseCigaretteDict.Values)
            //{
            //    if (item.isAtBestViewPos)
            //    {
            //        item.isAtBestViewPos = false;
            //    }
            //}
            //facade.Set_isRotAroundTarget(true);
            //facade.Set_canRot(true);
            //facade.Set_lock_rotTarget(false);
            //facade.Set_canZoom(false);
            //facade.Set_moveForZoom(true);
        }
       
       
        /// <summary>
        /// 暂停所有香烟的移动
        /// </summary>
        public void PauseAllCigaretteMove()
        {
            foreach (var item in allBaseCigaretteList)
            {
                item.GetComponent<BaseMoveObj>().PauseMove();
            }
            foreach (var item in allBaseUVAniObjList)
            {
                item.PauseUVAni();
            }
           // machineLight.GetComponent<IUpdateHandle>().UpdateHandle("shutdown");
            //if (cigaretteState)
            //{
            //    stopNum++;
            //    LaserCodingMachine laserCodingMachine = facade.GetBaseEquipmentForID("LaserCodingMachine").GetComponent<LaserCodingMachine>();
            //    LaserBase laserCodingMachineData = laserCodingMachine.Get_LaserCodingMachineData();
            //    laserCodingMachineData.hangUpCount = stopNum.ToString();
            //    laserCodingMachineData.StateText = "停机";
            //    laserCodingMachine.Set_LaserCodingMachineData(laserCodingMachineData);
            //    cigaretteState = false; 
            //}
        }
        /// <summary>
        /// 暂停所有香烟的移动
        /// </summary>
        public void PlayAllCigaretteMove()
        {
            foreach (var item in allBaseCigaretteList)
            {
                item.GetComponent<BaseMoveObj>().PlayMove();
            }
            foreach (var item in allBaseUVAniObjList)
            {
                item.PlayUVAni();
            }
            //if (!cigaretteState)
            //{
            //    machineLight.GetComponent<IUpdateHandle>().UpdateHandle("run");
            //    LaserCodingMachine laserCodingMachine = facade.GetBaseEquipmentForID("LaserCodingMachine").GetComponent<LaserCodingMachine>();
            //    LaserBase laserCodingMachineData = laserCodingMachine.Get_LaserCodingMachineData();
            //    //laserCodingMachineData.StateText = "运行";
            //    laserCodingMachine.Set_LaserCodingMachineData(laserCodingMachineData);
            //    cigaretteState = true; 
            //}
        }
        /// <summary>
        /// 随机创建香烟
        /// </summary>
        public void CreateBaseCigarette()
        {
            int index = Random.Range(1, 9);

            //BaseCigarette baseCigarette = GameObject.Instantiate<BaseCigarette>(Resources.Load<BaseCigarette>("CigarettePrefabs/Cigarette" + index), cigaretteStartPoint);
            BaseCigarette baseCigarette = facade.GetObjForObjTypeInPool(MemoryPoolObjType.Cigarette, index.ToString()).GetComponent<BaseCigarette>();
            baseCigarette.GetComponent<CigaretteMemoryObj>().OutPool(new object[] { cigaretteStartPoint });
            //Debug.Log(baseCigarette.name);
            AddBaseCigarette(baseCigarette);
           // baseCigarette.transform.localPosition = Vector3.zero;
            BaseMoveObj baseMoveObj = baseCigarette.GetComponent<BaseMoveObj>();
            baseMoveObj.OnInit();
            baseMoveObj.PlayMove();

        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //PauseAllCigaretteMove();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                //PlayAllCigaretteMove();
            }
        }
        public override void OnDestory()
        {

        }

        
    }
}
