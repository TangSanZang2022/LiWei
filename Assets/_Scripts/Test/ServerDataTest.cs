using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Test;
using DG.Tweening;
using CSVTool;
using DFDJ;
public class ServerDataTest : MonoBehaviour
{
    ReadExcelTest readExcelTest;
    private List<Vector3> posList = new List<Vector3>();
    private List<double> x = new List<double>();
    private List<double> y = new List<double>();
    private List<double> z = new List<double>();
    public bool xDown;
    public bool yDown;
    public bool zDown;
    /// <summary>
    /// 数据已经全部遍历完成
    /// </summary>
    private bool dataEnd = false;
    /// <summary>
    /// X数据控制的物体
    /// </summary>
    public Transform xTrans;
    /// <summary>
    /// Y数据控制的物体
    /// </summary>
    public Transform yTrans;
    /// <summary>
    /// Z数据控制的物体
    /// </summary>
    public Transform zTrans;
    // Start is called before the first frame update
    void Start()
    {
        readExcelTest = new ReadExcelTest();
        ReadHistoryData();

        CSV.GetInstance().LoadFile(Application.streamingAssetsPath, "newX.csv");
        Debug.Log("读取到newX.csv中数据" + CSV.GetInstance().GetStringInArrayData(2, 2));
        CSV.GetInstance().LoadMultipleFile(new string[] { Application.streamingAssetsPath, Application.streamingAssetsPath, Application.streamingAssetsPath },
            new string[] { "newX.csv", "newY.csv", "HeavyEquipmentInfo.csv" }
            );
        Debug.Log("读取到newX.csv中数据" + CSV.GetInstance().GetStringInDictData("newX.csv", 2, 2));
        Debug.Log("读取到newY.csv中数据" + CSV.GetInstance().GetStringInDictData("newY.csv", 2, 2));
        Debug.Log("HeavyEquipmentInfo.csv中数据" + CSV.GetInstance().GetStringInDictData("HeavyEquipmentInfo.csv", 2, 2));

       


    }
    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10,20,200,40),"读取X"))
    //    {
    //        string path = Application.streamingAssetsPath + "/newx.xls";
    //        Debug.Log(path);
    //        readExcelTest.ReadExcel_NewThread(path, (xValue,b)=> { x.Add(xValue); xDown = b; });
    //        StartCoroutine(IUpdateXData());
    //    }
    //    if (GUI.Button(new Rect(10, 70, 200, 40), "读取Y"))
    //    {
    //        string path = Application.streamingAssetsPath + "/newy.xls";
    //        Debug.Log(path);
    //        readExcelTest.ReadExcel_NewThread(path, (yValue,b) => { y.Add(yValue); yDown = b; });
    //        StartCoroutine(IUpdateYData());
    //    }
    //    if (GUI.Button(new Rect(10, 130, 200, 40), "读取Z"))
    //    {
    //        string path = Application.streamingAssetsPath + "/newz.xls";
    //        Debug.Log(path);
    //        readExcelTest.ReadExcel_NewThread(path, (zValue, b) => { z.Add(zValue); zDown = b; });
    //        StartCoroutine(IUpdateZData());
    //    }
    //    if (GUI.Button(new Rect(220, 20, 200, 40), "遍历得到数据"))
    //    {
    //        StartCoroutine(IDebugData());
    //    }
    //}

    private IEnumerator IDebugData()
    {
        yield return new WaitUntil(() => (xDown && yDown && zDown));
        for (int i = 0; i < x.Count; i++)
        {
            Debug.Log(string.Format("X:{0},Y{1},Z{2}", x[i], y[i], z[i]));
            yield return new WaitForSeconds(1);
        }
    }
    /// <summary>
    /// 更新物体的X轴
    /// </summary>
    /// <returns></returns>
    private IEnumerator IUpdateXData()
    {
        Debug.Log(x.Count);
        yield return new WaitUntil(() => xDown);
        for (int i = 11900; i < x.Count; i++)
        {
            // Debug.Log("Double:"+ x[i] / 1000);
            // Debug.Log("float:" + float.Parse((x[i] / 1000).ToString()));
            xTrans.DOLocalMoveY(float.Parse((x[i] / 1000).ToString()) * -1, 1f);
            //xTrans.localPosition=new Vector3(xTrans.localPosition.x, float.Parse((x[i] / 1000).ToString())*-1, xTrans.localPosition.z);
            yield return new WaitForSeconds(0.02f);
        }
       yield return new WaitUntil(() => dataEnd);
        //GetComponent<CNCHheavySleeper_17m>().UpdateObjSync("Stop");
        StartMoveForHistoryData();
    }
    private IEnumerator IUpdateYData()
    {
        yield return new WaitUntil(() => yDown);
        for (int i = 11900; i < y.Count; i++)
        {
            yTrans.DOLocalMoveX(float.Parse((y[i] / 1000).ToString()) * -1, 1f);
            //yTrans.localPosition = new Vector3(float.Parse((y[i] / 1000).ToString())*-1, yTrans.localPosition.y, yTrans.localPosition.z);
            yield return new WaitForSeconds(0.02f);
        }
        dataEnd = true;
    }
    private IEnumerator IUpdateZData()
    {
        yield return new WaitUntil(() => zDown);
        for (int i = 30000; i < z.Count; i++)
        {
            zTrans.localPosition = new Vector3(float.Parse((z[i] / 1000).ToString()), zTrans.localPosition.y, zTrans.localPosition.z);
            yield return new WaitForSeconds(0.02f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 读取历史数据
    /// </summary>
    private void ReadHistoryData()
    {
        string pathX = Application.streamingAssetsPath + "/newx.xls";
        Debug.Log(pathX);
        readExcelTest.ReadExcel_NewThread(pathX, (xValue, b) => { x.Add(xValue); xDown = b; });

        string pathY = Application.streamingAssetsPath + "/newy.xls";
        Debug.Log(pathY);
        readExcelTest.ReadExcel_NewThread(pathY, (yValue, b) => { y.Add(yValue); yDown = b; });
    }
    /// <summary>
    /// 开始历史数据驱动
    /// </summary>
    public void StartMoveForHistoryData()
    {
        StartCoroutine(IUpdateXData());
        StartCoroutine(IUpdateYData());
    }
    /// <summary>
    /// 停止根据历史数据运动，并且恢复为初始状态
    /// </summary>
    public void StopMoveForHistoryData()
    {
        StopAllCoroutines();
        xTrans.DOLocalMove(Vector3.zero, 1f);
    }
}
