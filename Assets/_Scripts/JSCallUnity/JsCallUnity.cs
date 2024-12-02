using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LiWei;
using Tools;
namespace JsCallUnityTool
{
    /// <summary>
    /// JS调用Unity方法
    /// </summary>
    public class JsCallUnity : MonoBehaviour
    {
//#if UNITY_EDITOR
        private void OnGUI()
        {
            if (GUI.Button(new Rect(100, 50, 200, 50), "BestView_HarbourOverview"))
            {
                SetCamToBestViewPos_HarbourOverview();
            }
            if (GUI.Button(new Rect(100, 150, 200, 50), "BestView_DeviceInfo"))
            {
                SetCamToBestViewPos_DeviceInfo();
            }
            if (GUI.Button(new Rect(100, 200, 200, 50), "SetCamToBestViewPos_PartDetails"))
            {
                SetCamToBestViewPos_PartDetails();
            }
            if (GUI.Button(new Rect(100, 300, 200, 50), "sun"))
            {
                SetWeather("sun");
            }
            if (GUI.Button(new Rect(100, 400, 200, 50), "cloudy"))
            {
                SetWeather("cloudy");
            }
            if (GUI.Button(new Rect(100, 500, 200, 50), "rain"))
            {
                SetWeather("rain");
            }
            if (GUI.Button(new Rect(100, 600, 200, 50), "snow"))
            {
                SetWeather("snow");
            }

            if (GUI.Button(new Rect(400, 300, 200, 50), "morning"))
            {
                SetTime("morning");
            }
            if (GUI.Button(new Rect(400, 400, 200, 50), "noon"))
            {
                SetTime("noon");
            }
            if (GUI.Button(new Rect(400, 500, 200, 50), "afternoon"))
            {
                SetTime("afternoon");
            }
            if (GUI.Button(new Rect(400, 600, 200, 50), "night"))
            {
                SetTime("night");
            }
            if (GUI.Button(new Rect(700, 100, 200, 50), "HarbourOverview"))///港口总览
            {
                OnHarbourOverviewClick();
            }
            if (GUI.Button(new Rect(1000, 100, 200, 50), "DeviceInfo"))///设备详情
            {
                OnDeviceInfoClick();
            }
            if (GUI.Button(new Rect(1300, 100, 200, 50), "PartDetails"))///部件详情
            {
                OnPartDetailsClick();
            }

            if (GUI.Button(new Rect(1000, 800, 200, 50), "ShoreBridge"))///岸桥
            {
                ChangeDeviceForID("ShoreBridge");
            }
            if (GUI.Button(new Rect(1300, 800, 200, 50), "TyreCrane"))///轮胎吊
            {
                ChangeDeviceForID("TyreCrane");
            }
            if (GUI.Button(new Rect(1600, 800, 200, 50), "RMG"))///轨道吊
            {
                ChangeDeviceForID("RMG");
            }

            if (GUI.Button(new Rect(500, 900, 100, 50), "EM01"))///ElectricMachine01
            {
                ChangePartForID("ElectricMachine01");
            }
            //if (GUI.Button(new Rect(700, 900, 100, 50), "EM_Test01"))///ElectricMachine_Test01
            //{
            //    ChangePartForID("ElectricMachine_Test01");
            //}
            //if (GUI.Button(new Rect(900, 900, 100, 50), "EM_Test04"))///ElectricMachine_Test04
            //{
            //    ChangePartForID("ElectricMachine_Test04");
            //}
            //if (GUI.Button(new Rect(1100, 900, 100, 50), "EM_Test05"))///ElectricMachine_Test05
            //{
            //    ChangePartForID("ElectricMachine_Test05");
            //}
            //if (GUI.Button(new Rect(1300, 900, 100, 50), "EM_Test02"))///ElectricMachine_Test02
            //{
            //    ChangePartForID("ElectricMachine_Test02");
            //}
            //if (GUI.Button(new Rect(1500, 900, 100, 50), "EM_Test03"))///ElectricMachine_Test03
            //{
            //    ChangePartForID("ElectricMachine_Test03");
            //}

            if (GUI.Button(new Rect(1000, 200, 200, 50), "SetToFadeMode"))///设备详情
            {
                SetToFadeMode();
            }
            if (GUI.Button(new Rect(1300, 200, 200, 50), "SetToBombMode"))///部件详情
            {
                SetToBombMode();
            }
        }
//#endif
        /// <summary>
        /// 港口概览点击
        /// </summary>
        public void OnHarbourOverviewClick()
        {
           GameFacade.Instance.Set_gameState(GameState.HarbourOverview);
            GameFacade.Instance.Set_currentDevices(null);//回到港口视角
           // ChangeDeviceForID("");
            Debug.Log("港口概览");
        }
        /// <summary>
        /// 设备详情点击
        /// </summary>
        public void OnDeviceInfoClick()
        {
            GameFacade.Instance.Set_gameState(GameState.DeviceInfo);
            //LiWeiBaseDevices baseDevices = GameFacade.Instance.Get_currentDevices();
            //string id = "";
            //if (baseDevices != null)
            //{
            //    id = baseDevices.Get_id();

            //}
           GameFacade.Instance.GoToDevicesForID();//前往设备
            //ChangeDeviceForID("");
            Debug.Log("设备详情");
        }
        /// <summary>
        /// 部件详情点击
        /// </summary>
        public void OnPartDetailsClick()
        {
            GameFacade.Instance.Set_gameState(GameState.PartDetails);
            GameFacade.Instance.GoToPartForID();
           // ChangePartForID("");
            Debug.Log("部件详情");
        }

