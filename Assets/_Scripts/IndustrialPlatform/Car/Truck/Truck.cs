using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
namespace IndustrialPlatform
{
    /// <summary>
    /// 卡车
    /// </summary>
    public class Truck : BaseCar
    {
        /// <summary>
        /// 数据Icon
        /// </summary>
        //public TruckWorldUIIcon truckWorldUIIcon;
      

        float timeSecond;

        // Start is called before the first frame update
        void Start()
        {
            //if (truckWorldUIIcon==null)
            //{
            //    truckWorldUIIcon = transform.GetComponentInChildren<TruckWorldUIIcon>();
            //}
            //truckWorldUIIcon.gameObject.SetActive(false);
           
        }
        public override void InTruckSpace()
        {
            base.InTruckSpace();
            //truckWorldUIIcon.gameObject.SetActive(true);

            realTimeCarItemData.inTime = TimeTool.GetNowTime("HH:MM:ss");
            realTimeCarItemData.truckSpaceName = Get_baseTruckSpace().GetName();
            timeSecond = 0;
            realTimeCarItemData.carNum = Get_carNum();
        }

        public override void OutTruckSpace()
        {
            base.OutTruckSpace();
            //truckWorldUIIcon.gameObject.SetActive(false);
            realTimeCarItemData.outTime = TimeTool.GetNowTime("HH:MM:ss");
            realTimeCarItemData.stayTime = TimeTool.GetTimeString_Second((int)timeSecond);
            
        }

        public override void StayInTruckSpace()
        {
            base.StayInTruckSpace();
            timeSecond += Time.deltaTime;

            realTimeCarItemData.stayTime = TimeTool.GetTimeString_Second((int)timeSecond);
        }
    }
   
}

