using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Cigarette
{
    /// <summary>
    /// 每一条异常记录
    /// </summary>
    public class AbnormalInformationItem : MonoBehaviour
    {

        private Text orderNumberText;
        /// <summary>
        /// 当单号
        /// </summary>
        private Text OrderNumberText
        {
            get
            {
                if (orderNumberText==null)
                {
                    orderNumberText = transform.FindChildForName("OrderNumberText").GetComponent<Text>();
                }
                return orderNumberText;
            }
        }

        private Text sequenceNumberText;
        /// <summary>
        /// 顺序号
        /// </summary>
        private Text SequenceNumberText
        {
            get
            {
                if (sequenceNumberText == null)
                {
                    sequenceNumberText = transform.FindChildForName("SequenceNumberText").GetComponent<Text>();
                }
                return sequenceNumberText;
            }
        }
        private Text nameText;
        /// <summary>
        /// 客户名称
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
        private Text timeText;
        /// <summary>
        /// 时间
        /// </summary>
        private Text TimeText
        {
            get
            {
                if (timeText == null)
                {
                    timeText = transform.FindChildForName("TimeText").GetComponent<Text>();
                }
                return timeText;
            }
        }
        private Text typeText;
        /// <summary>
        /// 异常类型
        /// </summary>
        private Text TypeText
        {
            get
            {
                if (typeText == null)
                {
                    typeText = transform.FindChildForName("TypeText").GetComponent<Text>();
                }
                return typeText;
            }
        }
        /// <summary>
        /// 设置异常记录信息
        /// </summary>
        /// <param name="abnormalInformationItemData"></param>
        public void SetValue(errorLogs abnormalInformationItemData)
        {
            OrderNumberText.text = abnormalInformationItemData.orderNo;
            SequenceNumberText.text = abnormalInformationItemData.serialNo;
            NameText.text = abnormalInformationItemData.clientName;
            TimeText.text = abnormalInformationItemData.createTime;
            TypeText.text = abnormalInformationItemData.errorType;
        }
    }
}
/// <summary>
/// 异常记录
/// </summary>
[Serializable]
public class errorLogs
{
    /// <summary>
    /// 订单号
    /// </summary>
    public string orderNo;
    /// <summary>
    /// 顺序号
    /// </summary>
    public string serialNo;
    /// <summary>
    /// 客户名称
    /// </summary>
    public string clientName;
    /// <summary>
    /// 时间
    /// </summary>
    public string createTime;
    /// <summary>
    /// 异常类型
    /// </summary>
    public string errorType;
}
