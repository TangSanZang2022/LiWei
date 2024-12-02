﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyPos
{
    /// <summary>
    /// 位置基类
    /// </summary>
    public class BasePos : MonoBehaviour
    {
        [SerializeField]
        /// <summary>
        /// 移动到此点的时间
        /// </summary>
        protected float moveTime=3f;
        [SerializeField]
        /// <summary>
        /// ID
        /// </summary>
        protected string id;

        /// <summary>
        /// 要移动到这个点的物体Transform,用来检查相机是否到达点
        /// </summary>
        protected Transform moveObjTransform;
        /// <summary>
        /// 获取ID
        /// </summary>
        /// <returns></returns>
        public string GetID()
        {
            return id;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            if (string.IsNullOrEmpty(id))
            {
                id = gameObject.name;
            }
        }

        /// <summary>
        /// 向点此点移动移动
        /// </summary>
        /// <param name="trans">要移动的物体</param>
        /// <param name="time">移动的时间</param>
        public virtual void MoveToPoint(Transform trans,float time=-1f)
        {
            if (time!=-1)
            {
                moveTime = time;
            }
            moveObjTransform = trans;
            StartCoroutine(IWaitCameraArrived());
        }
        /// <summary>
        /// 检测相机是否到达
        /// </summary>
        /// <returns></returns>
       public IEnumerator IWaitCameraArrived()
        {
            yield return new WaitForSeconds(0.2f);
            //Debug.Log(Vector3.Distance(moveObjTransform.position, transform.position));
            //yield return  ();
            yield return new WaitUntil(() => Vector3.Distance(moveObjTransform.position, transform.position) <= 0.01f);
            CamArrived();
        }
        /// <summary>
        /// 相机到达
        /// </summary>
        public virtual void CamArrived()
        {


        }
        /// <summary>
        /// 相机离开
        /// </summary>
        public virtual void Leave()
        {
            Debug.Log(string.Format("相机离开ID为{0}的位置", GetID()));
        }
    }
}

