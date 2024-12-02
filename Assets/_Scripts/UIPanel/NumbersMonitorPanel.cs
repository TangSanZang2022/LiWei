using System.Collections;
using System.Collections.Generic;
using UMP;
using UnityEngine;
using UnityEngine.UI;
using UnityMonitor;

public class NumbersMonitorPanel : BasePanel
{
    /// <summary>
    /// 是否已经初始化
    /// </summary>
    private bool isInit;
    /// <summary>
    /// 存放播放视频的面板
    /// </summary>
    private ARVideoCanvasHelper[] videoImageArray;
    
    /// <summary>
    /// 关闭按钮
    /// </summary>
    private Button closeBtn;
    UniversalMediaPlayer[] mediaPlayers;
    /// <summary>
    /// 视频播放器列表
    /// </summary>
    UniversalMediaPlayer[] MediaPlayers
    {
        get
        {
            if (mediaPlayers == null)
            {
                mediaPlayers = new UniversalMediaPlayer[3];
                mediaPlayers[0] = GameObject.Find("MediaPlayers/UniversalMediaPlayerBottom1").GetComponent<UniversalMediaPlayer>();
                mediaPlayers[1] = GameObject.Find("MediaPlayers/UniversalMediaPlayerBottom2").GetComponent<UniversalMediaPlayer>();
                mediaPlayers[2] = GameObject.Find("MediaPlayers/UniversalMediaPlayerBottom3").GetComponent<UniversalMediaPlayer>();
            }
            return mediaPlayers;
        }
    }
    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        videoImageArray = transform.GetComponentsInChildren<ARVideoCanvasHelper>();//给播放器列表赋值
        for (int i = 0; i < videoImageArray.Length; i++)
        {
            videoImageArray[i].GetComponent<VideoImage>().Init();
            //videoImageArray[i].Set_mediaPlayer(MediaPlayers[i]);
            MediaPlayers[i].RenderingObjects = new GameObject[] { videoImageArray[i].gameObject }; //设置RenderingObjects数组，如果不设置，视频无法播放
        }

        closeBtn = transform.Find("CloseButton").GetComponent<Button>();
        closeBtn.onClick.AddListener(() => ClosePanel());
        isInit = true;
    }
    /// <summary>
    /// 根据视频地址播放视频
    /// </summary>
    /// <param name="url"></param>
    public void PlayMonitors(string[] urls)
    {
        for (int i = 0; i < urls.Length; i++)
        {
            if (!string.IsNullOrEmpty(urls[i])) //播放地址不为空就播放
            {
                videoImageArray[i].gameObject.SetActive(true);
                MediaPlayers[i].Stop();
                MediaPlayers[i].Path = urls[i];
                MediaPlayers[i].Play();
            }
            else  //播放地址为空，则隐藏播放视频面板
            {
                videoImageArray[i].gameObject.SetActive(false);
            }

        }

    }
    /// <summary>
    /// 将所有摄像头关闭
    /// </summary>
    private void StopPlayMonitors()
    {
        for (int i = 0; i < MediaPlayers.Length; i++)
        {
            MediaPlayers[i].Stop();
            MediaPlayers[i].Path =string.Empty;
        }
    }
    /// <summary>
    /// 显示面板
    /// </summary>
    private void ShowPanel()
    {
        gameObject.SetActive(true);
    }
    /// <summary>
    /// 隐藏面板
    /// </summary>
    private void HidePanel()
    {
       
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 关闭此界面
    /// </summary>
    private void ClosePanel()
    {
        HidePanel();
        GameFacade.Instance.PopPanel();
    }
    /// <summary>
    /// 面板进入
    /// </summary>
    public override void OnEnter()
    {
        ShowPanel();
        if (!isInit)
        {
            Init();
        }
    }
    /// <summary>
    /// 面板暂停
    /// </summary>
    public override void OnPause()
    {
        HidePanel();
    }
    /// <summary>
    /// 面板继续
    /// </summary>
    public override void OnResume()
    {
        ShowPanel();
    }
      /// <summary>
      /// 面板退出
      /// </summary>
    public override void OnExit()
    {
        StopPlayMonitors();
        HidePanel();
    }
}
