using DFDJ;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using System;

public class DataInterfaceTest : MonoBehaviour
{
    /// <summary>
    /// 读取到的数据接口
    /// </summary>
    public DataInterfaceConfig dataInterfaceConfig;

    public int getDataNum;
    public Text interfaceText;
    public Text dataText;
    public Text getDataNumText;
    private string nowTime;
    private string deviceCollectionItemInformation_JsonBody;
    private string signValue;
    /// <summary>
    /// 获取实时工艺参数信息接口中设备ID，多个用$$隔开
    /// </summary>
    private string deviceValue;
    /// <summary>
    /// 获取实时工艺参数信息接口中采集项编码，多个用$$隔开
    /// </summary>
    private string itemValue;
    /// <summary>
    /// 获取设备、采集项信息接口HTTPRequest
    /// </summary>
    private HTTPRequest deviceCollectionItemInformation_HTTPRequest;
    /// <summary>
    /// 获取实时工艺参数信息接口的sonBody
    /// </summary>
    private string realTimeData_JsonBody;
    /// <summary>
    /// 获取实时工艺参数信息接口HTTPRequest
    /// </summary>
    private HTTPRequest realTimeData_HTTPRequest;

    #region//历史数据
    /// <summary>
    /// 历史数据要查询的数据项
    /// </summary>
    private string historyDataItemValue;
    /// <summary>
    /// 历史数据开始时间
    /// </summary>
    private string historyDataStartValue;
    /// <summary>
    /// 历史数据结束时间
    /// </summary>
    private string historyDataEndValue;
    /// <summary>
    /// 历史数据设备编号
    /// </summary>
    private string historyDataDevice;

    /// <summary>
    /// 历史数据的sonBody
    /// </summary>
    private string historyData_JsonBody;

    /// <summary>
    /// 历史数据接口HTTPRequest
    /// </summary>
    private HTTPRequest historyData_HTTPRequest;

    #endregion

    #region//获取实时信息
    /// <summary>
    /// 获取设备的实时信息的设备编号
    /// </summary>
    private string realTimeStatusOfEquipmentDevice;
    /// <summary>
    /// 获取设备的实时信息的jsonBody
    /// </summary>
    private string realTimeStatusOfEquipment_JsonBody;

    /// <summary>
    /// 获取设备的实时信息的HTTPRequest
    /// </summary>
    private HTTPRequest realTimeStatusOfEquipment_HTTPRequest;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        dataInterfaceConfig = XmlController.ReadJson<DataInterfaceConfig>("", Application.streamingAssetsPath + "/DataInterfaceConfig.txt");
        // Debug.Log(dataInterfaceConfig.DeviceCollectionItemInformation);
        nowTime = System.DateTime.Today.ToString("yyyy-MM-dd");
        signValue = EncryptMD5.EncryptMD5_32(dataInterfaceConfig.Username + dataInterfaceConfig.Password + nowTime, true);
        deviceCollectionItemInformation_JsonBody = string.Format("?username={0}&sign={1}", dataInterfaceConfig.Username, signValue);

        //deviceValue = "001077$$001007";
        //itemValue = "absolutePosition_x$$absolutePosition_y";
        //realTimeData_JsonBody = string.Format("?username={0}&sign={1}&device={2}&item={3}", dataInterfaceConfig.Username, signValue, deviceValue, itemValue);

        //historyDataDevice = "001077$$001007";
        //historyDataItemValue = "absolutePosition_x$$absolutePosition_y";
        //historyDataStartValue = "202112010000";
        //historyDataEndValue = "202112020000";
        //historyData_JsonBody = string.Format("?username={0}&sign={1}&device={2}&item={3}&start={4}&end={5}", dataInterfaceConfig.Username, signValue, historyDataDevice, historyDataItemValue, historyDataStartValue, historyDataEndValue);

        //realTimeStatusOfEquipmentDevice = "001077$$001007";
        //realTimeStatusOfEquipment_JsonBody = string.Format("?username={0}&sign={1}&device={2}", dataInterfaceConfig.Username, signValue, realTimeStatusOfEquipmentDevice);

