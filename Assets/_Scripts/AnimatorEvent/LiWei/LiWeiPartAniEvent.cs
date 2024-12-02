using MyAnimEventTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LiWei
{
    /// <summary>
/// 利维港口部件动画事件
/// </summary>
    public class LiWeiPartAniEvent : MonoBehaviour
    {
        /// <summary>
        /// 动画完成之后事件
        /// </summary>
        public void AniEndEvent()
        {
            IAnimEvent animEndEvent = GetComponentInParent<IAnimEvent>();
            Debug.Log(animEndEvent);
            if (animEndEvent != null)
            {
                animEndEvent.AniEndEvent();
            }

        }


    }
}
