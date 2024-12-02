using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
/// <summary>
/// 自助通道的门，用于更新颜色和开关状态
/// </summary>
public class AutomatedChannelsDoor : MonoBehaviour, IUpdateHandle
{

    private MeshRenderer meshRenderer;
    /// <summary>
    /// 默认的材质球
    /// </summary>
    private Material[] normalMaterials;
    [SerializeField]
    /// <summary>
    /// 开门时的旋转角度
    /// </summary>
    private Vector3 openRotAngle;
    /// <summary>
    /// 关闭状态的角度,既初始状态
    /// </summary>
    private Vector3 closeRotAngle;
    /// <summary>
    /// 自助通道的数据
    /// </summary>
    private AutomatedChannelsData automatedChannelsData;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        normalMaterials = meshRenderer.materials;
        closeRotAngle = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 还原为初始状态
    /// </summary>
    public void ReductionNormalState()
    {

    }
    /// <summary>
    /// 自助通道门的状态更新处理
    /// </summary>
    /// <param name="data"></param>
    public void UpdateHandle(object data)
    {
        this.automatedChannelsData = data as AutomatedChannelsData;
        if (automatedChannelsData.state == "Open")
        {
            ChangeToOpenMaterials();
            OpenTheDoor();
        }
        else
        {
            ChangeToCloseMaterials();
            CloseTheDoor();
        }
    }
    /// <summary>
    /// 开门
    /// </summary>
    private void OpenTheDoor()
    {
        //transform.DOLocalRotate(openRotAngle, 1,RotateMode.LocalAxisAdd);
        transform.localEulerAngles = openRotAngle;
    }
    /// <summary>
    /// 关门
    /// </summary>
    private void CloseTheDoor()
    {
        //transform.DOLocalRotate(closeRotAngle, 1, RotateMode.LocalAxisAdd);
        transform.localEulerAngles = closeRotAngle;
    }
    /// <summary>
    /// 更换为打开状态的材质
    /// </summary>
    public void ChangeToOpenMaterials()
    {
        meshRenderer.materials[0].DOColor(Color.green, 0.1f);
    }
    /// <summary>
    /// 更换为关闭状态的材质
    /// </summary>
    public void ChangeToCloseMaterials()
    {
        automatedChannelsData.state = "Close";//2021.06.21添加，在设置为原状态时要将 automatedChannelsData.state设置为Close

        meshRenderer.materials[0].DOColor(Color.red, 0.1f);
    }
    /// <summary>
    /// 重置为最初的材质球
    /// </summary>
    public void ResetNormalMaterial()
    {
        automatedChannelsData.state = "Close";//2021.06.21添加，在设置为原状态时要将 testBenchData.state设置为Close
        if (meshRenderer.materials.Length > 1)
        {
            for (int i = 0; i < meshRenderer.materials.Length; i++)
            {
                meshRenderer.materials[i] = normalMaterials[i];
            }
        }
        else
        {
            meshRenderer.material = normalMaterials[0];
        }
    }
}