        /// <summary>
        /// 设置相机到最佳视角
        /// </summary>
        public void SetCamToBestViewPos()
        {
            switch (GameFacade.Instance.Get_gameState())
            {
                case GameState.HarbourOverview:
                    GameFacade.Instance.SetTarnsToPos(GameObjIDTool.PortBestPos, Camera.main.transform);
                    break;
                case GameState.DeviceInfo:
                    GameFacade.Instance.SetCamToCurrentDevicesBestViewPos();
                    break;
                case GameState.PartDetails:
                    GameFacade.Instance.GoToPartForID();
                    //todo
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 港口层级设置相机到最佳视角
        /// </summary>
        public void SetCamToBestViewPos_HarbourOverview()
        {
            GameFacade.Instance.SetTarnsToPos(GameObjIDTool.PortBestPos, Camera.main.transform);
        }

        /// <summary>
        /// 设备层级设置相机到最佳视角
        /// </summary>
        public void SetCamToBestViewPos_DeviceInfo()
        {
            GameFacade.Instance.SetCamToCurrentDevicesBestViewPos();
        }

        /// <summary>
        /// 部件层级设置相机到最佳视角
        /// </summary>
        public void SetCamToBestViewPos_PartDetails()
        {
            GameFacade.Instance.GoToPartForID();
        }
        /// <summary>
        /// 设置相机的位置
        /// </summary>
        /// <param name="posID"></param>
        public void SetCamPos(string posID)
        {
            GameFacade.Instance.SetTarnsToPos(posID, Camera.main.transform);
        }
        /// <summary>
        /// 设置天气
        /// </summary>
        /// <param name="weather">"sun":晴天，"cloudy":阴天，"rain":雨天，"snow":雪天</param>
        public void SetWeather(string weather)
        {
            GameFacade.Instance.SetWeather(weather);
        }
        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="timeString">"morning":早上,"noon":中午,"afternoon":下午,"night":晚上</param>
        public void SetTime(string time)
        {
            GameFacade.Instance.SetTime(time);
        }
        /// <summary>
        /// 根据设备ID来切换展示的设备
        /// </summary>
        /// <param name="deviceID">"ShoreBridge":岸桥,"TyreCrane":轮胎吊,"RMG":轨道吊</param>
        public void ChangeDeviceForID(string deviceID)
        {
            GameFacade.Instance.GoToDevicesForID(deviceID);
        }

        /// <summary>
        /// 根据设备ID来切换展示的设备
        /// </summary>
        /// <param name="deviceID">"ElectricMachine01":岸桥中的电动机</param>
        public void ChangePartForID(string partID)
        {
            GameFacade.Instance.GoToPartForID(partID);
        }

        /// <summary>
        /// 透视模式
        /// </summary>
        public void SetToFadeMode()
        {
            GameFacade.Instance.SetToFadeMode(0.01f, 5f);
        }
        /// <summary>
        /// 爆炸模式
        /// </summary>
        public void SetToBombMode()
        {
            GameFacade.Instance.SetToBombMode();
        }
    }
}
