using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
/// <summary>
/// Unity中的监控
/// </summary>
namespace UnityMonitor
{
    /// <summary>
    /// 摄像头基类
    /// </summary>
    public class BaseMonitor : OperationalObj
    {
        [SerializeField]
        /// <summary>
        /// 监控的地址，从服务器获取
        /// </summary>
        private string rtspURL;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// 设置RtspURL
        /// </summary>
        /// <param name="url"></param>
        public void SetRtspURL(string url)
        {
            rtspURL = url;
        }

        /// <summary>
        /// 获取RtspURL 
        /// </summary>
        /// <returns></returns>
        public string GetRtspURL()
        {
            return rtspURL;
        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        protected override void MouseEnterHandle()
        {
            base.MouseEnterHandle();
        }

        /// <summary>
        /// 鼠标按下
        /// </summary>
        protected override void MouseDownHandle()
        {
            base.MouseDownHandle();
            MonitorOn();
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        protected override void MouseExitHandle()
        {
            base.MouseExitHandle();
        }

        /// <summary>
        /// 打开摄像头
        /// </summary>
        public virtual void MonitorOn()
        {

        }

        /// <summary>
        /// 关闭摄像头
        /// </summary>
        public virtual void MonitorOff()
        {

        }
    }
}
/// <summary>
/// 摄像头id和播放路径配置列表
/// </summary>
[Serializable]
public class MonitorDataList
{
    /// <summary>
    /// 响应类型，为2的时候表示为摄像头
    /// </summary>
    public string ActionCode;
    /// <summary>
    /// 摄像头具体ID对应的播放路径
    /// </summary>

    public List<MonitorData> Data;
}
/// <summary>
/// 摄像头id和播放路径配置
/// </summary>
[Serializable]
public class MonitorData
{
    /// <summary>
    /// 摄像头ID
    /// </summary>
    public string id;
    /// <summary>
    /// 播放地址
    /// </summary>
    public string path;

}