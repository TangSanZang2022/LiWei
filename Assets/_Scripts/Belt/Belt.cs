using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using UnityOprationalObj;
using System;
/// <summary>
/// 通常皮带皮带挂载脚本，用于更新颜色等功能
/// </summary>
public class Belt : BaseBelt
{
    private MeshRenderer meshRenderer;
    /// <summary>
    /// 默认的材质球
    /// </summary>
    private Material[] normalMaterials;

    private Quaternion normalRot;
    // Start is called before the first frame update
    //protected override void Start()
    //{
    //    base.Start();
       
    //}
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    UpdateObj("");
        //}
        //else if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Reduction();
        //}
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void OnInit()
    {
        base.OnInit();
        meshRenderer = GetComponent<MeshRenderer>();

        normalMaterials = meshRenderer.materials;
        normalRot = transform.localRotation;
    }
    /// <summary>
    /// 更新皮带状态
    /// </summary>
    /// <param name="args"></param>
    public override void UpdateObj(object data)
    {
       // base.UpdateObj(data);
        BeltData beltData = data as BeltData;
        if (beltData.IsRunning == 1)//在转动，变换颜色，且转动
        {
            StartRuning();
            ChangeMaterials();
            Debug.Log(string.Format("转动："));
        }
        else
        { 
            Reduction();
        }
       

    }
    /// <summary>
    /// 停止转动
    /// </summary>
    private void StopRuning()
    {
        StopCoroutine("IRuning");
    }
    /// <summary>
    ///开始转动
    /// </summary>
    private void StartRuning()
    {
        StopCoroutine("IRuning");
        StartCoroutine("IRuning");
    }
    private IEnumerator IRuning()
    {
        float speed=100;
        float angle = 0;
        while (true)
        {
            yield return 0;
            angle += Time.deltaTime*speed;
            transform.localRotation = Quaternion.Euler(Vector3.up* angle);
        }
    }
    /// <summary>
    /// 重置为最初的材质球
    /// </summary>
    private void ResetNormalMaterial()
    {
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
    /// <summary>
    /// 更换材质球
    /// </summary>
    private void ChangeMaterials()
    {
        Material getMaterial = GameFacade.Instance.GetMaterialForName(MaterialsCntroller.Green);
        if (meshRenderer.materials.Length > 1)
        {
            for (int i = 0; i < meshRenderer.materials.Length; i++)
            {
                meshRenderer.materials[i] = getMaterial;
            }
        }
        else
        {
            meshRenderer.material = getMaterial;
        }
    }
     /// <summary>
     /// 还原到
     /// </summary>
    private void ResetNormalRotation()
    {
        transform.localRotation = normalRot;
    }
    /// <summary>
    /// 变为原状态
    /// </summary>
    public override void Reduction()
    {
        base.Reduction();
        StopRuning();
        ResetNormalRotation();
        ResetNormalMaterial();
    }
    /// <summary>
    /// 鼠标放到物体上面的时候调用
    /// </summary>
    protected override void MouseEnterHandle()
    {
        base.MouseEnterHandle();

    }
    /// <summary>
    /// 鼠标移出物体的时候调用
    /// </summary>

    protected override void MouseExitHandle()
    {
        base.MouseExitHandle();

    }



}

[Serializable]
public class BeltDataList
{
    public string ActionCode;

    public List<BeltData> StateInfos;
}
[Serializable]
/// <summary>
/// 皮带的数据类
/// </summary>
public class BeltData
{
    /// <summary>
    /// 皮带ID
    /// </summary>
    public string ID { get => SubsectionNum; }

    /// <summary>
    /// 段位编号
    /// </summary>
    public string SubsectionNum;
    /// <summary>
    /// 运行状态bit0 (是否运行)  1运行  0停止 
    /// </summary>
    public int IsRunning;

    /// <summary>
    /// 报警bit1 (是否报警)  1报警  0无报警
    /// </summary>
    public int IsAlarm;

    /// <summary>
    /// 光电1 bit2 (是否遮挡) 1遮挡  0未遮挡  
    /// </summary>
    public int IsOcclusio_Ph1;


    /// <summary>
    /// 光电2 bit3(是否遮挡) 1遮挡  0未遮挡  
    /// </summary>
    public int IsOcclusio_Ph2;

    /// <summary>
    /// 到位信息bit4  1上升到位  0下降到位
    /// </summary>
    public int Inplace;

    /// <summary>
    /// 报警代码bit5-bit7   000(0)无故障  001(1)滚筒驱动卡故障 010(2)光电1异常(堵包)   011(3)光电2异常(堵包)  100(4)上升异常  101(5)下降异常  
    /// </summary>
    public int AlarmCode;
}