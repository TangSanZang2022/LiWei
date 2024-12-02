using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
/// <summary>
/// 光电管
/// </summary>
public class Phototube : OperationalObj, IUpdateHandle
{
    /// <summary>
    /// 遮挡时的颜色
    /// </summary>
    private Color occlusionColor = Color.red;
    /// <summary>
    /// 未遮挡时的颜色
    /// </summary>
    private Color noCoveredColor = Color.green;
    /// <summary>
    /// 初始颜色
    /// </summary>
    private Color normalColor;
    /// <summary>
    /// 光电管的灯
    /// </summary>
    private Light phototubeLight;
    /// <summary>
    /// 还原为初始状态
    /// </summary>
    public void ReductionNormalState()
    {
        phototubeLight.color = normalColor;
    }
    /// <summary>
    /// 更新状态
    /// </summary>
    /// <param name="data"></param>
    public void UpdateHandle(object data)
    {
        BeltData beltData = data as BeltData;
        if (GetID() == "1")//一号光电管
        {
            if (beltData.IsOcclusio_Ph1 == 1) 
            {
                ChangeLightColor(true);
            }
            else
            {
                ChangeLightColor(false);
            }
        }
        else if (GetID() == "2")//二号光电管
        {
            if (beltData.IsOcclusio_Ph2 == 1)
            {
                ChangeLightColor(true);
            }
            else
            {
                ChangeLightColor(false);
            }
        }
        
    }

   
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void OnInit()
    {
        phototubeLight = GetComponentInChildren<Light>();
        normalColor = phototubeLight.color;
    }
    /// <summary>
    /// 更换灯的颜色
    /// </summary>
    /// <param name="isLighting">是否被遮挡</param>
    private void ChangeLightColor(bool isCovered)
    {
        if (isCovered)//被遮挡
        {
            phototubeLight.color = occlusionColor;
        }
        else
        {
            phototubeLight.color = noCoveredColor;
        }
    }
}
