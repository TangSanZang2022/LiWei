using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using LitJson;

/// <summary>
/// 配置文件控制器
/// </summary>
public class XmlController : BaseController
{
    public XmlController(GameFacade gameFacade) : base(gameFacade)
    { }
    /// <summary>
    /// 服务器相关配置
    /// </summary>
    public NetConfig NetConfig
    {
        get;
        private set;
    }
    /// <summary>
    /// 皮带上摄像头配置列表
    /// </summary>
    public List<ConveyorBeltMonitorData> ConveyorBeltMonitorData
    {
        get;
        private set;
    }
    /// <summary>
    /// 初始化
    /// </summary>
    public override void OnInit()
    {
        base.OnInit();
        //ReadXml();
        //ReadConveyorBeltMonitorConfig();
        //ReadMoveObjDataConfig();
        //ReadPoliceInfos();
        //sdsd;
    }

     /// <summary>
     /// 创建配置文件
     /// </summary>
    private void CreateXml()
    {
        string path = Application.streamingAssetsPath + @"/NetConfig.xml";
        if (!File.Exists(path))
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("NetPath");
            XmlElement httpServerPath = xmlDoc.CreateElement("HttpServerPath");
            //httpServerPath.InnerText = "1aa";
            httpServerPath.SetAttribute("HttpPath", "www");
            httpServerPath.SetAttribute("Other", "aaa");

            XmlElement monitorPath = xmlDoc.CreateElement("MonitorPath");
            monitorPath.SetAttribute("Path", "www.ww");
            monitorPath.SetAttribute("bodyJson", "sasada");
            root.AppendChild(httpServerPath);
            root.AppendChild(monitorPath);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(path);
            Debug.Log("XML保存成功" + path);
        }
    }
    /// <summary>
    /// 读取Json泛型方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static T ReadJson<T>(string json, string path = null)
    {
        if (path != null) //如果有路径，则为本地读取
        {
            string localJson = File.ReadAllText(path);
            json = localJson;

        }
        Debug.Log(json);
        T resT = JsonUtility.FromJson<T>(json.Trim());
        return resT;
    }

    public static T ReadJsonForLitJson<T>(string json, string path = null)
    {
        if (path != null) //如果有路径，则为本地读取
        {
            string localJson = File.ReadAllText(path);
            json = localJson;

        }
        Debug.Log(json);
        //T resT = JsonUtility.FromJson<T>(json.Trim());
        T resT = JsonMapper.ToObject<T>(json);
        return resT;
    }
    public static T ReadJsonForLitJson<T>(JsonData json)
    {
        //T resT = JsonUtility.FromJson<T>(json.Trim());
        T resT = JsonMapper.ToObject<T>(json.ToJson());
        return resT;
    }
    /// <summary>
    /// 泛型类将Json转换为需要用到的对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    public static T ReadJson<T>(string json)
    {
        T resT = JsonUtility.FromJson<T>(json.Trim());
        return resT;
    }
    /// <summary>
    ///  读取皮带上摄像头的配置，并获取摄像头配置列表
    /// </summary>
    private void ReadConveyorBeltMonitorConfig()
    {
        string path = Application.streamingAssetsPath + @"//ConveyorBeltMonitorConfig.txt";
        if (!File.Exists(path))
        {
            FileStream fs = File.Create(path);
            fs.Close();
        }
        string json = File.ReadAllText(path);
        ConveyorBeltMonitorDataList dataList = JsonUtility.FromJson<ConveyorBeltMonitorDataList>(json);
        if (dataList == null)
        {
            ConveyorBeltMonitorData = new List<ConveyorBeltMonitorData>();
        }
        else
        {
            ConveyorBeltMonitorData = dataList.data;
        }

        Debug.Log(string.Format("读取ConveyorBeltMonitorConfig.txt成功"));

    }
    /// <summary>
    ///  读取物体位置信息数据
    /// </summary>
    private void ReadMoveObjDataConfig()
    {

       // string path = Application.streamingAssetsPath + @"//MoveObjData.txt";
        //MoveObjDataList moveObjDatas = ReadJson<MoveObjDataList>(null, path);
        //facade.UpdateAllMoveObjPos(moveObjDatas.moveObjDatas);

    }
     /// <summary>
     ///  读取物体介绍UI信息配置
     /// </summary>
    public void ReadPoliceInfos()
    {
        string path = Application.streamingAssetsPath + @"//PoliceInfos.txt";
        PoliceInfos policeInfos  = ReadJson<PoliceInfos>(null, path);
        foreach (PoliceInfo item in policeInfos.PoliceInfoList)
        {
            facade.SetBaseInfo(item);
        }

        string path1 = Application.streamingAssetsPath + @"//FactFinderInfos.txt";
        FactFinderInfos actFinderInfos = ReadJson<FactFinderInfos>(null, path1);
        foreach (FactFinderInfo item in actFinderInfos.FactFinderInfoList)
        {
            facade.SetBaseInfo(item);
        }

    }

    /// <summary>
    ///  将皮带上摄像头的配置写到本地
    /// </summary>
    public void WriteConveyorBeltMonitorConfig(string json)
    {
        string path = Application.streamingAssetsPath + @"//ConveyorBeltMonitorConfig.txt";
        if (!File.Exists(path))
        {
            FileStream fs = File.Create(path);
            fs.Close();
        }
        if (File.ReadAllText(path) == json)
        {
            Debug.Log(string.Format("json相同，无需更新"));
            return;
        }
        File.WriteAllText(path, json);
        ConveyorBeltMonitorDataList dataList = JsonUtility.FromJson<ConveyorBeltMonitorDataList>(json);
        ConveyorBeltMonitorData = dataList.data;
        Debug.Log(string.Format("更新ConveyorBeltMonitorConfig.txt成功"));
    }
    /// <summary>
    /// 读取XML
    /// </summary>
    private void ReadXml()
    {
        NetConfig = new NetConfig();
        string path = Application.streamingAssetsPath + @"//NetConfig.xml";
        if (File.Exists(path))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("NetPath").ChildNodes;
            foreach (XmlElement xe in xmlNodeList)
            {
                if (xe.Name == "HttpServerPath")
                {
                    NetConfig.HttpServerPath = xe.GetAttribute("HttpServerPath");
                    NetConfig.HttpServerOther = xe.GetAttribute("HttpServerOther");
                }
                else if (xe.Name == "MonitorRequestPath")
                {
                    NetConfig.MonitorRequestPath = xe.GetAttribute("MonitorRequestPath");
                    NetConfig.MonitorRequestBodyJson = xe.GetAttribute("MonitorRequestBodyJson");
                }
            }
        }
    }
}

/// <summary>
/// 服务器相关配置
/// </summary>
public class NetConfig
{
    /// <summary>
    /// 被监听的服务器的地址
    /// </summary>
    public string HttpServerPath { get; set; }

    /// <summary>
    ///关于被监听服务器的其他配置，备用
    /// </summary>
    public string HttpServerOther { get; set; }

    /// <summary>
    /// 监控请求的路径
    /// </summary>
    public string MonitorRequestPath { get; set; }

    /// <summary>
    /// 监控请求的BodyJson
    /// </summary>
    public string MonitorRequestBodyJson { get; set; }
}
