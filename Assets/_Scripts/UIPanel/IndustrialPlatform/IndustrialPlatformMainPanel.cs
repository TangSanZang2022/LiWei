using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using Tool;
using XCharts;
using System;
/// <summary>
/// 月台
/// </summary>
namespace IndustrialPlatform
{
    /// <summary>
    /// 月台主界面
    /// </summary>
    public class IndustrialPlatformMainPanel : BasePanel
    {
        [SerializeField]
        /// <summary>
        /// 实时车辆预制体
        /// </summary>
        private RealTimeCarItem realTimeCarItemPtrfab;
        [SerializeField]
        /// <summary>
        /// 空闲月台预制体
        /// </summary>
        private FreePlatformItem freePlatformItemPtrfab;
        [SerializeField]
        /// <summary>
        /// 已出库件数预制体
        /// </summary>
        private OutboundNumItem outboundNumItemPtrfab;

        private Transform realTimeCarContent;
        /// <summary>
        /// 实时车辆父物体
        /// </summary>
        private Transform RealTimeCarContent
        {
            get
            {
                if (realTimeCarContent == null)
                {
                    realTimeCarContent = transform.FindChildForName("RealTimeCarContent");
                }
                return realTimeCarContent;
            }
        }
        private Transform freePlatformContent;
        /// <summary>
        /// 空闲月台
        /// </summary>
        private Transform FreePlatformContent
        {
            get
            {
                if (freePlatformContent == null)
                {
                    freePlatformContent = transform.FindChildForName("FreePlatformContent");
                }
                return freePlatformContent;
            }
        }
        private Transform outboundNumContent;
        /// <summary>
        /// 已出库父物体
        /// </summary>
        private Transform OutboundNumContent
        {
            get
            {
                if (outboundNumContent == null)
                {
                    outboundNumContent = transform.FindChildForName("OutboundNumContent");
                }
                return outboundNumContent;
            }
        }


        private AniText loadingVehiclesText;
        /// <summary>
        /// 当前在装载车辆
        /// </summary>
        private AniText LoadingVehiclesText
        {
            get
            {
                if (loadingVehiclesText == null)
                {
                    loadingVehiclesText = transform.FindChildForName("LoadingVehiclesText").GetComponent<AniText>();
                }
                return loadingVehiclesText;
            }
        }

        private AniText idlePlatformText;
        /// <summary>
        /// 当前空闲月台
        /// </summary>
        private AniText IdlePlatformText
        {
            get
            {
                if (idlePlatformText == null)
                {
                    idlePlatformText = transform.FindChildForName("IdlePlatformText").GetComponent<AniText>();
                }
                return idlePlatformText;
            }
        }

        private AniText completeOrderText;
        /// <summary>
        /// 完成单据数
        /// </summary>
        private AniText CompleteOrderText
        {
            get
            {
                if (completeOrderText == null)
                {
                    completeOrderText = transform.FindChildForName("CompleteOrderText").GetComponent<AniText>();
                }
                return completeOrderText;
            }
        }
        private AniText loadedVehiclesText;
        /// <summary>
        /// 已装载车辆数
        /// </summary>
        private AniText LoadedVehiclesText
        {
            get
            {
                if (loadedVehiclesText == null)
                {
                    loadedVehiclesText = transform.FindChildForName("LoadedVehiclesText").GetComponent<AniText>();
                }
                return loadedVehiclesText;
            }
        }
        private PieChart warehouseShipmentRatioPiechart;
        /// <summary>
        /// 库区出货占比
        /// </summary>
        private PieChart WarehouseShipmentRatioPiechart
        {
            get
            {
                if (warehouseShipmentRatioPiechart == null)
                {
                    warehouseShipmentRatioPiechart = transform.FindChildForName("WarehouseShipmentRatioPiechart").GetComponent<PieChart>();
                }
                return warehouseShipmentRatioPiechart;
            }
        }

