using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
/// <summary>
/// 轨迹回放控制器
/// </summary>
public class ReplayController : MonoBehaviour
{
    /// <summary>
    /// 存放所有行走的路径点
    /// </summary>
    private List<Vector3> roadPoints = new List<Vector3>();
    /// <summary>
    /// 寻路组件
    /// </summary>
    private NavMeshAgent meshAgent;
    /// <summary>
    /// 绘制轨迹组件
    /// </summary>
    private LineRenderer lineRenderer;
    /// <summary>
    /// 进度条
    /// </summary>
    private MySlider progressSlider;
    /// <summary>
    /// 关闭按钮
    /// </summary>
    private Button closeButton;
    /// <summary>
    /// 暂停按钮
    /// </summary>
    private Button stopButton;
    /// <summary>
    /// 暂停按钮的文字
    /// </summary>
    private Text stopBtnText;
    /// <summary>
    /// UI面板
    /// </summary>
    private Canvas canvas;
    /// <summary>
    /// 当前进度
    /// </summary>
    private float process;
    /// <summary>
    /// 是否暂停
    /// </summary>
    private bool isPause;
    /// <summary>
    /// 当前速度
    /// </summary>
    float speed;
    int index;
    /// <summary>
    /// 当前会放到第几个点
    /// </summary>
    int Index
    {
        get
        {
            return index;
        }
        set
        {
            // if (value>0)
            {
                List<Vector3> posList = new List<Vector3>();
                posList = roadPoints.GetRange(0, Mathf.Clamp(value + 1, 0, roadPoints.Count));//Mathf.Clamp函数不包括最大值
                lineRenderer.positionCount = posList.Count;
                lineRenderer.SetPositions(posList.ToArray());
            }
            index = value;

        }
    }
    /// <summary>
    /// 是否在回放
    /// </summary>
    public bool isPlaying;
    private void Start()
    {
        progressSlider = transform.Find("Canvas/ProgressSlider").GetComponent<MySlider>();
        canvas = transform.Find("Canvas").GetComponent<Canvas>();
        closeButton = transform.Find("Canvas/CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(CloseReplayUI);
        stopButton = transform.Find("Canvas/StopButton").GetComponent<Button>();
        stopButton.onClick.AddListener(StopReplay);
        stopBtnText =transform.Find("Canvas/StopButton/Text").GetComponent<Text>();
        canvas.gameObject.SetActive(false);
        lineRenderer = GetComponent<LineRenderer>();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    public void OnInit(List<Vector3> roadPoints, NavMeshAgent meshAgent)
    {
        this.roadPoints = roadPoints;
        this.meshAgent = meshAgent;
        canvas.gameObject.SetActive(true);
        Index = 0;
    }

    /// <summary>
    /// 回放
    /// </summary>
    public void ReplayRuningData()
    {
        Index = 0;
        progressSlider.value = 0;
        isPlaying = true;
        StartCoroutine("IReplayRuningData");
        StartCoroutine("IOnDragingProcessSlider");
    }
    /// <summary>
    /// 回放协程
    /// </summary>
    /// <returns></returns>
    IEnumerator IReplayRuningData()
    {
        meshAgent.enabled = false;
        meshAgent.transform.position = roadPoints[Index];
        meshAgent.enabled = true;
        //lineRenderer.positionCount = roadPoints.Count;
        //lineRenderer.SetPositions(roadPoints.ToArray());
        while (true)
        {

            yield return new WaitUntil(() => (progressSlider.IsDraging == false) && (isPause == false));//没有拖动滑块的时候才更新
            yield return 0;
            if (!meshAgent.hasPath)
            {
                if (Index >= roadPoints.Count)
                {
                    // CloseReplayUI();
                    ReplayRuningData();
                    break;
                }
                meshAgent.SetDestination(roadPoints[Index]);
                //计算出移动距离
                float distance = Vector3.Distance(meshAgent.transform.position, roadPoints[Mathf.Clamp(Index + 1, 0, roadPoints.Count - 1)]);
                float time = distance / meshAgent.speed;
                process = (float)Index / (roadPoints.Count - 1);
                if (time != 0)
                {
                    speed = process / time;
                }
                else
                {
                    speed = 0;
                }
                yield return IUpDateProgressSlider();
                Index++;
            }
        }
    }
    /// <summary>
    /// 关闭回放UI
    /// </summary>
    private void CloseReplayUI()
    {
        lineRenderer.positionCount = 0;
        progressSlider.value = 0;
        canvas.gameObject.SetActive(false);
        Index = 0;
        StopAllCoroutines();
        isPlaying = false;
        isPause = false;
        SetMeshAgentPos(roadPoints[roadPoints.Count - 1]);//将物体设置到开始回放的时候最后一个位置
    }
    /// <summary>
    /// 暂停轨迹回放
    /// </summary>
    private void StopReplay()
    {
        isPause = !isPause;
        if (isPause)//已经暂停，就需要将按钮的文字更换为开始
        {
            stopBtnText.text = "开始";
        }
        else
        {
            stopBtnText.text = "暂停";
        }
    }
    /// <summary>
    /// 在没有导航移动效果的情况下，设置导航组件的位置
    /// </summary>
    /// <param name="pos"></param>
    private void SetMeshAgentPos(Vector3 pos)
    {
        meshAgent.enabled = false;
        meshAgent.transform.position = pos;//物体设置到最后的那个点
        meshAgent.enabled = true;
        #region //当移动物体是警察的时候，要开启倒计时删除物体的协程
        PoliceMoveObj policeMoveObj = meshAgent.GetComponent<PoliceMoveObj>();
        if (policeMoveObj != null)
        {
            policeMoveObj.StartTimer();
        }
        #endregion
    }
    /// <summary>
    /// 更新进度条
    /// </summary>
    /// <param name="process"></param>
    /// <returns></returns>
    IEnumerator IUpDateProgressSlider()
    {
        while (progressSlider.value < process && !progressSlider.IsDraging)
        {
            yield return new WaitForEndOfFrame();
            progressSlider.value += speed * Time.deltaTime;
        }
    }

    /// <summary>
    /// 鼠标拖动滑块
    /// </summary>
    IEnumerator IOnDragingProcessSlider()
    {
        while (true)
        {
            yield return new WaitUntil(() => (progressSlider.IsDraging == true) && (isPause == false));//没有拖动滑块的时候才更新
            float value = progressSlider.value;
            Index = Mathf.Clamp(Mathf.RoundToInt(roadPoints.Count * value) - 1, 0, roadPoints.Count - 1);
            meshAgent.enabled = false;
            meshAgent.transform.position = roadPoints[Index];
            meshAgent.enabled = true;
        }
    }
}
