using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveObjTool;
using UnityEngine.UI;
using DG.Tweening;

namespace Cigarette
{
    /// <summary>
    /// 离开时驾驶变更颜色
    /// </summary>
    public class LeavedChangeColorImagePoint : BaseRoadPoint
    {
        /// <summary>
        /// 变色时间
        /// </summary>
        [SerializeField]
        private float doColorTime;
        /// <summary>
        /// 目标颜色
        /// </summary>
        [SerializeField]
        private Color targetColor;
        // Start is called before the first frame update
        void Start()
        {

        }
        private Tweener tweener;
        public override void ArrivedPoint(BaseMoveObj currentBaseMoveObj)
        {
            base.ArrivedPoint(currentBaseMoveObj);
        }

        public override void LeavedPoint()
        {
            if (currentBaseMoveObj!=null)
            {
                Image image = currentBaseMoveObj.GetComponent<Image>();
                if (image != null)
                {
                    if (tweener!=null)
                    {
                        tweener.Kill();
                    }
                    tweener = image.DOColor(targetColor, doColorTime);
                }
            }
           
            base.LeavedPoint();
        }
        void OnDisable()
        {
            if (tweener != null)
            {
                tweener.Kill();
            }
        }
    }
}