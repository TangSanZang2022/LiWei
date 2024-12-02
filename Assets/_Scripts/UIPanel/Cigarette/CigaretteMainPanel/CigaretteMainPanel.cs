using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tool;
using DG.Tweening;
namespace Cigarette
{
    /// <summary>
    /// 烟草主界面
    /// </summary>
    public class CigaretteMainPanel : BasePanel
    {
        /// <summary>
        /// 页面数据
        /// </summary>
        [SerializeField]
        private CigaretteMainPanelData cigaretteMainPanelData;
        /// <summary>
        /// 条码和客户名称预制体
        /// </summary>
        [SerializeField]
        private GameObject barCodeItemPrafab;
        private Transform barCodeContent;
        /// <summary>
        /// 存放条码的父物体
        /// </summary>
        private Transform BarCodeContent
        {
            get
            {
                if (barCodeContent == null)
                {
                    barCodeContent = transform.FindChildForName("BarCodeContent");
                }
                return barCodeContent;
            }
        }

        private Scrollbar barCodeScrollbarertical;
        /// <summary>
        /// 条码Scrollbar
        /// </summary>
        private Scrollbar BarCodeScrollbarertical
        {
            get
            {
                if (barCodeScrollbarertical == null)
                {
                    barCodeScrollbarertical = transform.FindChildForName("BarCodeScrollbarertical").GetComponent<Scrollbar>();
                }
                return barCodeScrollbarertical;
            }
        }

        [SerializeField]
        private GameObject AbnormalInformationItemPrafab;
        private Transform abnormalInformationContent;
        /// <summary>
        /// 存放条码的父物体
        /// </summary>
        private Transform AbnormalInformationContent
        {
            get
            {
                if (abnormalInformationContent == null)
                {
                    abnormalInformationContent = transform.FindChildForName("AbnormalInformationContent");
                }
                return abnormalInformationContent;
            }
        }

        private Scrollbar abnormalInformationScrollbarertical;
        /// <summary>
        /// 条码Scrollbar
        /// </summary>
        private Scrollbar AbnormalInformationScrollbarertical
        {
            get
            {
                if (abnormalInformationScrollbarertical == null)
                {
                    abnormalInformationScrollbarertical = transform.FindChildForName("AbnormalInformationScrollbarertical").GetComponent<Scrollbar>();
                }
                return abnormalInformationScrollbarertical;
            }
        }

        #region//订单信息
        private Text batchNoText;
        /// <summary>
        /// 批次
        /// </summary>
        private Text BatchNoText
        {
            get
            {
                if (batchNoText == null)
                {
                    batchNoText = transform.FindChildForName("BatchNoText").GetComponent<Text>();
                }
                return batchNoText;
            }
        }

        private Text countText;
        /// <summary>
        /// 数量
        /// </summary>
        private Text CountText
        {
            get
            {
                if (countText == null)
                {
                    countText = transform.FindChildForName("CountText").GetComponent<Text>();
                }
                return countText;
            }
        }

        private Text lineText;
        /// <summary>
        /// 线路
        /// </summary>
        private Text LineText
        {
            get
            {
                if (lineText == null)
                {
                    lineText = transform.FindChildForName("LineText").GetComponent<Text>();
                }
                return lineText;
            }
        }

        private Text countText_Line;
        /// <summary>
        /// 线路数量
        /// </summary>
        private Text CountText_Line
        {
            get
            {
                if (countText_Line == null)
                {
                    countText_Line = transform.FindChildForName("CountText_Line").GetComponent<Text>();
                }
                return countText_Line;
            }
        }

        private Text orderNoText;
        /// <summary>
        /// 订单号
        /// </summary>
        private Text OrderNoText
        {
            get
            {
                if (orderNoText == null)
                {
                    orderNoText = transform.FindChildForName("OrderNoText").GetComponent<Text>();
                }
                return orderNoText;
            }
        }

        private Text serialNoText;
        /// <summary>
        /// 顺序号
        /// </summary>
        private Text SerialNoText
        {
            get
            {
                if (serialNoText == null)
                {
                    serialNoText = transform.FindChildForName("SerialNoText").GetComponent<Text>();
                }
                return serialNoText;
            }
        }

        private Text clientNameText;
        /// <summary>
        /// 客户名称
        /// </summary>
        private Text ClientNameText
        {
            get
            {
                if (clientNameText == null)
                {
                    clientNameText = transform.FindChildForName("ClientNameText").GetComponent<Text>();
                }
                return clientNameText;
            }
        }

