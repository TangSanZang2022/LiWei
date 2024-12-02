using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 点击之后可以UI展示信息物体基类
/// </summary>
public class BaseInfoUIObj : MonoBehaviour
{
    protected IBaseInfo baseInfo;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
        CloseUI();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
       /// <summary>
       /// 初始化 ，获取组件等
       /// </summary>
    protected virtual void Init()
    { }
    /// <summary>
    /// 初始化UI内容
    /// </summary>
    protected virtual void InitUIContent()
    { 
    
    }
    /// <summary>
    /// 获取ID
    /// </summary>
    /// <returns></returns>
    public  string GetID()
    {
        return baseInfo.ID;
    }
    /// <summary>
    /// 设置信息
    /// </summary>
    /// <param name="baseInfo"></param>
    public virtual void SetBaseInfo(IBaseInfo baseInfo)
    { 
    
    }
    /// <summary>
    /// 打开UI
    /// </summary>
    public void OpenUI()
    {
        gameObject.SetActive(true);
        InitUIContent();
    }
    /// <summary>
    /// 关闭UI
    /// </summary>
    public void CloseUI()
    {
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 设置Text的展示内容
    /// </summary>
    /// <param name="text"></param>
    /// <param name="content"></param>
    protected void SetTextContent(Text text, string content)
    {
        text.text = content;
    }
}