        private Text one;
        /// <summary>
        /// 库区1
        /// </summary>
        private Text One
        {
            get
            {
                if (one == null)
                {
                    one = transform.FindChildForName("One").GetComponent<Text>();
                }
                return one;
            }
        }
        private Text two;
        /// <summary>
        /// 库区2
        /// </summary>
        private Text Two
        {
            get
            {
                if (two == null)
                {
                    two = transform.FindChildForName("Two").GetComponent<Text>();
                }
                return two;
            }
        }
        private Text three;
        /// <summary>
        /// 库区3
        /// </summary>
        private Text Three
        {
            get
            {
                if (three == null)
                {
                    three = transform.FindChildForName("Three").GetComponent<Text>();
                }
                return three;
            }
        }


        private int totalNum = 10000;
        private AniText totalText;
        /// <summary>
        /// 总出货
        /// </summary>
        private AniText TotalText
        {
            get
            {
                if (totalText == null)
                {
                    totalText = transform.FindChildForName("TotalText").GetComponent<AniText>();
                }
                return totalText;
            }
        }
        
        public int[] OrderNum = new int[] { 10, 10 };
        public override void OnEnter()
        {
            base.OnEnter();
            TotalText.GetComponent<Text>().text = totalNum.ToString();
            StartCoroutine(IUpdateData(1));
            StartCoroutine(IUpdateDataPie(10));
            // UpdateRealTimeCarContentTest();
            // UpdateRealTimeCarContent(GameFacade.Instance.GetRealTimeCarItemDatas());
            UpdateFreePlatformContentTest();
            UpdateOutboundNumContentTest();
            //UpdateCarNum(new int[] { Random.Range(0, 20), Random.Range(0, 10) });
            UpdateOrderNum(OrderNum);
           ;
            UpdateWarehouseShipmentRatio(new float[] { (float)Math.Round(Convert.ToDouble(UnityEngine.Random.Range(0.0f, 1.0f)),2),
                (float)Math.Round(Convert.ToDouble(UnityEngine.Random.Range(0.0f, 1.0f)), 2) ,
                (float)Math.Round(Convert.ToDouble(UnityEngine.Random.Range(0.0f, 1.0f)), 2) });
        }

