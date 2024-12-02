using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 检验台上面的数字牌
/// </summary>
public class TestBenchNum : MonoBehaviour, IUpdateHandle
{
    private MeshRenderer meshRenderer;
    /// <summary>
    /// 默认的材质球
    /// </summary>
    private Material[] normalMaterials;
    /// <summary>
    /// 检验台的数据
    /// </summary>
    private TestBenchData testBenchData;
    public void ReductionNormalState()
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// 更新检验台上面的数字牌
    /// </summary>
    /// <param name="data"></param>
    public void UpdateHandle(object data)
    {
        this.testBenchData = data as TestBenchData;
        if (testBenchData.state=="Open")//打开状态
        {
            ChangeToOpenMaterials();
        }
        else
        {
            ChangeToCloseMaterials();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        normalMaterials = meshRenderer.materials;
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 更换为打开状态的材质
    /// </summary>
    public void ChangeToOpenMaterials()
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
    /// 更换为关闭状态的材质
    /// </summary>
    public void ChangeToCloseMaterials()
    {
        testBenchData.state = "Close";//2021.06.21添加，在设置为原状态时要将 testBenchData.state设置为Close
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
       testBenchData.state ="Close";//2021.06.21添加，在设置为原状态时要将 testBenchData.state设置为Close
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
