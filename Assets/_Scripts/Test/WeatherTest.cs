using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
public class WeatherTest : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(100,100,200,100),"获取当前城市天气"))
        {
            WeatherTool.Instance.GetCurrentCityWeatherData(GetWeatherSuccess, GetWeatherFail);
        }
        if (GUI.Button(new Rect(100, 400, 200, 100), "获取北京市天气"))
        {
            WeatherTool.Instance.GetCityWeatherDataForCityName("北京市",GetWeatherSuccess, GetWeatherFail);
        }
    }

    private void GetWeatherSuccess(WeatherData weatherData)
    {
        Debug.Log("获取城市天气数据成功");
        Debug.Log(weatherData.data.forecast[0].date);
        Debug.Log(weatherData.data.forecast[0].high);
        Debug.Log(weatherData.data.forecast[0].low);
        Debug.Log(weatherData.data.forecast[0].ymd);
        Debug.Log(weatherData.data.forecast[0].week);
        Debug.Log(weatherData.data.forecast[0].sunrise);
        Debug.Log(weatherData.data.forecast[0].sunset);
        Debug.Log(weatherData.data.forecast[0].aqi);
        Debug.Log(weatherData.data.forecast[0].fx);
        Debug.Log(weatherData.data.forecast[0].fl);
        Debug.Log(weatherData.data.forecast[0].type);
        Debug.Log(weatherData.data.forecast[0].notice);
    }

    private void GetWeatherFail()
    {
        Debug.Log("获取城市天气数据失败");
    }

}
