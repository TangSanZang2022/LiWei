using System.Collections;
using System.Collections.Generic;
using UMP;
using UnityEngine;
using UnityEngine.UI;
using UIFramework;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;
using DFDJ;
using MyPos;
/// <summary>
/// 播放监控面板
/// </summary>
public class MonitorPanel : BasePanel
{



    #region//小窗口
    private Transform MinPanel;
    private ARVideoCanvasHelper videoImageBottom;
    private Text num_Min;
    private Text Num_Min
    {
        get
        {
            if (num_Min == null)
            {
                num_Min = transform.FindChildForName("Num_Min").GetComponent<Text>();
            }
            return num_Min;
        }
    }
    /// <summary>
    /// 播放按钮
    /// </summary>
    private Button playBtn;
    /// <summary>
    /// 暂停按钮
    /// </summary>
    private Button pauseBtn;
    /// <summary>
    /// 关闭按钮
    /// </summary>
    private Button closeBtn;
    /// <summary>
    /// 音量调节
    /// </summary>
    private Slider volumeSli;
    /// <summary>
    /// 显示最大化按钮
    /// </summary>
    private Transform ShowMaxButton;
    #endregion
    #region//大窗口
    private Transform MaxPanel;
    private ARVideoCanvasHelper videoImageBottom_Max;
    private Text num_Max;
    private Text Num_Max
    {
        get
        {
            if (num_Max == null)
            {
                num_Max = transform.FindChildForName("Num_Max").GetComponent<Text>();
            }
            return num_Max;
        }
    }
    /// <summary>
    /// 播放按钮
    /// </summary>
    private Button playBtn_Max;
    /// <summary>
    /// 暂停按钮
    /// </summary>
    private Button pauseBtn_Max;
    /// <summary>
    /// 关闭按钮
    /// </summary>
    private Button closeBtn_Max;
    /// <summary>
    /// 音量调节
    /// </summary>
    private Slider volumeSli_Max;
    /// <summary>
    /// 显示最大化按钮
    /// </summary>
    private Transform ShowMinButton;
    #endregion
    /// <summary>
    /// 是否已经初始化
    /// </summary>
    private bool isInit = false;

    private string url;
    UniversalMediaPlayer mediaPlayer_Min;
    UniversalMediaPlayer MediaPlayer_Min
    {
        get
        {
            if (mediaPlayer_Min == null)
            {
                if (MinPanel == null)
                {
                    MinPanel = transform.FindChildForName("MinPanel");
                }
                mediaPlayer_Min = MinPanel.GetComponent<UniversalMediaPlayer>();
                if (mediaPlayer_Min == null)
                {
                    mediaPlayer_Min = MinPanel.gameObject.AddComponent<UniversalMediaPlayer>();
                }
            }
            // mediaPlayer.Path = string.Empty;//将视频路径设置为空
            return mediaPlayer_Min;
        }
    }

    UniversalMediaPlayer mediaPlayer_Max;
    UniversalMediaPlayer MediaPlayer_Max
    {
        get
        {
            if (mediaPlayer_Max == null)
            {
                if (MaxPanel == null)
                {
                    MaxPanel = transform.FindChildForName("MinPanel");
                }
                mediaPlayer_Max = MaxPanel.GetComponent<UniversalMediaPlayer>();
                if (mediaPlayer_Max == null)
                {
                    mediaPlayer_Max = MaxPanel.gameObject.AddComponent<UniversalMediaPlayer>();
                }
            }
            // mediaPlayer.Path = string.Empty;//将视频路径设置为空
            return mediaPlayer_Max;
        }
    }
    private void Awake()
    {

    }
    private void Start()
    {

    }
    /// <summary>
    /// 更新小面板的位置
    /// </summary>
    /// <param name="monitorWorldPos"></param>
    public void UpdateMinPanelPos(Vector3 monitorWorldPos)
    {
        Debug.Log("摄像头的世界坐标为" + monitorWorldPos);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(monitorWorldPos);
        Debug.Log(screenPos);
       // MinPanel.transform.position = screenPos;
        Vector3 dir =new Vector3(Screen.width/2,Screen.height/2,0) - screenPos;
        float dis = dir.magnitude;
        MinPanel.transform.position = screenPos + dir.normalized * (dis / 2);
    }
    /// <summary>
    /// 设置标题
    /// </summary>
    /// <param name="title"></param>
    public void SetTitle(string title)
    {
        Num_Max.text = title;
        Num_Min.text = title;
    }
    /// <summary>
    /// 初始化，在播放视频之前要完成
    /// </summary>
    public void Init()
    {
        MinPanel = transform.FindChildForName("MinPanel");
        MaxPanel = transform.FindChildForName("MaxPanel");

        videoImageBottom_Max = transform.FindChildForName("VideoImageBottom_Max").GetComponent<ARVideoCanvasHelper>();
        //videoImageBottom_Max.Set_mediaPlayer(MediaPlayer_Max);
        MediaPlayer_Max.RenderingObjects = new GameObject[] { videoImageBottom_Max.gameObject }; //设置RenderingObjects数组，如果不设置，视频无法播放
        closeBtn_Max = transform.FindChildForName("Close_Max").GetComponent<Button>();
        closeBtn_Max.onClick.AddListener(() => OnCloseBtnClick());
        // playBtn_Max = transform.FindChildForName("Play_Max").GetComponent<Button>();
        //playBtn_Max.onClick.AddListener(() => MediaPlayer_Max.Play());
        //pauseBtn_Max = transform.FindChildForName("Pause_Max").GetComponent<Button>();
        // pauseBtn_Max.onClick.AddListener(() => MediaPlayer_Max.Pause());
        // volumeSli_Max = transform.FindChildForName("Volume_Max").GetComponent<Slider>();
        // volumeSli_Max.onValueChanged.AddListener(delegate { SetVolume(volumeSli.value); });
        ShowMinButton = transform.FindChildForName("ShowMinButton");
        UIEventListener.GetUIEventListener(ShowMinButton).pointClickHandler += OnShowMinButtonClick;


        videoImageBottom = transform.FindChildForName("VideoImageBottom").GetComponent<ARVideoCanvasHelper>();
        //videoImageBottom.Set_mediaPlayer(MediaPlayer_Min);
        mediaPlayer_Min.RenderingObjects = new GameObject[] { videoImageBottom.gameObject }; //设置RenderingObjects数组，如果不设置，视频无法播放
        closeBtn = transform.FindChildForName("Close").GetComponent<Button>();
        closeBtn.onClick.AddListener(() => OnCloseBtnClick());
        // playBtn = transform.FindChildForName("Play").GetComponent<Button>();
        //playBtn.onClick.AddListener(() => mediaPlayer_Min.Play());
        // pauseBtn = transform.FindChildForName("Pause").GetComponent<Button>();
        // pauseBtn.onClick.AddListener(() => mediaPlayer_Min.Pause());
        // volumeSli = transform.FindChildForName("Volume").GetComponent<Slider>();
        // volumeSli.onValueChanged.AddListener(delegate { SetVolume(volumeSli.value); });
        ShowMaxButton = transform.FindChildForName("ShowMaxButton");
        UIEventListener.GetUIEventListener(ShowMaxButton).pointClickHandler += OnShowMaxButtonClick;
        isInit = true;
    }

