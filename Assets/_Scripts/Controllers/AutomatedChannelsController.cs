using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 自助通道控制
/// </summary>
public class AutomatedChannelsController : BaseController
{
    /// <summary>
    /// 存放所有自助通道的字典
    /// </summary>
    private Dictionary<string, AutomatedChannels> allAutomatedChannelsDict = new Dictionary<string, AutomatedChannels>();
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="facade"></param>
    public AutomatedChannelsController(GameFacade facade) : base(facade)


    { }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
      /// <summary>
      /// 初始化
      /// </summary>
    public override void OnInit()
    {
        SetAllAutomatedChannelsDict();
        UpdateAutomatedChannelsRequest updateAutomatedChannelsRequest = new UpdateAutomatedChannelsRequest();

    }
    /// <summary>
    /// 从场景中得到AutomatedChannels给 allAutomatedChannelsDict赋值
    /// </summary>
    private void SetAllAutomatedChannelsDict()
    {
        allAutomatedChannelsDict.Clear();
        AutomatedChannels[] automatedChannels = GameObject.FindObjectsOfType<AutomatedChannels>();
        foreach (AutomatedChannels ac in automatedChannels)
        {
            allAutomatedChannelsDict.Add(ac.GetID(), ac);
        }
    }

    /// <summary>
    /// 通过ID得到自助通道
    /// </summary>
    /// <param name="automatedChannelsID"></param>
    /// <returns></returns>
    public AutomatedChannels GetAutomatedChannelsForID(string automatedChannelsID)
    {
        AutomatedChannels ac;
        if (!allAutomatedChannelsDict.TryGetValue(automatedChannelsID, out ac))
        {
            Debug.LogError(string.Format("找不到对应ID：{0}的自助通道", automatedChannelsID));
        }
        return ac;
    }

    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="data"></param>
    public void UpdateAllAutomatedChannels(string data)
    {
        AutomatedChannelsDataList automatedChannelsDataList  = JsonUtility.FromJson<AutomatedChannelsDataList>(data);
        List<AutomatedChannelsData> automatedChannelsDatas = automatedChannelsDataList.data;
        foreach (AutomatedChannelsData acd in automatedChannelsDatas)
        {
            GetAutomatedChannelsForID(acd.id).UpdateObj(acd);
        }
    }
}
