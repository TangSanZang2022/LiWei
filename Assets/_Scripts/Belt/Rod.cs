using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
/// <summary>
/// RodBelt皮带的子物体，用于更换颜色和旋转
/// </summary>
public class Rod : MonoBehaviour, IUpdateHandle
{
    [SerializeField]
    /// <summary>
    /// 是否是向右旋转
    /// </summary>
    private bool isRightRotDir;
    private MeshRenderer meshRenderer;
    /// <summary>
    /// 默认的材质球
    /// </summary>
    private Material[] normalMaterials;

    private Quaternion normalRot;
    /// <summary>
    /// 当前皮带对应的皮带数据
    /// </summary>
    private BeltData beltData;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        normalMaterials = meshRenderer.materials;
        normalRot = transform.localRotation;
    }


    /// <summary>
    /// 停止转动
    /// </summary>
    public void StopRuning()
    {
        StopCoroutine("IRuning");
    }
    /// <summary>
    ///开始转动
    /// </summary>
    public void StartRuning()
    {
        StopCoroutine("IRuning");
        StartCoroutine("IRuning");
    }
    private IEnumerator IRuning()
    {
        float speed = 10;
        int dir;
        dir = isRightRotDir == true ? 1 : -1;
        //float angle = 0;
        while (true)
        {
            yield return 0;
            // angle += Time.deltaTime * speed;
            transform.Rotate(Vector3.right * speed * dir, Space.Self);
        }
    }
    /// <summary>
    /// 更换为转动的材质球
    /// </summary>
    public void ChangeToRotateMaterials()
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
    /// 警报闪烁为红色的材质球
    /// </summary>
    public void ChangeToAlarmMaterialsToRed()
    {
        if (beltData.IsAlarm == 0)
        {
            return;
        }
        Material getMaterial = GameFacade.Instance.GetMaterialForName(MaterialsCntroller.Red);
        if (meshRenderer.materials.Length > 1)
        {
            for (int i = 0; i < meshRenderer.materials.Length; i++)
            {
                meshRenderer.materials[i] = getMaterial;
                meshRenderer.materials[i].DOColor(Color.red, 0.3f).OnComplete(() => ChangeToAlarmMaterialsToWhite());
            }
        }
        else
        {
            meshRenderer.material = getMaterial;
            meshRenderer.material.DOColor(Color.red, 0.3f).OnComplete(() => ChangeToAlarmMaterialsToWhite());
        }
    }
    /// <summary>
    /// 警报闪烁为白色的材质球
    /// </summary>
    public void ChangeToAlarmMaterialsToWhite()
    {
        if (beltData.IsAlarm == 0)
        {
            return;
        }
        Material getMaterial = GameFacade.Instance.GetMaterialForName(MaterialsCntroller.Red);
        if (meshRenderer.materials.Length > 1)
        {
            for (int i = 0; i < meshRenderer.materials.Length; i++)
            {
                meshRenderer.materials[i] = getMaterial;
                meshRenderer.materials[i].DOColor(Color.white, 0.3f).OnComplete(() => ChangeToAlarmMaterialsToRed());
            }
        }
        else
        {
            meshRenderer.material = getMaterial;
            meshRenderer.material.DOColor(Color.white, 0.3f).OnComplete(() => ChangeToAlarmMaterialsToRed());
        }
    }
    /// <summary>
    /// 更换为报警材质球
    /// </summary>
    public void ChangeToAlarmMaterials()
    {
        Material getMaterial = GameFacade.Instance.GetMaterialForName(MaterialsCntroller.Red);
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
    /// 重置为最初的材质球
    /// </summary>
    public void ResetNormalMaterial()
    {
        beltData.IsAlarm = 0;//2021.06.21添加，在设置为原状态时要将 beltData.IsAlarm设置为0，用来暂停报警皮带的闪烁效果
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
    /// 还原到
    /// </summary>
    public void ResetNormalRotation()
    {
        transform.localRotation = normalRot;
    }
    /// <summary>
    /// 更新操作
    /// </summary>
    public void UpdateHandle(object data)
    {
        this.beltData = data as BeltData;
        if (beltData.IsRunning == 1 && beltData.IsAlarm == 0) //转动
        {
            StartRuning();
            ChangeToRotateMaterials();
        }
        else if (beltData.IsAlarm == 0)
        {
            ReductionNormalState();
        }
        else
        {
            StopRuning();
            // ChangeToAlarmMaterials();//将报警的皮带变为红色
            ChangeToAlarmMaterialsToRed();//2021.06.21修改报警的皮带颜色在红色和原来颜色之间变换
        }
        //if (beltData.IsAlarm==1)
        //{
        //    StopRuning();
        //    ChangeToAlarmMaterials();
        //    //StartCoroutine("MaterialTwinkle");
        //}
        //else 
        //{
        //    ReductionNormalState();
        //}
    }

    /// <summary>
    /// 恢复初始状态
    /// </summary>
    public void ReductionNormalState()
    {
        StopRuning();
        ResetNormalRotation();
        ResetNormalMaterial();
    }
}
