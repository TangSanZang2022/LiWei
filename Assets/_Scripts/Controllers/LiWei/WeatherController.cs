using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalSnowEffect;
using DG.Tweening;
using UnityEngine.Events;
namespace LiWei
{
    /// <summary>
    /// 天气时间控制
    /// </summary>
    public class WeatherController : BaseController
    {
        /// <summary>
        /// 当前天气
        /// </summary>
        private string currentWeather= "sun";
        /// <summary>
        /// 当前时间
        /// </summary>
        private string currentTime= "noon";
        /// <summary>
        /// 上一个天气
        /// </summary>
        private string lastWeather= "sun";
        /// <summary>
        /// 上一个时间
        /// </summary>
        private string lastTime= "noon";
        public WeatherController(GameFacade gameFacade) : base(gameFacade)
        { }
        private EnviroSkyMgr _enviroSkyMgr;
        private EnviroSkyMgr enviroSkyMgr
        {
            get
            {
                if (_enviroSkyMgr==null)
                {
                    _enviroSkyMgr = EnviroSkyMgr.instance;
                }
                return _enviroSkyMgr;
            }
        }

        private CamScreenSnow _camScreenSnow;
        /// <summary>
        /// 雪的覆盖效果
        /// </summary>
        private CamScreenSnow camScreenSnow
        {
            get
            {
                if (_camScreenSnow==null)
                {
                    _camScreenSnow = Camera.main.GetComponent<CamScreenSnow>();
                }
                return _camScreenSnow;
            }
        }

        private GameObject mainLight;
        /// <summary>
        /// 主光源
        /// </summary>
        private GameObject MainLight
        {
            get
            {
                if (mainLight == null)
                {
                    mainLight = GameObject.Find("MainLight");
                }
                return mainLight;
            }
        }
        private GameObject night;
        /// <summary>
        /// 晚上光源
        /// </summary>
        private GameObject Night
        {
            get
            {
                if (night == null)
                {
                    night = GameObject.Find("Night");
                }
                return night;
            }
        }
        
        public override void OnInit()
        {
            base.OnInit();
            // SetWeather("sun");
            //SetTime("noon");
            // _camScreenSnow.enabled = false;
            Night.SetActive(false);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnDestory()
        {
            base.OnDestory();
        }
        /// <summary>
        /// 设置天气
        /// </summary>
        /// <param name="weather">"sun":晴天，"cloudy":阴天，"rain":雨天，"snow":雪天，空的时候为晴天</param>
        public void SetWeather(string weather)
        {
            lastWeather = currentWeather;
            switch (weather.ToLower())
            {
                case "sun"://晴天
                    enviroSkyMgr.ChangeWeather(0);
                    Stop_globalSnow();
                    break;
                case "cloudy"://阴天
                    enviroSkyMgr.ChangeWeather(2);
                    Stop_globalSnow();
                    break;
                case "rain"://雨天
                    enviroSkyMgr.ChangeWeather(7);
                    Stop_globalSnow();
                    break;
                case "snow"://雪天
                    enviroSkyMgr.ChangeWeather(9);
                    Start_globalSnow();
                    break;
                default:
                    enviroSkyMgr.ChangeWeather(0);
                    Stop_globalSnow();
                    break;
            }
            currentWeather = weather;
        }
        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="timeString">"morning":早上,"noon":中午,"afternoon":下午,"night":晚上,空的时候为当前时间</param>
        public void SetTime(string timeString)
        {
            lastTime = currentTime;
            switch (timeString.ToLower())
            {
                case "morning"://早上
                    enviroSkyMgr.SetTimeOfDay(8);
                    MainLight.SetActive(true);
                    Night.SetActive(false);
                    break;
                case "noon"://中午
                    enviroSkyMgr.SetTimeOfDay(12);
                    MainLight.SetActive(true);
                    Night.SetActive(false);
                    break;
                case "afternoon"://下午
                    enviroSkyMgr.SetTimeOfDay(17);
                    MainLight.SetActive(true);
                    Night.SetActive(false);
                    break;

                case "night"://晚上
                    enviroSkyMgr.SetTimeOfDay(20);
                    MainLight.SetActive(false);
                    Night.SetActive(true);
                    break;
                default:
                    enviroSkyMgr.SetTime(DateTime.Now);
                    MainLight.SetActive(true);
                    Night.SetActive(false);
                    break;
            }
            currentTime = timeString;
        }
        /// <summary>
        /// 开启雪的覆盖效果
        /// </summary>
        public void Start_globalSnow()
        {
            camScreenSnow.Start_globalSnow();
            
        }
        /// <summary>
        /// 停止雪的覆盖效果
        /// </summary>
        public void Stop_globalSnow()
        {
            camScreenSnow.Stop_globalSnow();

        }
        /// <summary>
        /// 设置到上一个天气和时间
        /// </summary>
        public void WeatherTime_Back()
        {
            SetWeather(lastWeather);
            SetTime(lastTime);
        }
        /// <summary>
        /// 设置为最佳天气和时间
        /// </summary>
        public void SetBestWeatherAndTime()
        {
            SetWeather("sun");
            SetTime("noon");
        }
    }
}
