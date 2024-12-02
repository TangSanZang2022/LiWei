using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using Tool;
namespace IndustrialPlatform
{
    /// <summary>
    /// 空闲月台
    /// </summary>
    public class FreePlatformItem : MonoBehaviour
    {
        private Text platformNumText;
        /// <summary>
        /// 月台名称
        /// </summary>
        private Text PlatformNumText
        {
            get
            {
                if (platformNumText == null)
                {
                    platformNumText = transform.FindChildForName("PlatformNumText").GetComponent<Text>();
                }
                return platformNumText;
            }
        }
        private Image freeTimeImage;
        /// <summary>
        /// 空闲时间Image
        /// </summary>
        private Image FreeTimeImage
        {
            get
            {
                if (freeTimeImage == null)
                {
                    freeTimeImage = transform.FindChildForName("FreeTimeImage").GetComponent<Image>();
                }
                return freeTimeImage;
            }
        }
        private Text freeTimeText;
        /// <summary>
        /// 空闲时间Text
        /// </summary>
        private Text FreeTimeText
        {
            get
            {
                if (freeTimeText == null)
                {
                    freeTimeText = transform.FindChildForName("FreeTimeText").GetComponent<Text>();
                }
                return freeTimeText;
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
        /// <param name="freePlatformItemData"></param>
        public void SetData(FreePlatformItemData freePlatformItemData)
        {
            PlatformNumText.text = freePlatformItemData.truckSpaceName;
            float f = (float)freePlatformItemData.freeTime / 600;
            //FreeTimeImage.DOFillAmount(f,0);
            FreeTimeImage.fillAmount = f;
            FreeTimeText.text =TimeTool.GetTimeString_Second(freePlatformItemData.freeTime);
        }

       
        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="index"></param>
        public void SetColor(int index)
        {
            if (index % 2 == 0)//第偶数个
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
    public class FreePlatformItemData
    {
        /// <summary>
        /// 月台名称
        /// </summary>
        public string truckSpaceName;

      
        /// <summary>
        /// 空闲时间,秒钟
        /// </summary>
        public int freeTime=86400;

        //public string GetTimeString()
        //{
        //    int hd = stayTime / 60;
        //    //Debug.Log(stayTime+"："+ hd);
        //    string h = hd.ToString() != "0" ? hd.ToString() + "小时" : "";//小时
        //    int md = stayTime % 60;
        //    //Debug.Log(stayTime + "：" + md);
        //    string m = md.ToString() + "分钟";//分钟

        //    return h + m;
        //}
    }
}