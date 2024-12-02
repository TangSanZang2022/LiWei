using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndustrialPlatform
{
    /// <summary>
    /// 月台控制器
    /// </summary>
    public class TruckSpaceController : BaseController
    {
        public TruckSpaceController(GameFacade gameFacade) : base(gameFacade)
        {

        }
        /// <summary>
        /// 所有月台
        /// </summary>
        private Dictionary<string, BaseTruckSpace> allBaseTruckSpaces = new Dictionary<string, BaseTruckSpace>();
        /// <summary>
        /// 初始化站点
        /// </summary>
        private void Init_allBaseTruckSpaces()
        {
            BaseTruckSpace[] baseTruckSpaces = GameObject.FindObjectsOfType<BaseTruckSpace>();
            for (int i = 0; i < baseTruckSpaces.Length; i++)
            {
                int index = i;
                allBaseTruckSpaces.Add(baseTruckSpaces[index].GetID(), baseTruckSpaces[index]);
            }
        }
        public override void OnInit()
        {
            base.OnInit();
            Init_allBaseTruckSpaces();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
        /// <summary>
        /// 获取月台数据
        /// </summary>
        /// <returns></returns>
        public int[] Get_TruckSpaceNum()
        {
            int[] res = new int[2] { 0,0};
            foreach (BaseTruckSpace item in allBaseTruckSpaces.Values)
            {
                if (item.Get_currentInStationCar()!=null)//有车
                {
                    res[0]++;
                }
                else
                {
                    res[1]++;
                }
            }
            return res;
        }

        /// <summary>
        /// 得到所有月台空闲时间数据
        /// </summary>
        /// <returns></returns>
        public List<FreePlatformItemData> GetFreePlatformItemDatas()
        {
            List<FreePlatformItemData> freePlatformItemDatas = new List<FreePlatformItemData>();
            foreach (var item in allBaseTruckSpaces.Values)
            {
              
                    freePlatformItemDatas.Add(item.Get_freePlatformItemData());
                

            }
            return freePlatformItemDatas;
        }
        public override void OnDestory()
        {
            base.OnDestory();
        }


    }
}