        private Text clientCodeText;
        /// <summary>
        /// 客户代码
        /// </summary>
        private Text ClientCodeText
        {
            get
            {
                if (clientCodeText == null)
                {
                    clientCodeText = transform.FindChildForName("ClientCodeText").GetComponent<Text>();
                }
                return clientCodeText;
            }
        }
        #endregion
        private JumpingNumberTextComponent markCount;
        /// <summary>
        /// 今日打码数
        /// </summary>
        private JumpingNumberTextComponent MarkCount
        {
            get
            {
                if (markCount == null)
                {
                    markCount = transform.FindChildForName("MarkCount").GetComponent<JumpingNumberTextComponent>();
                }
                return markCount;
            }
        }

        private JumpingNumberTextComponent errorCount;
        /// <summary>
        /// 今日异常数
        /// </summary>
        private JumpingNumberTextComponent ErrorCount
        {
            get
            {
                if (errorCount == null)
                {
                    errorCount = transform.FindChildForName("ErrorCount").GetComponent<JumpingNumberTextComponent>();
                }
                return errorCount;
            }
        }

        private Text completeRateText;
        /// <summary>
        /// 订单完成率
        /// </summary>
        private Text CompleteRateText
        {
            get
            {
                if (completeRateText == null)
                {
                    completeRateText = transform.FindChildForName("CompleteRateText").GetComponent<Text>();
                }
                return completeRateText;
            }
        }

        private Text errorRateText;
        /// <summary>
        /// 订单异常率
        /// </summary>
        private Text ErrorRateText
        {
            get
            {
                if (errorRateText == null)
                {
                    errorRateText = transform.FindChildForName("ErrorRateText").GetComponent<Text>();
                }
                return errorRateText;
            }
        }
        #region//订单进度

        #endregion
        public override void OnEnter()
        {
            gameObject.SetActive(true);
            // StartCoroutine(ICreate_barCodeItem());
            //StartCoroutine(ICreate_barCodeItem_Count(7));
           // StartCoroutine(ICreate_abnormalInformationItem_Count(7));
        }

        public override void OnPause()
        {
            gameObject.SetActive(false);
        }

        public override void OnResume()
        {
            gameObject.SetActive(true);
        }

        public override void OnExit()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// 更新面板
        /// </summary>
        /// <param name="panelData"></param>
        public override void UpdatePanelData(object panelData)
        {
            base.UpdatePanelData(panelData);
            Debug.Log(panelData);

            cigaretteMainPanelData = panelData as CigaretteMainPanelData;
            Debug.Log(cigaretteMainPanelData);
            Update_barCodeItem(cigaretteMainPanelData.marks);
            Update_abnormalInformationItem(cigaretteMainPanelData.errorLogs);
            Update_OrderInfo(cigaretteMainPanelData.orderInfo);
            Update_OrderProgress(cigaretteMainPanelData.orderProgress);
        }


