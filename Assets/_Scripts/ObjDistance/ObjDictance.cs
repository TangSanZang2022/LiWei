using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace DFDJ
{
    /// <summary>
    /// 计算物体之间的距离
    /// </summary>
    public class ObjDictance : MonoBehaviour
    {

        /// <summary>
        /// 开始目标点，如果为空，则默认为自己
        /// </summary>
        public Transform startTransTarget;
        /// <summary>
        /// 计算距离的目标点
        /// </summary>
        public Transform targetTrans;
        /// <summary>
        /// 实时距离
        /// </summary>
        public float distanceFromTargetTrans;
        /// <summary>
        /// 阈值
        /// </summary>
        public float ThresholdValue;
        /// <summary>
        /// 是否小于阈值
        /// </summary>
        bool isLessThanThresholdValue = false;
     
        /// <summary>
        /// 开始小于阈值
        /// </summary>
        public UnityAction BecomeLessThanThresholdValue;
        /// <summary>
        /// 开始大于阈值
        /// </summary>
        public UnityAction BecomeGreaterThanThresholdValue;
        // Start is called before the first frame update
        void Start()
        {
            if (startTransTarget==null)
            {
                startTransTarget = transform;
            }
        }

        // Update is called once per frame
        void Update()
        {
            distanceFromTargetTrans = Vector3.Distance(startTransTarget.position, targetTrans.position);
            if (distanceFromTargetTrans <ThresholdValue&& !isLessThanThresholdValue )
            {
                isLessThanThresholdValue = true;
                if (BecomeLessThanThresholdValue != null)
                {
                    BecomeLessThanThresholdValue();
                }
               
            }
            if (distanceFromTargetTrans>ThresholdValue && isLessThanThresholdValue)
            {
                isLessThanThresholdValue = false;
                if (BecomeGreaterThanThresholdValue != null)
                {
                    BecomeGreaterThanThresholdValue();
                }
            }
        }
        /// <summary>
        /// 可见
        /// </summary>
        private void OnBecameVisible()
        {
            
        }
        /// <summary>
        /// 不可见
        /// </summary>
        private void OnBecameInvisible()
        {
            
        }
    }
}
