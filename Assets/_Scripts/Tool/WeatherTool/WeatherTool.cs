using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using BestHTTP;
using System;
using System.Text.RegularExpressions;
using Common;
namespace Tools
{
    #region 返回的城市名字等数据类
    public class CityData
    {
        public string address;
        public Content content;
        public int status;

    }
    public class Content
    {
        public string address;
        public Address_Detail address_detail;
        public Point point;
    }
    public class Address_Detail
    {
        public string city;
        public int city_code;
        public string district;
        public string province;
        public string street;
        public string street_number;
    }

    public class Point
    {
        public string x;
        public string y;
    }
    #endregion

    #region 城市的city_code编号代码
    public class CityCode
    {
        public int id;
        public int pid;
        public string city_code;
        public string city_name;
        public string post_code;
        public string area_code;
        public string ctime;
    }
    #endregion

    #region 天气数据类
    public class WeatherData
    {
        public string message;
        public int status;
        public string date;
        public string time;
        public CityInfo cityInfo;
        public WeathData data;
    }
    public class CityInfo
    {
        public string city;
        public string cityId;
        public string parent;
        public string updateTime;
    }
    public class WeathData
    {
        public string shidu;
        public double pm25;
        public double pm10;
        public string quality;
        public string wendu;
        public string ganmao;
        public WeathDetailData[] forecast;
        public WeathDetailData yesterday;
    }
    public class WeathDetailData
    {
        public string date;
        public string sunrise;
        public string high;
        public string low;
        public string sunset;
        public double aqi;
        public string ymd;
        public string week;
        public string fx;
        public string fl;
        public string type;
        public string notice;
    }
    #endregion
    /// <summary>
    /// 获取到了天气之后委托
    /// </summary>
    /// <param name="weatherTool"></param>
    public delegate void GetWeatherSucceedHandle(WeatherData weatherData);
    /// <summary>
    /// 获取天气失败回调
    /// </summary>
    /// <param name="weatherTool"></param>
    public delegate void GetWeatherFailHandle();
    public class WeatherTool : MonoSingleton<WeatherTool>
    {

        public GetWeatherSucceedHandle getWeatherSucceedHandle;

        public GetWeatherFailHandle getWeatherFailHandle;
        public static Dictionary<string, string> PosToId = new Dictionary<string, string>();
        public static bool initDic = false;

        public
        /// <summary>
        /// 城市名转换为城市编号
        /// </summary>
        string Cityurl = "http://t.weather.sojson.com/api/weather/city/city_code";
        /// <summary>
        /// 获取位置信息
        /// </summary>
        string Posurl = "http://api.map.baidu.com/location/ip?ak=bretF4dm6W5gqjQAXuvP0NXW6FeesRXb&coor=bd09ll";
        /// <summary>
        /// 获取天气信息
        /// </summary>
        string Weatherurl = "http://t.weather.sojson.com/api/weather/city/";

        string testUrl = "http://wthrcdn.etouch.cn/weather_mini?city=";
        void Start()
        {
            //获取位置
            //StartCoroutine(RequestCityName());
            // StartCoroutine(RequestCityCode());
            // GetTestWeatherData();
        }
        /// <summary>
        /// 获取当前城市天气
        /// </summary>
        /// <param name="getWeatherSucceedHandle"></param>
        /// <param name="getWeatherFailHandle"></param>
        public void GetCurrentCityWeatherData(GetWeatherSucceedHandle getWeatherSucceedHandle, GetWeatherFailHandle getWeatherFailHandle)
        {
            this.getWeatherSucceedHandle = null;
            this.getWeatherFailHandle = null;
            this.getWeatherSucceedHandle += getWeatherSucceedHandle;
            this.getWeatherFailHandle += getWeatherFailHandle;
            StartCoroutine(RequestCityName());
        }