        /// <summary>
        /// 更新条码
        /// </summary>
        /// <param name="marks"></param>
        private void Update_barCodeItem(List<Marks> marks)
        {
            for (int i = 0; i < BarCodeContent.childCount; i++)//先删除
            {
                int index = i;
                GameObject.Destroy(BarCodeContent.GetChild(index).gameObject);
            }
            foreach (Marks item in marks)
            {
                BarCodeItem barCodeItem = GameObject.Instantiate(barCodeItemPrafab, BarCodeContent).GetComponent<BarCodeItem>();
                BarCodeScrollbarertical.value = 0;
                //barCodeItem.Set_NameNum(item.GetTime(), item.pbarcode);
             
                barCodeItem.Set_NameNum(item.clientName, item.pbarcode.Insert(16, "\n"));
            }
        }
        /// <summary>
        /// 更新异常信息
        /// </summary>
        /// <param name="errorLogs"></param>
        private void Update_abnormalInformationItem(List<errorLogs> errorLogs)
        {
            for (int i = 0; i < AbnormalInformationContent.childCount; i++)//先删除
            {
                int index = i;
                GameObject.Destroy(AbnormalInformationContent.GetChild(index).gameObject);
            }
            foreach (errorLogs item in errorLogs)
            {
                AbnormalInformationItem abnormalInformationItem = GameObject.Instantiate(AbnormalInformationItemPrafab, AbnormalInformationContent).GetComponent<AbnormalInformationItem>();
                AbnormalInformationScrollbarertical.value = 0;
                abnormalInformationItem.SetValue(item);
            }
        }
        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        private void Update_OrderInfo(OrderInfo orderInfo)
        {
            BatchNoText.text = orderInfo.batchNo;
            CountText.text = orderInfo.count;
            LineText.text = orderInfo.line;
            CountText_Line.text = orderInfo.count;
            OrderNoText.text = orderInfo.orderNo;
            SerialNoText.text = orderInfo.serialNo;
            ClientNameText.text = orderInfo.clientName;
            ClientCodeText.text = orderInfo.clientCode;
        }
        /// <summary>
        /// 更新订单进度
        /// </summary>
        /// <param name="orderProgress"></param>
        private void Update_OrderProgress(OrderProgress orderProgress)
        {
            MarkCount.number = int.Parse(orderProgress.markCount);
            ErrorCount.number = int.Parse(orderProgress.errorCount);
            CompleteRateText.GetComponent<AniText>().Set_endValue(int.Parse(orderProgress.completeRate.Remove(orderProgress.completeRate.Length-1,1)));
            ErrorRateText.GetComponent<AniText>().Set_endValue(int.Parse(orderProgress.errorRate.Remove(orderProgress.errorRate.Length - 1, 1)));
        }

        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        int i = UnityEngine.Random.Range(1, 101);
        //        int j = UnityEngine.Random.Range(1, 101);
        //        CompleteRateText.GetComponent<AniText>().Set_endValue(i);
        //        ErrorRateText.GetComponent<AniText>().Set_endValue(j);
        //    }
        //}
        /// <summary>
        /// Text文字变动效果
        /// </summary>
        /// <param name="text"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        IEnumerator INumChangeAni(Text text, int num)
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
        private IEnumerator ICreate_barCodeItem()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                BarCodeItem barCodeItem = GameObject.Instantiate(barCodeItemPrafab, BarCodeContent).GetComponent<BarCodeItem>();
                BarCodeScrollbarertical.value = 0;
                string[] res = Get_BarCodeItemValue();
                barCodeItem.Set_NameNum(res[0], res[1]);
            }
        }
        /// <summary>
        /// 创建固定数量的条码
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private IEnumerator ICreate_barCodeItem_Count(int count)
        {
            while (BarCodeContent.childCount <= count)
            {
                yield return new WaitForSeconds(0.1f);
                BarCodeItem barCodeItem = GameObject.Instantiate(barCodeItemPrafab, BarCodeContent).GetComponent<BarCodeItem>();
                BarCodeScrollbarertical.value = 0;
                string[] res = Get_BarCodeItemValue();
                barCodeItem.Set_NameNum(res[0], res[1]);

            }
            StartCoroutine(IUpdateAllbarCodeItem());
        }
        /// <summary>
        /// 更新每个条码
        /// </summary>
        /// <returns></returns>
        private IEnumerator IUpdateAllbarCodeItem()
        {
            while (true)
            {
                for (int i = 0; i < BarCodeContent.childCount; i++)
                {
                    int index = i;
                    BarCodeItem barCodeItem = BarCodeContent.GetChild(index).GetComponent<BarCodeItem>();
                    string[] res = Get_BarCodeItemValue();
                    barCodeItem.Set_NameNum(res[0], res[1]);
                }
                yield return new WaitForSeconds(0.1f);
            }

        }
        /// <summary>
        /// 顺序号
        /// </summary>
        int orderNum = 0;
        /// <summary>
        /// 获取随机条码
        /// </summary>
        /// <returns></returns>
        private string[] Get_BarCodeItemValue()
        {
            string[] res = new string[2];
            res[0] = "浦江县青天副食店";
            //分拣日期(5位)
            string data = DateTime.Now.ToString("yyyyMMdd");
            //data = data.Replace('/', ' ');
            //data= data.Trim();
            data = data.Remove(0, 3);

            //件烟序列号（9位）
            string serial = UnityEngine.Random.Range(100000000, 1000000000).ToString();

            //01-50顺序号（2位）
            string newOrderNum = orderNum.ToString();
            if (newOrderNum.Length < 2)
            {
                newOrderNum = "0" + newOrderNum;
            }
            orderNum++;
            if (orderNum < 0 || orderNum > 50)
            {
                orderNum = 0;
            }

            //自定义信息（4位）
            string customInfo = UnityEngine.Random.Range(1000, 10000).ToString();

            //零售户信息（12位）
            string retailAccountInformation = "251453258971";


            string allRes = data + serial + newOrderNum + customInfo + retailAccountInformation;
            allRes = allRes.Insert(16, "\n");
            res[1] = allRes;

            return res;
        }


        /// <summary>
        /// 创建固定数量的异常信息
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private IEnumerator ICreate_abnormalInformationItem_Count(int count)
        {
            while (AbnormalInformationContent.childCount <= count)
            {
                yield return new WaitForSeconds(0.02f);
                AbnormalInformationItem abnormalInformationItem = GameObject.Instantiate(AbnormalInformationItemPrafab, AbnormalInformationContent).GetComponent<AbnormalInformationItem>();
                AbnormalInformationScrollbarertical.value = 0;
                //string[] res = Get_BarCodeItemValue();
                // abnormalInformationItem.Set_NameNum(res[0], res[1]);

            }
            // StartCoroutine(IUpdateAllabnormalInformationItem());
        }
        /// <summary>
        /// 更新每个异常信息
        /// </summary>
        /// <returns></returns>
        private IEnumerator IUpdateAllabnormalInformationItem()
        {
            while (true)
            {
                for (int i = 0; i < AbnormalInformationContent.childCount; i++)
                {
                    int index = i;
                    AbnormalInformationItem abnormalInformationItem = AbnormalInformationContent.GetChild(index).GetComponent<AbnormalInformationItem>();
                    abnormalInformationItem.SetValue(Get_abnormalInformationItemValue());
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

        private errorLogs Get_abnormalInformationItemValue()
        {
            errorLogs abnormalInformationItemData = new errorLogs();
            //abnormalInformationItemData.OrderNumberText = UnityEngine.Random.Range(10000, 100000).ToString() + "\n" 
            //    + UnityEngine.Random.Range(1000000, 10000000).ToString();
            //abnormalInformationItemData.SequenceNumberText = UnityEngine.Random.Range(0, 1000).ToString();
            //abnormalInformationItemData.NameText= "浦江县青天副食店";
            //abnormalInformationItemData.TimeText = TimeTool.GetNowTime();
            //abnormalInformationItemData.TypeText = "指令错误";
            return abnormalInformationItemData;
        }
    }
}
/// <summary>
/// 烟草主页面数据
/// </summary>
[Serializable]
public class CigaretteMainPanelData
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public OrderInfo orderInfo;
    /// <summary>
    /// 订单进度
    /// </summary>
    public OrderProgress orderProgress;
    /// <summary>
    /// 打码信息
    /// </summary>
    public List<Marks> marks;
    /// <summary>
    /// 
    /// </summary>
    public List<errorLogs> errorLogs;
}
/// <summary>
/// 订单信息
/// </summary>
[Serializable]
public class OrderInfo
{
    /// <summary>
    /// 批次
    /// </summary>
    public string batchNo;
    /// <summary>
    /// 数量
    /// </summary>
    public string count;
    /// <summary>
    /// 线路
    /// </summary>
    public string line;
    /// <summary>
    /// 订单号
    /// </summary>
    public string orderNo;
    /// <summary>
    /// 顺序号
    /// </summary>
    public string serialNo;
    /// <summary>
    /// 客户名称
    /// </summary>
    public string clientName;
    /// <summary>
    /// 客户代码
    /// </summary>
    public string clientCode;
}
/// <summary>
/// 订单进度
/// </summary>
[Serializable]
public class OrderProgress
{
    /// <summary>
    /// 今日打码数
    /// </summary>
    public string markCount;
    /// <summary>
    /// 今日异常数
    /// </summary>
    public string errorCount;
    /// <summary>
    /// 订单完成率
    /// </summary>
    public string completeRate;
    /// <summary>
    /// 今日异常率
    /// </summary>
    public string errorRate;
}
/// <summary>
/// 打码信息
/// </summary>
[Serializable]
public class Marks
{
    /// <summary>
    /// 时间
    /// </summary>
    public string timestamp;
    /// <summary>
    /// 客户名称
    /// </summary>
    public string clientName;
    /// <summary>
    /// 条码
    /// </summary>
    public string pbarcode;

    public string GetTime()
    {
        return TimeTool.TimeStamp2DateTime_String(long.Parse(timestamp), 0, false);
    }
}


