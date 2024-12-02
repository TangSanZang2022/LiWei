using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndustrialPlatform
{
    /// <summary>
    /// 车辆控制
    /// </summary>
    public class CarController : BaseController
    {
        public CarController(GameFacade gameFacade) : base(gameFacade)
        { }

        private Dictionary<string, BaseCar> allCarDict = new Dictionary<string, BaseCar>();

        private void GetAllCar()
        {
            BaseCar[] baseCars = GameObject.FindObjectsOfType<BaseCar>();
            foreach (BaseCar item in baseCars)
            {
                allCarDict.Add(item.GetID(), item);
            }
        }
        public override void OnInit()
        {
            base.OnInit();
            GetAllCar();
        }
        /// <summary>
        /// 得到所有车辆实时信息
        /// </summary>
        /// <returns></returns>
        public List<RealTimeCarItemData> GetRealTimeCarItemDatas()
        {
            List<RealTimeCarItemData> realTimeCarItemDatas = new List<RealTimeCarItemData>();
            foreach (var item in allCarDict.Values)
            {
                if (item.Get_baseTruckSpace()!=null)
                {
                    realTimeCarItemDatas.Add(item.Get_realTimeCarItemData());
                }
                
            }
            return realTimeCarItemDatas;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnDestory()
        {
            base.OnDestory();
        }
    }
}
