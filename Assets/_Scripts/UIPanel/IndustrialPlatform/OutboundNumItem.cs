using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

namespace IndustrialPlatform
{
    /// <summary>
    /// 已出库件数
    /// </summary>
    public class OutboundNumItem : MonoBehaviour
    {
        [SerializeField]
        /// <summary>
        /// 数量图片Top1-4
        /// </summary>
        private Sprite[] sprites;

        private Text nameText;
        /// <summary>
        /// 名称
        /// </summary>
        private Text NameText
        {
            get
            {
                if (nameText == null)
                {
                    nameText = transform.FindChildForName("NameText").GetComponent<Text>();
                }
                return nameText;
            }
        }
        private Text numText;
        /// <summary>
        ///数量
        /// </summary>
        private Text NumText
        {
            get
            {
                if (numText == null)
                {
                    numText = transform.FindChildForName("NumText").GetComponent<Text>();
                }
                return numText;
            }
        }
        private Slider numSlider;
        /// <summary>
        ///数量滑块
        /// </summary>
        private Slider NumSlider
        {
            get
            {
                if (numSlider == null)
                {
                    numSlider = transform.FindChildForName("NumSlider").GetComponent<Slider>();
                }
                return numSlider;
            }
        }
        private Image fill;
        /// <summary>
        ///数量滑块填充图片
        /// </summary>
        private Image Fill
        {
            get
            {
                if (fill == null)
                {
                    fill = transform.FindChildForName("Fill").GetComponent<Image>();
                }
                return fill;
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
        /// <param name="outboundNumItemData"></param>
        public void SetData(OutboundNumItemData outboundNumItemData)
        {
            NameText.text = outboundNumItemData.name;
            NumText.text = outboundNumItemData.num.ToString()+"(件)";
            float f = (float)outboundNumItemData.num / 10000.0f;
            NumSlider.DOValue(f, 1);
           
        }


        /// <summary>
        /// 设置滑块填充图片
        /// </summary>
        /// <param name="index"></param>
        public void SetImage(int index)
        {
            if (index<=3)
            {
                Fill.sprite = sprites[index];
            }
            else
            {
                Fill.sprite = sprites[3];
            }
        }
    }
    [Serializable]
    /// <summary>
    ///已出库数据
    /// </summary>
    public class OutboundNumItemData
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string name;


        /// <summary>
        /// 数量
        /// </summary>
        public int num;

       
    }
}
