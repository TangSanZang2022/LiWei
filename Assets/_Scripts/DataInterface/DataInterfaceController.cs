using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tool;
using BestHTTP;
using LitJson;

namespace DFDJ
{
    public enum HTTPRequestType
    {
        /// <summary>
        /// 获取设备、采集项信息接口
        /// </summary>
        DeviceCollectionItemInformation,
        /// <summary>
        /// 获取实时工艺参数信息接口
        /// </summary>
        RealTimeData,
        /// <summary>
        /// 获取历史采集项信息接口
        /// </summary>
        HistoryData,
        /// <summary>
        /// 获取设备实时状态信息接口
        /// </summary>
        RealTimeStatusOfEquipment,
        /// <summary>
        /// 设备切片百分比
        /// </summary>
        EqupmentSliceData,
        /// <summary>
        /// 能耗
        /// </summary>
        EnergyConsumptionData,
        /// <summary>
        /// 近七天生产效率
        /// </summary>
        ProductionEfficiencyData,
        /// <summary>
        /// 刀具状态数据
        /// </summary>
        ToolStateData
    }
    /// <summary>
    /// 数据接口控制器
    /// </summary>
    public class DataInterfaceController : BaseController
    {
        public DataInterfaceController(GameFacade gameFacade) : base(gameFacade)
        {
            DataInterfaceConfig = XmlController.ReadJson<DataInterfaceConfig>("", Application.streamingAssetsPath + "/DataInterfaceConfig.txt");
            Debug.Log(DataInterfaceConfig.DeviceCollectionItemInformation);


            // RealTimePosDataList realTimeDataDataList=  XmlController.ReadJson<RealTimePosDataList>("", Application.streamingAssetsPath + "/RealTimeData.txt");
            //foreach (var item in realTimeDataDataList.data)
            //{
            //    foreach (var item1 in item)
            //    {
            //        Debug.Log(item1);
            //    }
            //}


        }
        /// <summary>
        /// 读取到的数据接口
        /// </summary>
        public DataInterfaceConfig DataInterfaceConfig
        {
            get;
            private set;
        }
        /// <summary>
        /// 获取HTTPRequest地址
        /// </summary>
        /// <param name="hTTPRequestType">HTTPRequest类型</param>
        /// <param name="sign">签名</param>
        /// <param name="device">设备编号</param>
        /// <param name="item">设备采集码编号</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public string GetHTTPRequestPath(HTTPRequestType hTTPRequestType, string sign, string device, string item, string start, string end)
        {
            string interfacePath = "";
            switch (hTTPRequestType)
            {
                case HTTPRequestType.DeviceCollectionItemInformation:
                    interfacePath = DataInterfaceConfig.DeviceCollectionItemInformation + string.Format("?username={0}&sign={1}", DataInterfaceConfig.Username, sign);
                    break;
                case HTTPRequestType.RealTimeData:
                    interfacePath = DataInterfaceConfig.RealTimeData + string.Format("?username={0}&sign={1}&device={2}&item={3}", DataInterfaceConfig.Username, sign, device, item);
                    break;
                case HTTPRequestType.HistoryData:
                    interfacePath = DataInterfaceConfig.HistoryData + string.Format("?username={0}&sign={1}&device={2}&item={3}&start={4}&end={5}", DataInterfaceConfig.Username, sign, device, item, start, end);
                    break;
                case HTTPRequestType.RealTimeStatusOfEquipment:
                    interfacePath = DataInterfaceConfig.RealTimeStatusOfEquipment + string.Format("?username={0}&sign={1}&device={2}", DataInterfaceConfig.Username, sign, device);
                    break;
                case HTTPRequestType.EqupmentSliceData:
                    interfacePath= DataInterfaceConfig.EqupmentSliceData+ string.Format("?username={0}&sign={1}&devices={2}", DataInterfaceConfig.Username, sign, device);
                    break;
                case HTTPRequestType.EnergyConsumptionData:
                    interfacePath = DataInterfaceConfig.EnergyConsumptionData + string.Format("?username={0}&sign={1}&devices={2}&type=device&dateType=month&start={3}&end={4}", DataInterfaceConfig.Username, sign, device,start,end);
                    break;
                case HTTPRequestType.ProductionEfficiencyData:
                    interfacePath = DataInterfaceConfig.ProductionEfficiencyData + string.Format("?username={0}&sign={1}&devices={2}&dateType=day&start={3}&end={4}", DataInterfaceConfig.Username, sign, device, start, end);
                    break;
                case HTTPRequestType.ToolStateData:
                    interfacePath = DataInterfaceConfig.ToolStateData + string.Format("?username={0}&sign={1}&device={2}", DataInterfaceConfig.Username, sign, device);
                    break;
                default:
                    break;
            }
            return interfacePath;
        }
    }
    [Serializable]
    /// <summary>
    /// 读取接口配置解析类
    /// </summary>
    public class DataInterfaceConfig
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password;
        /// <summary>
        /// 获取设备、采集项信息接口
        /// </summary>
        public string DeviceCollectionItemInformation;
        /// <summary>
        /// 获取实时工艺参数信息接口
        /// </summary>
        public string RealTimeData;
        /// <summary>
        /// 获取历史采集项信息接口
        /// </summary>
        public string HistoryData;
        /// <summary>
        /// 获取设备实时状态信息接口
        /// </summary>
        public string RealTimeStatusOfEquipment;
        /// <summary>
        /// 设备切片百分比接口
        /// </summary>
        public string EqupmentSliceData;
        /// <summary>
        /// 能耗接口
        /// </summary>
        public string EnergyConsumptionData;
        /// <summary>
        /// 近七天生产效率
        /// </summary>
        public string ProductionEfficiencyData;
        /// <summary>
        /// 刀具状态接口
        /// </summary>
        public string ToolStateData;
        /// <summary>
        /// 设备ID
        /// </summary>
        public string Device;
        /// <summary>
        /// 要拿到的字段
        /// </summary>
        public string Item;

