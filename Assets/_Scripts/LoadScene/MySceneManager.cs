using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景控制器
/// </summary>
public static class MySceneManager
{
    /// <summary>
    /// 每次运行必须从Start场景开始加载
    /// </summary>
    [RuntimeInitializeOnLoadMethod]
    static void LoadToFirstScene()
    {
        if (SceneManager.GetActiveScene().name != "Start")
        {
            //SceneManager.LoadScene("Start");
        }
    }
    private static AsyncOperation ao;
    public static AsyncOperation Ao
    {
        get
        {
            return ao;
        }
        
    }
    /// <summary>
    /// 是否正在加载
    /// </summary>
    private static bool isLoading = false;
    /// <summary>
    /// 是否正在加载
    /// </summary>
    public static bool IsLoading
    {
        get
        {
            return isLoading;
        }
        set
        {
            isLoading = value;
        }
    }


    /// <summary>
    /// 通过场景名称来加载场景
    /// </summary>
    /// <param name="sceneName"></param>
    public static void LoadSceneSync(string sceneName)
    {
        if (isLoading||SceneManager.GetActiveScene().name== sceneName)
        {
            return;
        }
        IsLoading = true;
        ao = SceneManager.LoadSceneAsync(sceneName);
        CreateLoadingCanvas();
    }

    /// <summary>
    /// 通过场景ID来加载场景
    /// </summary>
    /// <param name="id"></param>
    public static void LoadSceneSync(int id)
    {
        if (isLoading || SceneManager.GetActiveScene().buildIndex==id)
        {
            return;
        }
        ao = SceneManager.LoadSceneAsync(id);
        CreateLoadingCanvas();
    }
    /// <summary>
    /// 创建加载界面
    /// </summary>
    private static void CreateLoadingCanvas()
    {
       // GameFacade.Instance.PushPanel(UIPanelType.LoadingCanvas);//通过UI框架弹出加载界面UI
        LoadingCanvas loadingCanvas =GameObject.Instantiate(Resources.Load<LoadingCanvas>("Prefabs/UIPrefab/LoadingCanvas"));
       // ao = null;
    }
}

