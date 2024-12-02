using DFDJ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Cigarette
{
    public class CigaretteWorldUIIcon : BaseWorldUIIcon
    {
        [SerializeField]
        private CigaretteWorldUIIconData cigaretteWorldUIIconData;

        private Text nameText;
        /// <summary>
        /// 设备名称
        /// </summary>
        private Text NameText
        {
            get
            {
                if (nameText==null)
                {
                    nameText = transform.FindChildForName("NameText").GetComponent<Text>();
                }
                return nameText;
            }
        }

        private Text startTimeText;
        /// <summary>
        /// 开机时间
        /// </summary>
        private Text StartTimeText
        {
            get
            {
                if (startTimeText == null)
                {
                    startTimeText = transform.FindChildForName("StartTimeText").GetComponent<Text>();
                }
                return startTimeText;
            }
        }

        private Text runTimeText;
        /// <summary>
        /// 运行时长
        /// </summary>
        private Text RunTimeText
        {
            get
            {
                if (runTimeText == null)
                {
                    runTimeText = transform.FindChildForName("RunTimeText").GetComponent<Text>();
                }
                return runTimeText;
            }
        }
        private Text efficiencyText;
        /// <summary>
        /// 分拣效率
        /// </summary>
        private Text EfficiencyText
        {
            get
            {
                if (efficiencyText == null)
                {
                    efficiencyText = transform.FindChildForName("EfficiencyText").GetComponent<Text>();
                }
                return efficiencyText;
            }
        }
        private Text scheduleText;
        /// <summary>
        /// 分拣进度
        /// </summary>
        private Text ScheduleText
        {
            get
            {
                if (scheduleText == null)
                {
                    scheduleText = transform.FindChildForName("ScheduleText").GetComponent<Text>();
                }
                return scheduleText;
            }
        }
        private Text stopNumText;
        /// <summary>
        /// 停机次数
        /// </summary>
        private Text StopNumText
        {
            get
            {
                if (stopNumText == null)
                {
                    stopNumText = transform.FindChildForName("StopNumText").GetComponent<Text>();
                }
                return stopNumText;
            }
        }
        private Text stateText;
        /// <summary>
        /// 运行状态
        /// </summary>
        private Text StateText
        {
            get
            {
                if (stateText == null)
                {
                    stateText = transform.FindChildForName("StateText").GetComponent<Text>();
                }
                return stateText;
            }
        }

        private void OnEnable()
        {
            SetIconData(cigaretteWorldUIIconData);
        }
        public override void SetIconData(object data)
        {
            base.SetIconData(data);
            CigaretteWorldUIIconData laserCodingMachineData_New = data as CigaretteWorldUIIconData;
            this.cigaretteWorldUIIconData = laserCodingMachineData_New;
            NameText.text = cigaretteWorldUIIconData.name;
            StartTimeText.text = cigaretteWorldUIIconData.startUpTime;
            RunTimeText.text = cigaretteWorldUIIconData.onlineTime;
            EfficiencyText.text = cigaretteWorldUIIconData.separateEfficiency;
            ScheduleText.text = cigaretteWorldUIIconData.separateProgress;
            StopNumText.text = cigaretteWorldUIIconData.hangUpCount;
            StateText.text = cigaretteWorldUIIconData.stateText;
        }
    }
}
/// <summary>
/// 烟草激光打码机世界UI数据
/// </summary>
[Serializable]
public class CigaretteWorldUIIconData
{
    /// <summary>
    /// 设备名称
    /// </summary>
    public string name;

    /// <summary>
    /// 开机时间
    /// </summary>
    public string startUpTime;

    /// <summary>
    /// 运行时长
    /// </summary>
    public string onlineTime;

    /// <summary>
    /// 分拣效率
    /// </summary>
    public string separateEfficiency;

    /// <summary>
    /// 分拣进度
    /// </summary>
    public string separateProgress;

    /// <summary>
    /// 停机次数
    /// </summary>
    public string hangUpCount;
    /// <summary>
    /// 状态
    /// </summary>
    public string stateText;
}