        /// <summary>
        /// 获取当前城市天气
        /// </summary>
        /// <param name="getWeatherSucceedHandle"></param>
        /// <param name="getWeatherFailHandle"></param>
        public void GetCityWeatherDataForCityName(string cityName, GetWeatherSucceedHandle getWeatherSucceedHandle, GetWeatherFailHandle getWeatherFailHandle)
        {
            this.getWeatherSucceedHandle = null;
            this.getWeatherFailHandle = null;
            this.getWeatherSucceedHandle += getWeatherSucceedHandle;
            this.getWeatherFailHandle += getWeatherFailHandle;
            StartCoroutine(RequestWeatherData(GetWeatherId(cityName)));
        }

        IEnumerator RequestCityName()
        {
            WWW www = new WWW(Posurl);
            yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                CityData cityData = LitJson.JsonMapper.ToObject<CityData>(www.text);
                Debug.Log(cityData.content.address_detail.city);
                //获取city_code
                Debug.Log(GetWeatherId(cityData.content.address_detail.city));
                //获取天气信息
                string city_code = GetWeatherId(cityData.content.address_detail.city);
                //string city_code = "101200101";
                StartCoroutine(RequestWeatherData(city_code));
            }
        }

        // IEnumerator RequestCityCode()
        //{
        //HTTPRequest request = new HTTPRequest(new System.Uri(testUrl + "武汉"));
        //// unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
        //yield return request.Send();
        //Debug.Log.text);

        // }
        private void GetTestWeatherData()
        {
            HTTPRequest request = new HTTPRequest(new System.Uri(testUrl + "武汉"), CallBack);
            request.Send();
            // unityWebRequest.downloadHandler = new DownloadHandlerBuffer();

        }

        private void CallBack(HTTPRequest originalRequest, HTTPResponse response)
        {
            Debug.Log(response.DataAsText);
        }

        private string GetWeatherId(string name)
        {
            string city_code = "";

            if (!initDic)
            {
                initDic = true;
                TextAsset city = Resources.Load<TextAsset>("city");
                if (city==null)
                {
                    Debug.Log("读取city失败");
                    if (getWeatherFailHandle!=null)
                    {
                        getWeatherFailHandle();
                    }
                    return null;
                }
                string content = Regex.Replace(city.text, @"\n", "");
                string[] cityAndID = content.Split(',');
                foreach (string item in cityAndID)
                {
                    string[] nameAndID = item.Split(':');
                    if (!PosToId.ContainsKey(nameAndID[0]))
                    {
                        PosToId.Add(nameAndID[0], nameAndID[1]);
                    }

                }
                //List<CityCode> cityCode = LitJson.JsonMapper.ToObject<List<CityCode>>(city.text);
                //foreach (CityCode t in cityCode)
                //{
                //    PosToId[t.city_name] = t.city_code;
                //}
            }
            //for (int i = 1; i < name.Length; i++)
            //{
            //    string tn = name.Substring(0, i);
            //    if (PosToId.ContainsKey(tn))
            //    {
            //        city_code = PosToId[tn];
            //    }
            //}
            if (PosToId.ContainsKey(name))
            {
                city_code = PosToId[name];
            }
            return city_code;
        }

        IEnumerator RequestWeatherData(string cicy_code)
        {
            WWW www = new WWW(Weatherurl + cicy_code);
            Debug.Log(Weatherurl + cicy_code);
            yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.text);
                WeatherData t = LitJson.JsonMapper.ToObject<WeatherData>(www.text);
                if (getWeatherSucceedHandle != null)
                {
                    getWeatherSucceedHandle(t);
                }
                //天气信息
                Debug.Log(t.data.forecast[0].date);
                Debug.Log(t.data.forecast[0].high);
                Debug.Log(t.data.forecast[0].low);
                Debug.Log(t.data.forecast[0].ymd);
                Debug.Log(t.data.forecast[0].week);
                Debug.Log(t.data.forecast[0].sunrise);
                Debug.Log(t.data.forecast[0].sunset);
                Debug.Log(t.data.forecast[0].aqi);
                Debug.Log(t.data.forecast[0].fx);
                Debug.Log(t.data.forecast[0].fl);
                Debug.Log(t.data.forecast[0].type);
                Debug.Log(t.data.forecast[0].notice);
            }
            else
            {
                Debug.Log("获取天气数据失败");
                if (getWeatherFailHandle != null)
                {
                    getWeatherFailHandle();
                }
            }
        }
    }
}
