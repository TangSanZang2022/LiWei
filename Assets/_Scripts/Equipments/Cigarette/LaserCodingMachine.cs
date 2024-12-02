using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
using Equipment;
using System;

namespace Cigarette
{
    /// <summary>
    /// 激光打码机
    /// </summary>
    public class LaserCodingMachine : BaseEquipment
    {

        /// <summary>
        /// 激光机信息
        /// </summary>
        [SerializeField]
        private LaserBase laserBase;
        /// <summary>
        /// 信号灯及蜂鸣器状态
        /// </summary>
        [SerializeField]
        private Signal signal;
        /// <summary>
        /// 灯
        /// </summary>
        private MachineLight machineLight;
        private DFDJ. EquipmentWorldIconObj _equipmentWorldIconObj;
        /// <summary>
        /// 设备的世界UI物体
        /// </summary>
        private DFDJ.EquipmentWorldIconObj equipmentWorldIconObj
        {
            get
            {
                if (_equipmentWorldIconObj==null)
                {
                    _equipmentWorldIconObj = GetComponent<DFDJ.EquipmentWorldIconObj>();
                }
                return _equipmentWorldIconObj;
            }
        }
        private GameObject infoUI;
        /// <summary>
        /// 设备信息UI
        /// </summary>
        private GameObject InfoUI
        {
            get
            {
                if (infoUI==null)
                {
                    infoUI = transform.FindChildForName("InfoUI").gameObject;
                }
                return infoUI;
            }
        }
        protected override void Start()
        {
            base.Start();
        }
        protected override void OnInit()
        {
            //laserCodingMachineData.startUpTime = DateTime.Now.ToString("yyyy/MM/dd   HH:MM:ss");//开始时间
            //laserCodingMachineData.hangUpCount ="0";
            base.OnInit();
            Set_machineLight();

            // InfoUI.SetActive(false);
        }

        protected override void MouseDownHandle()
        {
            base.MouseDownHandle();
            InfoUI.SetActive(!InfoUI.activeSelf);
        }
        /// <summary>
        /// 获取激光打印机数据
        /// </summary>
        /// <returns></returns>
        public LaserBase Get_laserBase()
        {
            return laserBase;
        }
        /// <summary>
        /// 获取灯
        /// </summary>
        private void Set_machineLight()
        {
            machineLight = GameObject.FindObjectOfType<MachineLight>();
        }
        /// <summary>
        /// 设置激光打印机数据
        /// </summary>
        /// <param name="laserCodingMachineData_New"></param>
        public void Set_laserBase(LaserBase laserCodingMachineData_New)
        {
            laserBase.name = laserCodingMachineData_New.name;
            laserBase.startUpTime = laserCodingMachineData_New.startUpTime;
            laserBase.onlineTime = laserCodingMachineData_New.onlineTime;
            laserBase.separateEfficiency = laserCodingMachineData_New.separateEfficiency;
            laserBase.separateProgress = laserCodingMachineData_New.separateProgress;
            laserBase.hangUpCount = laserCodingMachineData_New.hangUpCount;
            //equipmentWorldIconObj.SetIconData(laserBase);
        }

        /// <summary>
        /// 获取激光打印机数据
        /// </summary>
        /// <returns></returns>
        public Signal Get_signal()
        {
            return signal;
        }

        /// <summary>
        /// 设置信号灯及蜂鸣器状态
        /// </summary>
        /// <param name="signal_New"></param>
        public void Set_signal(Signal signal_New)
        {
            signal.greenLightState = signal_New.greenLightState;
            signal.yellowLightState = signal_New.yellowLightState;
            signal.redLightState = signal_New.redLightState;
            signal.buzzerState = signal_New.buzzerState;
            signal.running = signal_New.running;

            machineLight.GetComponent<IUpdateHandle>().UpdateHandle(signal);
            if (signal.running)
            {
                GameFacade.Instance.PlayAllCigaretteMove();
            }
            else
            {
                GameFacade.Instance.PauseAllCigaretteMove();
            }

            //equipmentWorldIconObj.SetIconData(laserBase);
        }
        /// <summary>
        /// 设置Ui上的数据
        /// </summary>
        /// <param name="cigaretteWorldUIIconData"></param>
        public void Set_equipmentWorldIconObjData(CigaretteWorldUIIconData cigaretteWorldUIIconData)
        {
            equipmentWorldIconObj.SetIconData(cigaretteWorldUIIconData);
        }
    }
}
/// <summary>
/// 激光打码机数据
/// </summary>
[Serializable]
public class LaserCodingMachineData
{
    public LaserBase laserBase;

    public Signal signal;
}
/// <summary>
/// 激光打码机数据
/// </summary>
[Serializable]
public class LaserBase
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

    
  
}
/// <summary>
/// 信号灯及蜂鸣器状态
/// </summary>
[Serializable]
public class Signal
{
    /// <summary>
    /// 绿灯状态,ON,OFF,SPARK(交替)
    /// </summary>
    public string greenLightState;
    /// <summary>
    /// 黄灯状态,ON,OFF,SPARK(交替)
    /// </summary>
    public string yellowLightState;
    /// <summary>
    /// 红灯状态,ON,OFF,SPARK(交替)
    /// </summary>
    public string redLightState;
    /// <summary>
    /// 蜂鸣器状态,ON,OFF,SPARK(交替)
    /// </summary>
    public string buzzerState;
    /// <summary>
    /// 设备启停
    /// </summary>
    public bool running;

    public string GetSatate()
    {
        if (running)
        {
            return "运行";
        }
        else
        {
            return "停止";
        }
    }
}