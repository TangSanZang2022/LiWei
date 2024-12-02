using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;

namespace BaseRotObjTool
{
    /// <summary>
    /// 旋转物体
    /// </summary>
    public class BaseRotObj : MonoBehaviour
    {
        /// <summary>
        /// 旋转点配置
        /// </summary>
        [SerializeField]
        private List<RotPointConfig> rotPointConfigs = new List<RotPointConfig>();
        /// <summary>
        /// 是否循环播放
        /// </summary>
        [SerializeField]
        private bool isLoop;
        /// <summary>
        /// 当前正在运行的Tweener
        /// </summary>
        private Tweener tweener;
        /// <summary>
        /// 当前的点序号
        /// </summary>
        [SerializeField]
        private int currentIndex;
        /// <summary>
        /// 原始的旋转
        /// </summary>
        [SerializeField]
        private Vector3 originallocalEulerAngles;
        // Start is called before the first frame update
        void Start()
        {

        }
        /// <summary>
        /// 开始旋转
        /// </summary>
        public virtual void StartChangeRot()
        {
            if (tweener != null)
            {
                tweener.Kill();
            }
            if (currentIndex==0)
            {
                transform.localEulerAngles = originallocalEulerAngles;
            }
            if (currentIndex<= rotPointConfigs.Count-1)//还有点
            {
                RotPointConfig rotPointConfig = rotPointConfigs[currentIndex];
                // tweener = transform.DOLocalRotate(rotPointConfig.pointLocalRotation, rotPointConfig.rotChangeTime).OnComplete(() =>
                tweener = transform.DOLocalRotateQuaternion(Quaternion.Euler( rotPointConfig.pointLocalRotation), rotPointConfig.rotChangeTime).OnComplete(() =>
                {
                    
                    On_tweener_Complete_Everytime();
                    if (rotPointConfig.action!=null)
                    {
                        rotPointConfig.action();
                    }
                    currentIndex++;
                    StartChangeRot();
                }
               );
                tweener.SetEase(rotPointConfig.ease);
            }
            else//到了随后一个点
            {
                currentIndex = 0;
                if (isLoop)//循环
                {
                    StartChangeRot();
                }
            }
            
        }
       
        /// <summary>
        /// 每完成一次旋转之后的回调
        /// </summary>
        public virtual void On_tweener_Complete_Everytime()
        {

        }

       

    }
    /// <summary>
    /// 旋转点的配置
    /// </summary>
    [Serializable]
    public class RotPointConfig
    {
        /// <summary>
        /// 旋转动画时长
        /// </summary>
        public float rotChangeTime;
        /// <summary>
        /// doTween的方式，线性匀速还是其他方式
        /// </summary>
        public Ease ease;
        /// <summary>
        /// 这个点的角度开始的角度
        /// </summary>
        public Vector3 pointLocalRotation;
        /// <summary>
        /// 到达之后的事件
        /// </summary>
        public UnityAction action;
    }
}
