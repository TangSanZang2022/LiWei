using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IndustrialPlatform
{
    /// <summary>
    /// 车位
    /// </summary>
    public class BaseTruckSpace : MonoBehaviour
    {
        [SerializeField]
        /// <summary>
        /// ID
        /// </summary>
        protected string id;
        [SerializeField]
        /// <summary>
        /// 车位名称
        /// </summary>
        protected string truckSpaceName;
        /// <summary>
        /// 进站事件
        /// </summary>
        public UnityAction InAction;
        /// <summary>
        /// 停在站点事件
        /// </summary>
        public UnityAction StayAction;
        /// <summary>
        /// 出站事件
        /// </summary>
        public UnityAction OutAction;
        /// <summary>
        /// 当前在站内的车
        /// </summary>
        private BaseCar currentInStationCar;

        /// <summary>
        /// 空闲时间单位“秒”
        /// </summary>
        //private int freeTimeSecond;
        /// <summary>
        /// 月台空闲数据
        /// </summary>
        protected FreePlatformItemData freePlatformItemData = new FreePlatformItemData();
        // Start is called before the first frame update
        protected void Start()
        {
            Init();
            freePlatformItemData.truckSpaceName = this.truckSpaceName;
            freePlatformItemData.freeTime = 600;
            StartCoroutine(IUpdate_freeTimeSecond());
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {

        }
        private IEnumerator IUpdate_freeTimeSecond()
        {
            //freePlatformItemData.freeTime = 0;
            while (currentInStationCar==null)
            {
                yield return new WaitForSeconds(1);
                freePlatformItemData.freeTime++;

            }
            freePlatformItemData.freeTime = 0;
        }
        /// <summary>
        /// 得到月台空闲数据
        /// </summary>
        /// <returns></returns>
        public FreePlatformItemData Get_freePlatformItemData()
        {
            return freePlatformItemData;
        }
        /// <summary>
        /// 进站
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Car" && currentInStationCar == null)
            {
                currentInStationCar = other.GetComponent<BaseCar>();
                currentInStationCar.Set_BaseTruckSpace(this);
                freePlatformItemData.freeTime = 0;
                StopAllCoroutines();
                if (InAction != null)
                {
                    InAction();
                }

            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Car")
            {
                if (currentInStationCar == null)
                {
                    OnTriggerEnter(other);
                }
                if (currentInStationCar == other.GetComponent<BaseCar>())
                {
                    currentInStationCar.StayInTruckSpace();
                    if (StayAction != null)
                    {
                        StayAction();
                    }
                }

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Car" && currentInStationCar != null)
            {
                if (currentInStationCar == other.GetComponent<BaseCar>())
                {
                    //currentInStationCar.Set_BaseTruckSpace(null);
                    currentInStationCar.OutTruckSpace();
                    currentInStationCar = null;
                    StartCoroutine(IUpdate_freeTimeSecond());
                }
                if (OutAction != null)
                {
                    OutAction();
                }
            }
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
        /// 获取名字
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return truckSpaceName;
        }
        /// <summary>
        /// 获取当前站点的车
        /// </summary>
        /// <returns></returns>
        public BaseCar Get_currentInStationCar()
        {
            return currentInStationCar;
        }
    }
}