        public string Start;

        public string End;
    }
    [Serializable]
    public class DeviceCollectionItemInformationDataList
    {
        public string code;
        public string msg;
        public List<DeviceCollectionItemInformationData> data = new List<DeviceCollectionItemInformationData>();
    }
    /// <summary>
    /// 获取设备、采集项信息数据
    /// </summary>
    [Serializable]
    public class DeviceCollectionItemInformationData
    {
        /// <summary>
        /// 设备ID
        /// </summary>
        public string device_no;
        /// <summary>
        /// 设备名称
        /// </summary>
        public string device_name;
        /// <summary>
        /// 设备工艺参数code
        /// </summary>
        public string item_code;
        /// <summary>
        /// 设备工艺参数名称
        /// </summary>
        public string item_name;
        /// <summary>
        /// 单位
        /// </summary>
        public string unit;
    }
    /// <summary>
    /// 检测是否收到数据
    /// </summary>
    [Serializable]
    public class RealTimeDataListCheck
    {
        public int code;
        public string msg;
    }
    /// <summary>
    /// 数据信息解析类
    /// </summary>
    [Serializable]
    public class RealTimeDataList
    {
        public int code;
        public string msg;
        public JsonData data;


    }
    /// <summary>
    /// 获取实时工艺参数信息数据
    /// </summary>
    [Serializable]
    public class RealTimePosData
    {
        public string absolutePosition_y;
        public string absolutePosition_x;
        public string absolutePosition_z;

        /// <summary>
        /// 天桥铣C
        /// </summary>
        public string CPOSAxis6;
        /// <summary>
        /// 天桥铣W
        /// </summary>
        public string WPOSAxis5;
        /// <summary>
        /// 天桥铣Z
        /// </summary>
        public string ZPOSAxis3;
        /// <summary>
        /// 天桥铣Y
        /// </summary>
        public string YPOSAxis2;
        /// <summary>
        /// 天桥铣X
        /// </summary>
        public string XPOSAxis1;
        /// <summary>
        /// 主轴转速
        /// </summary>
        public string spindleSpeed;
    }

    /// <summary>
    /// 历史数据解析类
    /// </summary>
    [Serializable]
    public class HistoryDataDataList
    {
        public int code;
        public string msg;
        public List<HistoryDataData> data = new List<HistoryDataData>();
    }
    /// <summary>
    /// 获取历史采集项信息
    /// </summary>
    [Serializable]
    public class HistoryDataData
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string time;



    }

    [Serializable]
    public class RealTimeStatusOfEquipmentDataList
    {

    }
    /// <summary>
    /// 获取设备实时状态信息数据
    /// </summary>
    [Serializable]
    public class RealTimeStatusOfEquipmentData
    {
        /// <summary>
        /// 机床状态，用于判断机床上的灯的颜色
        /// </summary>
        public string s_level_state;
        /// <summary>
        /// 根据得到的s_level_state来获取状态中文名
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetState()
        {
            string stateContent = "";
            switch (s_level_state)
            {
                case "s_shutdown":
                    stateContent = "关机";
                    break;
                case "s_fault":
                    stateContent = "故障停机";
                    break;
                case "s_alarm":
                    stateContent = "报警";
                    break;
                case "s_standby":
                    stateContent = "待机";
                    break;
                case "s_run":
                    stateContent = "运行";
                    break;
                default:
                    break;
            }
            return stateContent;
        }


        //        {
        //    "code": 200,
        //    "msg": "操作成功",
        //    "data": {
        //        "001077": {
        //            "f_level_state": "t_shutdown",
        //            "s_level_state": "s_shutdown",
        //            "slice_state": "t_shutdown",
        //            "v_date": "2022-01-13 09:56:01"
        //        }
        //    }
        //}
    }
    /// <summary>
    /// 刀具数据解析类列表
    /// </summary>
    public class ToolStateDataList
    {
        public int code;
        public string msg;
        public ToolStateData data;
    }

    /// <summary>
    /// 刀具数据解析类
    /// </summary>
    [Serializable]
    public class ToolStateData
    {
        /// <summary>
        /// 刀具编号
        /// </summary>
        public int Tool_Num;
        /// <summary>
        /// 刀具状态
        /// </summary>
        public int Tool_State;
        /// <summary>
        /// 刀具负载
        /// </summary>
        public List<double> Load_Tool = new List<double>();
        /// <summary>
        /// 破损上线
        /// </summary>
        public List<double> Brok_Upper = new List<double>();
        /// <summary>
        /// 破损下线
        /// </summary>
        public List<double> Brok_Lower = new List<double>();
        /// <summary>
        /// 过载阈值
        /// </summary>
        public List<double> Overload = new List<double>();
        /// <summary>
        /// 磨损度
        /// </summary>
        public int Wear_Perc;
        /// <summary>
        /// 磨损度阈值,磨损门限值的50%变黄，80%变浅红，超过磨损门限变深红
        /// </summary>
        public int Wear_Thre;
        /// <summary>
        /// 时间
        /// </summary>
        public string time;
    }
}
