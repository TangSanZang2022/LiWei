using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace IndustrialPlatform
{
    /// <summary>
    /// 车辆实时播报
    /// </summary>
    public class RealTimeCarItem : MonoBehaviour
    {
        private Text platformNumText;
        /// <summary>
        /// 月台名称
        /// </summary>
        private Text PlatformNumText
        {
            get
            {
                if (platformNumText==null)
                {
                    platformNumText = transform.FindChildForName("PlatformNumText").GetComponent<Text>();
                }
                return platformNumText;
            }
        }
        private Text carNumText;
        /// <summary>
        /// 车牌
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
        private Text inTimeText;
        /// <summary>
        /// 驶入时间
        /// </summary>
        private Text InTimeText
        {
            get
            {
                if (inTimeText == null)
                {
                    inTimeText = transform.FindChildForName("InTimeText").GetComponent<Text>();
                }
                return inTimeText;
            }
        }
        private Text outTimeText;
        /// <summary>
        /// 驶出时间
        /// </summary>
        private Text OutTimeText
        {
            get
            {
                if (outTimeText == null)
                {
                    outTimeText = transform.FindChildForName("OutTimeText").GetComponent<Text>();
                }
                return outTimeText;
            }
        }
        private Text stayTimeText;
        /// <summary>
        /// 停留时间
        /// </summary>
        private Text StayTimeText
        {
            get
            {
                if (stayTimeText == null)
                {
                    stayTimeText = transform.FindChildForName("StayTimeText").GetComponent<Text>();
                }
                return stayTimeText;
            }
        }

        public Color c1;
        public Color c2;
        // Start is called before the first frame update
        void Start()
        {
            
        }
        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="realTimeCarItemData"></param>
        public void SetData(RealTimeCarItemData realTimeCarItemData)
        {
            PlatformNumText.text = realTimeCarItemData.truckSpaceName;
            CarNumText.text = realTimeCarItemData.carNum;
            InTimeText.text = realTimeCarItemData.inTime;
            OutTimeText.text = realTimeCarItemData.outTime;
            StayTimeText.text = realTimeCarItemData.stayTime;
        }
        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="index"></param>
        public void SetColor(int index)
        {
            if (index%2==0)//第偶数个
            {
                GetComponent<Image>().color = c1;
            }
            else
            {
                GetComponent<Image>().color = c2;
            }
        }
    }
    [Serializable]
    /// <summary>
    /// 车辆实时播报数据
    /// </summary>
    public class RealTimeCarItemData
    {
        /// <summary>
        /// 月台名称
        /// </summary>
        public string truckSpaceName;

        /// <summary>
        /// 车牌
        /// </summary>
        public string carNum;

        /// <summary>
        /// 驶入时间
        /// </summary>
        public string inTime;

        /// <summary>
        /// 驶出时间
        /// </summary>
        public string outTime;
        /// <summary>
        /// 停留时间
        /// </summary>
        public string stayTime;
    }
}
