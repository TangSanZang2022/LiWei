﻿using ShowHideObj;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 显示隐藏物体控制器
/// </summary>
public class ShowHideObjController : BaseController
{
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="gameFacade"></param>
    public ShowHideObjController(GameFacade gameFacade) : base(gameFacade)
    { }
    /// <summary>
    /// 存放所有需要显示隐藏的物体
    /// </summary>
    private Dictionary<string, BaseShowHideObj> allShowHideObjDict = new Dictionary<string, BaseShowHideObj>();
    /// <summary>
    /// 初始化
    /// </summary>
    public override void OnInit()
    {
        SetAllShowHideObjDict();
    }


    /// <summary>
    /// 更新
    /// </summary>
    public override void OnUpdate()
    {
        
    }

    /// <summary>
    /// 将场景中所有需要显示隐藏的物体放入字典中
    /// </summary>
    private void SetAllShowHideObjDict()
    {
        allShowHideObjDict.Clear();
        BaseShowHideObj[]showHideObjs = GameObject.FindObjectsOfType<BaseShowHideObj>();
        foreach (BaseShowHideObj bs in showHideObjs)
        {
            allShowHideObjDict.Add(bs.GetID(), bs);
          
        }
        foreach (BaseShowHideObj bs in allShowHideObjDict.Values)
        {
            bs.Oninit();
        }
    }
    /// <summary>
    /// 根据ID来找到显示隐藏的物体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BaseShowHideObj GetShowHideObjForID(string id)
    {
        BaseShowHideObj baseShowHideObj;
        if (!allShowHideObjDict.TryGetValue(id,out baseShowHideObj))
        {
            Debug.LogError(string.Format("找不到对应ID为{0}的物体", id));
        }
        return baseShowHideObj;
    }
    /// <summary>
    /// 根据ID显示物体
    /// </summary>
    /// <param name="id"></param>
    public GameObject ShowObjForID(string id)
    {
        GetShowHideObjForID(id).Show();
        return GetShowHideObjForID(id).gameObject;
    }
    /// <summary>
    /// 根据ID隐藏物体
    /// </summary>
    /// <param name="id"></param>
    public void HideObjForID(string id)
    {
        GetShowHideObjForID(id).Hide();
    }
    /// <summary>
    /// 销毁
    /// </summary>
    public override void OnDestory()
    {
        
    }
}
