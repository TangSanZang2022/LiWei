using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndustrialPlatform
{
    /// <summary>
    /// 站点
    /// </summary>
    public class TruckSpace : BaseTruckSpace
    {
        [SerializeField]
        private TruckWorldUIIconData truckWorldUIIconData;

        private TruckWorldUIIcon _truckWorldUIIcon;
    /// <summary>
    /// 数据Icon
    /// </summary>
        public TruckWorldUIIcon truckWorldUIIcon
        {
            get
            {
                if (_truckWorldUIIcon == null)
                {
                    _truckWorldUIIcon = transform.GetComponentInChildren<TruckWorldUIIcon>();
                }
                return _truckWorldUIIcon;
            }
        }
       

       protected void Start()
        {
            base.Start();
        }
        private void Awake()
        {
            InAction += InTruckSpace;
            StayAction += StayTruckSpace;
            OutAction += OutTruckSpace;
        }
        private void InTruckSpace()
        {
            GameFacade.Instance.Update_CarNum();
            truckWorldUIIcon.gameObject.SetActive(true);
            truckWorldUIIconData.carNum = Get_currentInStationCar().Get_carNum();//车牌
            truckWorldUIIconData.installedVehicleNum++;
            truckWorldUIIconData.goodsNum = 0;
            truckWorldUIIcon.SetIconData(truckWorldUIIconData);
            StartCoroutine("IAdd_goodsNum");

        }
        private void StayTruckSpace()
        {
            //throw new NotImplementedException();

        }
        private void OutTruckSpace()
        {
            GameFacade.Instance.Update_CarNum();
            truckWorldUIIcon.gameObject.SetActive(false);
            StopCoroutine("IAdd_goodsNum");
        }

        IEnumerator IAdd_goodsNum()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                truckWorldUIIconData.goodsNum+=2;
                truckWorldUIIcon.SetIconData(truckWorldUIIconData);
            }
        }



      

        public override void Init()
        {
            base.Init();
           
            truckWorldUIIcon.gameObject.SetActive(false);
        }
    }
}
