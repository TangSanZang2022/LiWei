using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// 拓展类
/// </summary>
public static class MyExtension
{
    /// <summary>
    /// 获取子物体中T类型，除去父物体和子物体的子物体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="trans"></param>
    /// <returns></returns>
    public static T[] GetComponentsExceptParentAndChildedChild<T>(this Transform trans)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < trans.childCount; i++)
        {
            int index = i;
            T t = trans.GetChild(index).GetComponent<T>();
            if (t != null)
            {
                list.Add(t);
            }
        }
        return list.ToArray();
    }

    /// <summary>
    /// 获取子物体中T类型，除去父物体和子物体的子物体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public static T[] GetComponentsExceptParentAndChildedChild<T>(this GameObject go)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < go.transform.childCount; i++)
        {
            int index = i;
            T t = go.transform.GetChild(index).GetComponent<T>();
            if (t != null)
            {
                list.Add(t);
            }

        }
        return list.ToArray();
    }

    /// <summary>
    /// 根据子物体的名称，找到子物体
    /// </summary>
    /// <param name="currentTransform">子物体所在层级</param>
    /// <param name="childName">子物体名称</param>
    /// <returns></returns>
    public static Transform FindChildForName(this Transform currentTransform, string childName)
    {
        Transform childTrans = currentTransform.Find(childName);
        if (childTrans != null)
        {
            return childTrans;
        }
        for (int i = 0; i < currentTransform.childCount; i++)
        {
            childTrans = FindChildForName(currentTransform.GetChild(i), childName);
            if (childTrans != null)
            {
                return childTrans;
            }
        }
        return null;
    }
    /// <summary>
    /// 围绕物体旋转
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="center"></param>
    /// <param name="axis"></param>
    /// <param name="angle"></param>
    public static void MyRotateAround(this Transform transform, Vector3 center, Vector3 axis, float angle, float t)
    {

        Vector3 pos = transform.position;
        Quaternion rot = Quaternion.AngleAxis(angle, axis);
        Vector3 dir = pos - center; //计算从圆心指向摄像头的朝向向量
        dir = rot * dir;            //旋转此向量
        transform.position = Vector3.Lerp(transform.position, center + dir, t);//移动摄像机位置
                                                                               // transform.DOMove(center + dir, t);
        Quaternion myrot = transform.rotation;
        //transform.rotation *= Quaternion.Inverse(myrot) * rot *myrot;//设置角度另一种方法
        transform.rotation = Quaternion.Lerp(transform.rotation, rot * myrot, t); //设置角度
                                                                                  // transform.DORotate((rot * myrot).eulerAngles, t);
    }
    /// <summary>
    /// 围绕物体旋转
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="center"></param>
    /// <param name="axis"></param>
    /// <param name="angle"></param>
    public static void DOMyRotateAround(this Transform transform, Vector3 center, Vector3 axis, float angle, float t)
    {

        Vector3 pos = transform.position;
        Quaternion rot = Quaternion.AngleAxis(angle, axis);
        Vector3 dir = pos - center; //计算从圆心指向摄像头的朝向向量
        dir = rot * dir;            //旋转此向量
                                    // transform.position = Vector3.Lerp(transform.position, center + dir, t);//移动摄像机位置
        transform.DOMove(center + dir, t);
        Quaternion myrot = transform.rotation;
        //transform.rotation *= Quaternion.Inverse(myrot) * rot *myrot;//设置角度另一种方法
        //transform.rotation = Quaternion.Lerp(transform.rotation, rot * myrot, t); //设置角度
        transform.DORotate((rot * myrot).eulerAngles, t);
    }
    /// <summary>
    /// 判断物体是否被隐藏，包括父物体
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static bool IsSelfActive(this GameObject go)
    {
        Transform parentTrans = go.transform.parent;

        if (go.activeSelf)
        {
            if (parentTrans != null)
            {
                if (!parentTrans.gameObject.activeSelf)
                {
                    return false;
                }
                else
                {
                    return parentTrans.gameObject.IsSelfActive();
                }
            }
            else
            {
                return go.activeSelf;
            }
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// string转换为float
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static float StringToFloat(string content, float defultValue)
    {
        float f;
        if (!float.TryParse(content, out f))
        {
            f = defultValue;
        }
        return f;

    }

    /// <summary>
    /// 根据键从字典中获取对应的值
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="keyValuePairs"></param>
    /// <param name="keyStr"></param>
    /// <returns></returns>
    public static T GetValueInDictionary<Q, T>(this Dictionary<Q, T> keyValuePairs, Q keyStr) where T : Object
    {
        if (!keyValuePairs.ContainsKey(keyStr))
        {
            return null;
        }
        return keyValuePairs[keyStr];
    }

    /// <summary>
    /// 给动画添加事件
    /// </summary>
    /// <param name="animator">动画状态机</param>
    /// <param name="ClipName">动画clip名称</param>
    /// <param name="functionName">事件方法名称</param>
    /// <param name="animationEventTime">触发事件的时间,如果为-1，则为动画结束前的0.1秒</param>
    public static void AddAnimEvent(this Animator animator, string ClipName, string functionName, float animationEventTime = -1)
    {

        RuntimeAnimatorController runtimeAnimatorController = animator.runtimeAnimatorController;
        AnimationClip currentAnimClip;
        for (int i = 0; i < runtimeAnimatorController.animationClips.Length; i++)
        {
            Debug.Log(runtimeAnimatorController.animationClips[i].name);
            if (runtimeAnimatorController.animationClips[i].name == ClipName)
            {
                currentAnimClip = runtimeAnimatorController.animationClips[i];
                AnimationEvent animationEvent = new AnimationEvent();
                animationEvent.functionName = functionName;
                if (animationEventTime == -1)
                {
                    animationEventTime = currentAnimClip.length - 0.1f;
                }
                Debug.Log("动画时间为：" + (currentAnimClip.length - 0.1f));
                animationEvent.time = animationEventTime;
                currentAnimClip.AddEvent(animationEvent);
                break;
            }
        }
    }
    /// <summary>
    /// 给动画添加事件
    /// </summary>
    /// <param name="animator">动画状态机</param>
    /// <param name="ClipName">动画clip名称</param>
    /// <param name="functionName">事件方法名称</param>
    /// <param name="stringParameter">string参数</param> 
    /// <param name="animationEventTime">触发事件的时间,如果为-1，则为动画结束前的0.1秒</param>
    public static void AddAnimEvent(this Animator animator, string ClipName, string functionName, string stringParameter, float animationEventTime = -1)
    {

        RuntimeAnimatorController runtimeAnimatorController = animator.runtimeAnimatorController;
        AnimationClip currentAnimClip;
        for (int i = 0; i < runtimeAnimatorController.animationClips.Length; i++)
        {
            Debug.Log(runtimeAnimatorController.animationClips[i].name);
            if (runtimeAnimatorController.animationClips[i].name == ClipName)
            {
                currentAnimClip = runtimeAnimatorController.animationClips[i];
                AnimationEvent animationEvent = new AnimationEvent();
                animationEvent.functionName = functionName;
                animationEvent.stringParameter = stringParameter;
                if (animationEventTime == -1)
                {
                    animationEventTime = currentAnimClip.length - 0.1f;
                }
                Debug.Log("动画时间为：" + (currentAnimClip.length - 0.1f));
                animationEvent.time = animationEventTime;
                currentAnimClip.AddEvent(animationEvent);
                break;
            }
        }
    }
    /// <summary>
    /// 给动画添加事件
    /// </summary>
    /// <param name="animator">动画状态机</param>
    /// <param name="ClipName">动画clip名称</param>
    /// <param name="functionName">事件方法名称</param>
    /// <param name="floatParameter">float参数</param>
    /// <param name="animationEventTime">触发事件的时间,如果为-1，则为动画结束前的0.1秒</param>
    public static void AddAnimEvent(this Animator animator, string ClipName, string functionName, float floatParameter, float animationEventTime = -1)
    {

        RuntimeAnimatorController runtimeAnimatorController = animator.runtimeAnimatorController;
        AnimationClip currentAnimClip;
        for (int i = 0; i < runtimeAnimatorController.animationClips.Length; i++)
        {
            Debug.Log(runtimeAnimatorController.animationClips[i].name);
            if (runtimeAnimatorController.animationClips[i].name == ClipName)
            {
                currentAnimClip = runtimeAnimatorController.animationClips[i];
                AnimationEvent animationEvent = new AnimationEvent();
                animationEvent.functionName = functionName;
                animationEvent.floatParameter = floatParameter;
                if (animationEventTime == -1)
                {
                    animationEventTime = currentAnimClip.length - 0.1f;
                }
                Debug.Log("动画时间为：" + (currentAnimClip.length - 0.1f));
                animationEvent.time = animationEventTime;
                currentAnimClip.AddEvent(animationEvent);
                break;
            }
        }
    }
    /// <summary>
    /// 给动画添加事件
    /// </summary>
    /// <param name="animator">动画状态机</param>
    /// <param name="ClipName">动画clip名称</param>
    /// <param name="functionName">事件方法名称</param>
    /// <param name="intParameter">int参数</param>
    /// <param name="animationEventTime">触发事件的时间,如果为-1，则为动画结束前的0.1秒</param>
    public static void AddAnimEvent(this Animator animator, string ClipName, string functionName, int intParameter, float animationEventTime = -1)
    {

        RuntimeAnimatorController runtimeAnimatorController = animator.runtimeAnimatorController;
        AnimationClip currentAnimClip;
        for (int i = 0; i < runtimeAnimatorController.animationClips.Length; i++)
        {
            Debug.Log(runtimeAnimatorController.animationClips[i].name);
            if (runtimeAnimatorController.animationClips[i].name == ClipName)
            {
                currentAnimClip = runtimeAnimatorController.animationClips[i];
                AnimationEvent animationEvent = new AnimationEvent();
                animationEvent.functionName = functionName;
                animationEvent.intParameter = intParameter;
                if (animationEventTime == -1)
                {
                    animationEventTime = currentAnimClip.length - 0.1f;
                }
                Debug.Log("动画时间为：" + (currentAnimClip.length - 0.1f));
                animationEvent.time = animationEventTime;
                currentAnimClip.AddEvent(animationEvent);
                break;
            }
        }
    }
    /// <summary>
    /// 设置材质球渲染模式
    /// </summary>
    /// <param name="material"></param>
    /// <param name="renderingMode"></param>
    public static void SetMaterialRenderingMode(this Material material, RenderingMode renderingMode)
    {
        switch (renderingMode)
        {
            case RenderingMode.Opaque:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case RenderingMode.Cutout:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case RenderingMode.Fade:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case RenderingMode.Transparent:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.SetFloat("_BumpScale", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }
    }
}
public enum RenderingMode
{
    Opaque,
    Cutout,
    Fade,
    Transparent,
}