    private void PlayMaxOrMin(bool min)
    {
        if (min)
        {

        }
        else
        {

        }

    }
    /// <summary>
    /// 最大化按钮按下
    /// </summary>
    /// <param name="eventData"></param>
    private void OnShowMaxButtonClick(PointerEventData eventData)
    {

        MaxPanel.gameObject.SetActive(true);
        MinPanel.gameObject.SetActive(false);
        PlayMonitor_Max();
    }
    /// <summary>
    /// 最小化按钮按下
    /// </summary>
    /// <param name="eventData"></param>
    private void OnShowMinButtonClick(PointerEventData eventData)
    {
        MaxPanel.gameObject.SetActive(false);
        MinPanel.gameObject.SetActive(true);
        // PlayMaxOrMin(true);
        PlayMonitor_Min();
    }

    /// <summary>
    /// 设置音量
    /// </summary>
    /// <param name="v"></param>
    private void SetVolume(float v)
    {
        mediaPlayer_Min.Volume = (int)v;
    }
    /// <summary>
    /// 根据视频地址播放视频
    /// </summary>
    /// <param name="url"></param>
    public void PlayMonitor(string url)
    {
        this.url = url;
        MediaPlayer_Min.Stop();
        MediaPlayer_Min.Path = url;
        MediaPlayer_Min.Play();
    }

    public void PlayMonitor_Max()
    {
        MediaPlayer_Max.Stop();
        MediaPlayer_Max.Path = url;
        MediaPlayer_Max.Play();
    }

    public void PlayMonitor_Min()
    {
        MediaPlayer_Min.Stop();
        MediaPlayer_Min.Path = url;
        MediaPlayer_Min.Play();
    }
    /// <summary>
    /// 关闭按钮按下
    /// </summary>
    private void OnCloseBtnClick()
    {
        MediaPlayer_Min.Stop();
        BasePos baseCamPos = GameFacade.Instance.GetCurrentCamPos();
        if (baseCamPos != null)
        {
            IAnimControl animControl = baseCamPos.GetComponent<IAnimControl>();
            if (animControl != null)
            {
                animControl.Play();
            }

        }
        GameFacade.Instance.PopPanel();
    }
    /// <summary>
    /// 显示面板
    /// </summary>
    private void ShowPanel()
    {
        gameObject.SetActive(true);

    }
    /// <summary>
    /// 隐藏此界面
    /// </summary>
    private void HidePanel()
    {
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 显示面板
    /// </summary>
    public override void OnEnter()
    {
        ShowPanel();
        if (!isInit)
        {
            Init();
        }
        MaxPanel.gameObject.SetActive(false);
        MinPanel.gameObject.SetActive(true);


    }
    /// <summary>
    /// 暂停面板
    /// </summary>
    public override void OnPause()
    {
        HidePanel();
    }
    /// <summary>
    /// 继续面板
    /// </summary>
    public override void OnResume()
    {
        ShowPanel();
    }
    /// <summary>
    /// 退出面板
    /// </summary>
    public override void OnExit()
    {
        HidePanel();
    }
}
