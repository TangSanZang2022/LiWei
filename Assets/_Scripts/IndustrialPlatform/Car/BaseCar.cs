using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndustrialPlatform
{
    /// <summary>
    /// 汽车
    /// </summary>
    public class BaseCar : MonoBehaviour
    {
        [SerializeField]
        /// <summary>
        /// ID
        /// </summary>
        protected string id;
        [SerializeField]
        /// <summary>
        /// 车牌
        /// </summary>
        protected string carNum;
        /// <summary>
        /// 当前所在站台
        /// </summary>
        private BaseTruckSpace baseTruckSpace;

       
        /// <summary>
        /// 车辆实时播报
        /// </summary>
        protected RealTimeCarItemData realTimeCarItemData = new RealTimeCarItemData();
        // Start is called before the first frame update
        void Start()
        {

        }
        /// <summary>
        /// 设置当前车辆所在的站台
        /// </summary>
        /// <param name="baseTruckSpace"></param>
        public void Set_BaseTruckSpace(BaseTruckSpace baseTruckSpace)
        {
            this.baseTruckSpace = baseTruckSpace;
            if (baseTruckSpace!=null)
            {
                InTruckSpace();
            }
            else
            {
                OutTruckSpace();
            }
        }
        /// <summary>
        /// 得到车辆实时信息
        /// </summary>
        /// <returns></returns>
        public RealTimeCarItemData Get_realTimeCarItemData()
        {
            return realTimeCarItemData;
        }
        /// <summary>
        /// 进站
        /// </summary>
        public virtual void InTruckSpace()
        {

        }
        /// <summary>
        /// 出站
        /// </summary>
        public virtual void OutTruckSpace()
        {

        }
        /// <summary>
        /// 停在站点里面
        /// </summary>
        public virtual void StayInTruckSpace()
        {

        }

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <returns></returns>
        public string GetID()
        {
            return id;
        }
        /// <summary>
        /// 获取车牌
        /// </summary>
        /// <returns></returns>
        public string Get_carNum()
        {
            return carNum;
        }
        /// <summary>
        /// 获取当前车所在车站
        /// </summary>
        /// <returns></returns>
        public BaseTruckSpace Get_baseTruckSpace()
        {
            return baseTruckSpace;
        }
    }
}