        //RealTimeDataList realTimeDataDataList = XmlController.ReadJsonForLitJson<RealTimeDataList>("", Application.streamingAssetsPath + "/RealTimeData.txt");
        //Debug.Log(realTimeDataDataList.data.Count);
        //Debug.Log(realTimeDataDataList.data["001077"]);
        //RealTimePosData realTimeDataData = XmlController.ReadJsonForLitJson<RealTimePosData>(realTimeDataDataList.data["001077"]);
        //Debug.Log(realTimeDataData.absolutePosition_y);
       // foreach (var item in realTimeDataDataList.data)
        //{
            
            //foreach (var item1 in item)
            //{
            //    Debug.Log(item1);
            //}
        //}
        //Debug.Log(realTimeDataDataList.data);
    }
    private void SetTextContent(Text t, string content)
    {
        t.text = "";
        t.text = content;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 50), "获取设备、采集项信息接口"))
        {
            dataInterfaceConfig = XmlController.ReadJson<DataInterfaceConfig>("", Application.streamingAssetsPath + "/DataInterfaceConfig.txt");
            // Debug.Log(dataInterfaceConfig.DeviceCollectionItemInformation);
            nowTime = System.DateTime.Today.ToString("yyyy-MM-dd");
            signValue = EncryptMD5.EncryptMD5_32(dataInterfaceConfig.Username + dataInterfaceConfig.Password + nowTime, true);
            deviceCollectionItemInformation_JsonBody= string.Format("?username={0}&sign={1}", dataInterfaceConfig.Username, signValue);
            AbortAllHTTPRequest();
            SetTextContent(interfaceText, "");
            SetTextContent(dataText, "");
            SetTextContent(getDataNumText, "");
            getDataNum = 0;
            string interfacePath = dataInterfaceConfig.DeviceCollectionItemInformation + deviceCollectionItemInformation_JsonBody;
            SetTextContent(interfaceText, "获取设备、采集项信息接口"+ interfacePath);
            //if (deviceCollectionItemInformation_HTTPRequest == null)
            {
                deviceCollectionItemInformation_HTTPRequest = new HTTPRequest(new Uri(interfacePath), OnDeviceCollectionItemInformation_HTTPRequestFinished);
            }
            deviceCollectionItemInformation_HTTPRequest.ConnectTimeout = TimeSpan.FromSeconds(10);
            deviceCollectionItemInformation_HTTPRequest.Send();
            //Debug.Log(System.DateTime.Today.ToString("yyyy-MM-dd"));
            //string content = "112022-01-12";
            //Debug.Log(EncryptMD5.EncryptMD5_32(content, true));
            //38255856cd172f7d907105371b7248c4
            //38255856CD172F7D907105371B7248C4
        }
        if (GUI.Button(new Rect(10, 70, 200, 50), "获取实时工艺参数信息接口"))
        {
            dataInterfaceConfig = XmlController.ReadJson<DataInterfaceConfig>("", Application.streamingAssetsPath + "/DataInterfaceConfig.txt");
           
            realTimeData_JsonBody = string.Format("?username={0}&sign={1}&device={2}&item={3}", dataInterfaceConfig.Username, signValue, dataInterfaceConfig.Device, dataInterfaceConfig.Item);
            AbortAllHTTPRequest();
            SetTextContent(interfaceText, "");
            SetTextContent(dataText, "");
            SetTextContent(getDataNumText, "");
            getDataNum = 0;
            string interfacePath = dataInterfaceConfig.RealTimeData + realTimeData_JsonBody;
            SetTextContent(interfaceText, "获取实时工艺参数信息接口" + interfacePath);
            //if (realTimeData_HTTPRequest == null)
            {
                realTimeData_HTTPRequest = new HTTPRequest(new Uri(interfacePath), RealTimeData_HTTPRequestFinished);
            }
            realTimeData_HTTPRequest.ConnectTimeout = TimeSpan.FromSeconds(10);
            realTimeData_HTTPRequest.Send();

            //Debug.Log(System.DateTime.Today.ToString("yyyy-MM-dd"));
            //string content = "112022-01-12";
            //Debug.Log(EncryptMD5.EncryptMD5_16(content));
            //38255856cd172f7d907105371b7248c4
            //38255856CD172F7D907105371B7248C4
        }

        if (GUI.Button(new Rect(10, 130, 200, 50), "获取历史采集项信息接口"))
        {
            dataInterfaceConfig = XmlController.ReadJson<DataInterfaceConfig>("", Application.streamingAssetsPath + "/DataInterfaceConfig.txt");
            historyData_JsonBody = string.Format("?username={0}&sign={1}&device={2}&item={3}&start={4}&end={5}", dataInterfaceConfig.Username, signValue, dataInterfaceConfig.Device, dataInterfaceConfig.Item, dataInterfaceConfig.Start, dataInterfaceConfig.End);
            AbortAllHTTPRequest();
            SetTextContent(interfaceText, "");
            SetTextContent(dataText, "");
            SetTextContent(getDataNumText, "");
            getDataNum = 0;
            string interfacePath = dataInterfaceConfig.HistoryData + historyData_JsonBody;
            SetTextContent(interfaceText, "获取历史采集项信息接口" + interfacePath);
            //if (historyData_HTTPRequest == null)
            {
                historyData_HTTPRequest = new HTTPRequest(new Uri(interfacePath), OnHistoryData_HTTPRequestFinished);
            }
            historyData_HTTPRequest.ConnectTimeout = TimeSpan.FromSeconds(10);
            historyData_HTTPRequest.Send();
        }
        if (GUI.Button(new Rect(10, 190, 200, 50), "获取设备实时状态信息接口"))
        {
            dataInterfaceConfig = XmlController.ReadJson<DataInterfaceConfig>("", Application.streamingAssetsPath + "/DataInterfaceConfig.txt");
            realTimeStatusOfEquipment_JsonBody = string.Format("?username={0}&sign={1}&device={2}", dataInterfaceConfig.Username, signValue, dataInterfaceConfig.Device);
            AbortAllHTTPRequest();
            SetTextContent(interfaceText, "");
            SetTextContent(dataText, "");
            SetTextContent(getDataNumText, "");
            getDataNum = 0;
            string interfacePath = dataInterfaceConfig.RealTimeStatusOfEquipment + realTimeStatusOfEquipment_JsonBody;
            SetTextContent(interfaceText, "获取设备实时状态信息接口" + interfacePath);
           // if (realTimeStatusOfEquipment_HTTPRequest == null)
            {
                Debug.Log(111);
                realTimeStatusOfEquipment_HTTPRequest = new HTTPRequest(new Uri(interfacePath), OnRealTimeStatusOfEquipment_HTTPRequestFinished);
            }
            realTimeStatusOfEquipment_HTTPRequest.ConnectTimeout = TimeSpan.FromSeconds(10);
            realTimeStatusOfEquipment_HTTPRequest.Send();
        }
    }

    private void OnRealTimeStatusOfEquipment_HTTPRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        getDataNum++;
        SetTextContent(getDataNumText, getDataNum.ToString());
        switch (originalRequest.State)
        {
            case HTTPRequestStates.Initial:
                break;
            case HTTPRequestStates.Queued:
                break;
            case HTTPRequestStates.Processing:
                break;
            case HTTPRequestStates.Finished:
                SetTextContent(dataText, response.DataAsText);
                break;
            case HTTPRequestStates.Error:
                SetTextContent(dataText, "获取设备实时状态信息接口错误" + originalRequest.Exception.Message);
                break;
            case HTTPRequestStates.Aborted:
                break;
            case HTTPRequestStates.ConnectionTimedOut:
                SetTextContent(dataText, "获取设备实时状态信息接口,连接超时");
                break;
            case HTTPRequestStates.TimedOut:
                SetTextContent(dataText, "获取设备实时状态信息接口,未在规定时间内完成request");
                break;
            default:
                break;
        }
        if (response != null)
        {
            //originalRequest.Send();
        }
    }

    private void OnHistoryData_HTTPRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        getDataNum++;
        SetTextContent(getDataNumText, getDataNum.ToString());
        switch (originalRequest.State)
        {
            case HTTPRequestStates.Initial:
                break;
            case HTTPRequestStates.Queued:
                break;
            case HTTPRequestStates.Processing:
                break;
            case HTTPRequestStates.Finished:
                SetTextContent(dataText, response.DataAsText);
                break;
            case HTTPRequestStates.Error:
                SetTextContent(dataText, "历史数据接口错误" + originalRequest.Exception.Message);
                break;
            case HTTPRequestStates.Aborted:
                break;
            case HTTPRequestStates.ConnectionTimedOut:
                SetTextContent(dataText, "历史数据接口,连接超时");
                break;
            case HTTPRequestStates.TimedOut:
                SetTextContent(dataText, "历史数据接口,未在规定时间内完成request");
                break;
            default:
                break;
        }
        if (response != null)
        {
            //originalRequest.Send();
        }
    }

    private void RealTimeData_HTTPRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        getDataNum++;
        SetTextContent(getDataNumText, getDataNum.ToString());
        switch (originalRequest.State)
        {
            case HTTPRequestStates.Initial:
                break;
            case HTTPRequestStates.Queued:
                break;
            case HTTPRequestStates.Processing:
                break;
            case HTTPRequestStates.Finished:
                SetTextContent(dataText, response.DataAsText);
                break;
            case HTTPRequestStates.Error:
                SetTextContent(dataText, "获取实时工艺参数信息接口错误" + originalRequest.Exception.Message);
                break;
            case HTTPRequestStates.Aborted:
                break;
            case HTTPRequestStates.ConnectionTimedOut:
                SetTextContent(dataText, "获取实时工艺参数信息接口,连接超时");
                break;
            case HTTPRequestStates.TimedOut:
                SetTextContent(dataText, "获取实时工艺参数信息接口,未在规定时间内完成request");
                break;
            default:
                break;
        }
        if (response != null)
        {
            //originalRequest.Send();
        }
    }

    private void OnDeviceCollectionItemInformation_HTTPRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        getDataNum++;
        SetTextContent(getDataNumText, getDataNum.ToString());
        switch (originalRequest.State)
        {
            case HTTPRequestStates.Initial:
                break;
            case HTTPRequestStates.Queued:
                break;
            case HTTPRequestStates.Processing:
                break;
            case HTTPRequestStates.Finished:
                SetTextContent(dataText, response.DataAsText);
                break;
            case HTTPRequestStates.Error:
                SetTextContent(dataText, "获取设备、采集项信息接口错误" + originalRequest.Exception.Message);
                break;
            case HTTPRequestStates.Aborted:
                break;
            case HTTPRequestStates.ConnectionTimedOut:
                SetTextContent(dataText, "获取设备、采集项信息接口,连接超时");
                break;
            case HTTPRequestStates.TimedOut:
                SetTextContent(dataText, "获取设备、采集项信息接口,未在规定时间内完成request");
                break;
            default:
                break;
        }

        if (response != null)
        {
            //originalRequest.Send();
        }
    }

    private void AbortAllHTTPRequest()
    {
        if (deviceCollectionItemInformation_HTTPRequest != null)
        {
            deviceCollectionItemInformation_HTTPRequest.Abort();
            realTimeStatusOfEquipment_HTTPRequest = null;
        }
        if (realTimeData_HTTPRequest != null)
        {
            realTimeData_HTTPRequest.Abort();
            realTimeData_HTTPRequest = null;
        }
        if (historyData_HTTPRequest != null)
        {
            historyData_HTTPRequest.Abort();
            historyData_HTTPRequest = null;
        }
        if (realTimeStatusOfEquipment_HTTPRequest!=null)
        {
            realTimeStatusOfEquipment_HTTPRequest.Abort();
            realTimeStatusOfEquipment_HTTPRequest = null;
        }
    }
    private void OnDestroy()
    {
        if (deviceCollectionItemInformation_HTTPRequest != null)
        {
            deviceCollectionItemInformation_HTTPRequest.Abort();
            deviceCollectionItemInformation_HTTPRequest.Callback = null;
        }
        if (realTimeData_HTTPRequest != null)
        {
            realTimeData_HTTPRequest.Abort();
            realTimeData_HTTPRequest.Callback = null;
        }

    }
}
