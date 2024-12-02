using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 根据距离来显示隐藏灯光
/// </summary>
public class VisiableObjForDistance : MonoBehaviour
{
    /// <summary>
    /// 最大范围
    /// </summary>
    public float maxDistance;
    /// <summary>
    /// 判断距离的中心物体
    /// </summary>
    public Transform centerTarget;
    /// <summary>
    /// 可以看到
    /// </summary>
    private bool canSee;
    /// <summary>
    /// 灯光组件
    /// </summary>
    Light lightComponent;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
        canSee = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightComponent == null)
        {
            return;
        }
        if (!canSee && Vector3.Distance(transform.position, centerTarget.position) <= maxDistance)//由不可见变为可见
        {
            SeeObjOnDistance();
        }
        else if (canSee && Vector3.Distance(transform.position, centerTarget.position) > maxDistance)//由可见变为不可见
        {
            LoseSightObjOnDistance();
        }
    }
    /// <summary>
    /// 可见范围
    /// </summary>
    private void SeeObjOnDistance()
    {
        canSee = true;
        lightComponent.enabled = true;
    }
    /// <summary>
    /// 超出范围
    /// </summary>
    private void LoseSightObjOnDistance()
    {
        canSee = false;
        lightComponent.enabled = false;
    }
}
