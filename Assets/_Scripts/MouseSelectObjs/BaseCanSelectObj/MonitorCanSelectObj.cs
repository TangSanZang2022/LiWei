using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MouseSelectObjs;
using HighlightingSystem;
using UnityMonitor;
public class MonitorCanSelectObj : BaseCanSelectObj
{
    /// <summary>
    /// 高亮组件
    /// </summary>
    private Highlighter highlighter;
    protected override void Start()
    {
        highlighter = GetComponent<Highlighter>();
    }
    /// <summary>
    /// 正在选中时调用
    /// </summary>
    public override void SelectingHandle()
    {
        base.SelectingHandle();
        highlighter.FlashingOn();
    }
     /// <summary>
     /// 选中之后调用
     /// </summary>
    public override void SelectedHandle()
    {
        base.SelectedHandle();
        highlighter.FlashingOff();
        GameFacade.Instance.AddMonitors(GetComponent<BaseMonitor>());
    }
    /// <summary>
    ///选完之后调用
    /// </summary>
    public override void EndHandle()
    {
        base.EndHandle();
        highlighter.FlashingOff();
        //GameFacade.instance.RemoveMonitors(GetComponent<BaseMonitor>());
    }
}