        public override void OnPause()
        {
            base.OnPause();
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void UpdatePanelData(object panelData)
        {
            base.UpdatePanelData(panelData);
        }
        /// <summary>
        /// 更新车辆
        /// </summary>
        /// <param name="realTimeCarItemDatas"></param>
        public void UpdateRealTimeCarContent(List<RealTimeCarItemData> realTimeCarItemDatas)
        {
            for (int i = 0; i < RealTimeCarContent.childCount; i++)//删除
            {
                int index = i;
                Destroy(RealTimeCarContent.GetChild(index).gameObject);
            }
            for (int i = realTimeCarItemDatas.Count-1; i >=0; i--)
            {
                int index = i;
                RealTimeCarItem realTimeCarItem = Instantiate(realTimeCarItemPtrfab, RealTimeCarContent);//创建
                realTimeCarItem.SetData(realTimeCarItemDatas[index]);
                realTimeCarItem.SetColor(index + 1);
            }
        }
        /// <summary>
        /// 更新空闲月台
        /// </summary>
        /// <param name="freePlatformItemDatas"></param>
        public void UpdateFreePlatformContent(List<FreePlatformItemData> freePlatformItemDatas)
        {
            for (int i = 0; i < FreePlatformContent.childCount; i++)//删除
            {
                int index = i;
                Destroy(FreePlatformContent.GetChild(index).gameObject);
            }
            FreePlatformItemData[] freePlatformItemDatasArray = freePlatformItemDatas.ToArray();
            freePlatformItemDatasArray.DescendingOrder((f) => f.freeTime);
            for (int i = 0; i < freePlatformItemDatasArray.Length; i++)
            {
                int index = i;
                FreePlatformItem freePlatformItem = Instantiate(freePlatformItemPtrfab, FreePlatformContent);//创建
                freePlatformItem.SetData(freePlatformItemDatasArray[index]);
                freePlatformItem.SetColor(index + 1);
            }

            //FreePlatformItemData[] freePlatformItemDatasArray = freePlatformItemDatas.ToArray();
            //freePlatformItemDatasArray.DescendingOrder((f) => f.freeTime);
            //foreach (FreePlatformItemData item in freePlatformItemDatasArray)
            //{

            //}
        }
        /// <summary>
        /// 创建空闲月台
        /// </summary>
        /// <param name="freePlatformItemDatas"></param>
        private void CreateFreePlatformContent(List<FreePlatformItemData> freePlatformItemDatas)
        {
            for (int i = 0; i < FreePlatformContent.childCount; i++)//删除
            {
                int index = i;
                Destroy(FreePlatformContent.GetChild(index).gameObject);
            }
            FreePlatformItemData[] freePlatformItemDatasArray = freePlatformItemDatas.ToArray();
            freePlatformItemDatasArray.DescendingOrder((f) => f.freeTime);
            for (int i = 0; i < freePlatformItemDatasArray.Length; i++)
            {
                int index = i;
                FreePlatformItem freePlatformItem = Instantiate(freePlatformItemPtrfab, FreePlatformContent);//创建
                freePlatformItem.SetData(freePlatformItemDatasArray[index]);
                freePlatformItem.SetColor(index + 1);
            }
        }
        /// <summary>
        /// 更新已出库
        /// </summary>
        /// <param name="outboundNumItemDatas"></param>
        public void UpdateOutboundNumContent(List<OutboundNumItemData> outboundNumItemDatas)
        {
            for (int i = 0; i < OutboundNumContent.childCount; i++)//删除
            {
                int index = i;
                Destroy(OutboundNumContent.GetChild(index));
            }
            OutboundNumItemData[] outboundNumItemDatasArray = outboundNumItemDatas.ToArray();
            outboundNumItemDatasArray.DescendingOrder((o) => o.num);
            for (int i = 0; i < outboundNumItemDatasArray.Length; i++)
            {
                int index = i;
                OutboundNumItem outboundNumItem = Instantiate(outboundNumItemPtrfab, OutboundNumContent);//创建
                outboundNumItem.SetData(outboundNumItemDatasArray[index]);
                outboundNumItem.SetImage(index);
            }
        }
        /// <summary>
        /// 更新车辆和空闲月台
        /// </summary>
        /// <param name="nums"></param>
        public void UpdateCarNum(int[] nums)
        {
            LoadingVehiclesText.Set_endValue(nums[0]);
            IdlePlatformText.Set_endValue(nums[1]);
        }
        /// <summary>
        /// 更新订单数
        /// </summary>
        /// <param name="nums"></param>
        public void UpdateOrderNum(int[] nums)
        {
            CompleteOrderText.Set_endValue(nums[0]);
            LoadedVehiclesText.Set_endValue(nums[0]);
        }
        /// <summary>
        /// 更新库区出货比例
        /// </summary>
        /// <param name="ratios"></param>
        public void UpdateWarehouseShipmentRatio(float[] ratios)
        {
            One.text = (ratios[0] * 100).ToString("f0") + "%";
            Two.text = (ratios[1] * 100).ToString("f0") + "%";
            Three.text = (ratios[2] * 100).ToString("f0") + "%";
            //WarehouseShipmentRatioPiechart.ClearData();
            WarehouseShipmentRatioPiechart.UpdateData(0, 0, ratios[0]);
            WarehouseShipmentRatioPiechart.UpdateData(0, 1, ratios[1]);
            WarehouseShipmentRatioPiechart.UpdateData(0, 2, ratios[2]);
        }

        #region//随机更新数据
        public List<RealTimeCarItemData> realTimeCarItemDatasTest = new List<RealTimeCarItemData>();
        public void UpdateRealTimeCarContentTest()
        {
            int count = UnityEngine.Random.Range(0, realTimeCarItemDatasTest.Count);
            List<RealTimeCarItemData> realTimeCarItemDatasTest_New = realTimeCarItemDatasTest;
            List<RealTimeCarItemData> realTimeCarItemDatasTest_Update = new List<RealTimeCarItemData>();
            for (int i = 0; i < count; i++)
            {
                int index = UnityEngine.Random.Range(0, realTimeCarItemDatasTest_New.Count);
                RealTimeCarItemData realTimeCarItemData = realTimeCarItemDatasTest_New[index];
                realTimeCarItemDatasTest_Update.Add(realTimeCarItemData);
                realTimeCarItemDatasTest_New.RemoveAt(index);
            }
            UpdateRealTimeCarContent(realTimeCarItemDatasTest_Update);
        }


        public List<FreePlatformItemData> freePlatformItemDatasTest = new List<FreePlatformItemData>();
        public void UpdateFreePlatformContentTest()
        {
            int count = UnityEngine.Random.Range(0, freePlatformItemDatasTest.Count);
            List<FreePlatformItemData> freePlatformItemDatasTest_New = freePlatformItemDatasTest;
            List<FreePlatformItemData> freePlatformItemDatasTest_Update = new List<FreePlatformItemData>();
            for (int i = 0; i < count; i++)
            {
                int index = UnityEngine.Random.Range(0, freePlatformItemDatasTest_New.Count);
                FreePlatformItemData freePlatformItemData = freePlatformItemDatasTest_New[index];
                freePlatformItemDatasTest_Update.Add(freePlatformItemData);
                freePlatformItemDatasTest_New.RemoveAt(index);
            }
            //FreePlatformItemData[] freePlatformItemDatas = freePlatformItemDatasTest_Update.ToArray();
            //freePlatformItemDatas.AscendingOrder((f) => f.stayTime);

            UpdateFreePlatformContent(freePlatformItemDatasTest_Update);
        }


        public List<OutboundNumItemData> outboundNumItemDatasTest = new List<OutboundNumItemData>();
        public void UpdateOutboundNumContentTest()
        {
            int count = UnityEngine.Random.Range(outboundNumItemDatasTest.Count-1, outboundNumItemDatasTest.Count);
            List<OutboundNumItemData> outboundNumItemDatasTest_New = outboundNumItemDatasTest;
            List<OutboundNumItemData> outboundNumItemDatasTest_Update = new List<OutboundNumItemData>();
            for (int i = 0; i < count; i++)
            {
                int index = UnityEngine.Random.Range(0, outboundNumItemDatasTest_New.Count);
                OutboundNumItemData outboundNumItemData = outboundNumItemDatasTest_New[index];
                outboundNumItemDatasTest_Update.Add(outboundNumItemData);
                outboundNumItemDatasTest_New.RemoveAt(index);
            }
            //FreePlatformItemData[] freePlatformItemDatas = freePlatformItemDatasTest_Update.ToArray();
            //freePlatformItemDatas.AscendingOrder((f) => f.stayTime);

            UpdateOutboundNumContent(outboundNumItemDatasTest_Update);
        }


        private void OnGUI()
        {
            //if (GUI.Button(new Rect(100,100,200,50),"更新车辆"))
            //{
            //    UpdateRealTimeCarContent(GameFacade.Instance.GetRealTimeCarItemDatas());
            //}
        }

        private IEnumerator IUpdateData(float waitTime)
        {
            //CreateFreePlatformContent(GameFacade.Instance.GetFreePlatformItemDatas());
            while (true)
            {
                UpdateRealTimeCarContent(GameFacade.Instance.GetRealTimeCarItemDatas());
                UpdateFreePlatformContent(GameFacade.Instance.GetFreePlatformItemDatas());
                yield return new WaitForSeconds(waitTime);
            }
        }

        private IEnumerator IUpdateDataPie(float waitTime)
        {
            //CreateFreePlatformContent(GameFacade.Instance.GetFreePlatformItemDatas());
            while (true)
            {
                UpdateWarehouseShipmentRatio(new float[] { (float)Math.Round(Convert.ToDouble(UnityEngine.Random.Range(0.0f, 1.0f)),2),
                (float)Math.Round(Convert.ToDouble(UnityEngine.Random.Range(0.0f, 1.0f)), 2) ,
                (float)Math.Round(Convert.ToDouble(UnityEngine.Random.Range(0.0f, 1.0f)), 2) });
                totalNum += UnityEngine.Random.Range(100, 200);
                TotalText.Set_endValue(totalNum);
                yield return new WaitForSeconds(waitTime);
            }
        }
        #endregion
    }
}
