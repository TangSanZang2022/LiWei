using DFDJ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
namespace IndustrialPlatform
{
    /// <summary>
    /// 月台世界UIIcon
    /// </summary>
    public class TruckWorldUIIcon : BaseWorldUIIcon
    {
        //[SerializeField]
        private TruckWorldUIIconData truckWorldUIIconData;
        private Text numText;
        /// <summary>
        /// 月台ID
        /// </summary>
        private Text NumText
        {
            get
            {
                if (numText==null)
                {
                    numText = transform.FindChildForName("NumText").GetComponent<Text>();
                }
                return numText;
            }
        }
        private Text installedVehicleNumText;
        /// <summary>
        /// 已装载车辆数
        /// </summary>
        private Text InstalledVehicleNumText
        {
            get
            {
                if (installedVehicleNumText == null)
                {
                    installedVehicleNumText = transform.FindChildForName("InstalledVehicleNumText").GetComponent<Text>();
                }
                return installedVehicleNumText;
            }
        }
        private Text carNumText;
        /// <summary>
        /// 当前在月台内的车牌
        /// </summary>
        private Text CarNumText
        {
            get
            {
                if (carNumText == null)
                {
                    carNumText = transform.FindChildForName("CarNumText").GetComponent<Text>();
                }
                return carNumText;
            }
        }
        private Text goodsNumText;
        /// <summary>
        /// 货物的件数
        /// </summary>
        private Text GoodsNumText
        {
            get
            {
                if (goodsNumText == null)
                {
                    goodsNumText = transform.FindChildForName("GoodsNumText").GetComponent<Text>();
                }
                return goodsNumText;
            }
        }
       
        private void OnEnable()
        {
           // SetIconData(truckWorldUIIconData);
        }
        public override void SetIconData(object data)
        {
            base.SetIconData(data);
            TruckWorldUIIconData truckWorldUIIconData_New = data as TruckWorldUIIconData;
            this.truckWorldUIIconData = truckWorldUIIconData_New;
            NumText.text = truckWorldUIIconData.num;
            InstalledVehicleNumText.text ="已装载"+ truckWorldUIIconData.installedVehicleNum.ToString()+"辆";
            CarNumText.text = truckWorldUIIconData.carNum;
            GoodsNumText.text = truckWorldUIIconData.goodsNum.ToString()+"件";
            //NameText.text = truckWorldUIIconData.name;
            //StartTimeText.text = truckWorldUIIconData.startUpTime;
            //RunTimeText.text = truckWorldUIIconData.onlineTime;
            //EfficiencyText.text = truckWorldUIIconData.separateEfficiency;
            //ScheduleText.text = truckWorldUIIconData.separateProgress;
            //StopNumText.text = truckWorldUIIconData.hangUpCount;
            //StateText.text = truckWorldUIIconData.stateText;
        }
    }
    /// <summary>
    /// 汽车进入月台之后展示UI的数据
    /// </summary>
    [Serializable]
    public class TruckWorldUIIconData
    {
        /// <summary>
        /// 月台ID
        /// </summary>
        public string num;
        /// <summary>
        /// 已装载车辆数
        /// </summary>
        public int installedVehicleNum;
        /// <summary>
        /// 当前在月台内的车牌
        /// </summary>
        public string carNum;
        /// <summary>
        /// 货物的件数
        /// </summary>
        public int goodsNum;

    }
}
