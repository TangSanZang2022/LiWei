using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPos;
using DG.Tweening;
namespace LiWei
{
    /// <summary>
    /// 港口最佳视角位置
    /// </summary>
    public class PortBestPos : BasePos
    {
        
        public override void Init()
        {
            base.Init();
        }

        
        /// <summary>
        /// 向此点移动
        /// </summary>
        /// <param name="trans"></param>
        public override void MoveToPoint(Transform trans, float time = -1f)
        {
            if (time!=-1)
            {
                moveTime = time;
            }
            
            base.MoveToPoint(trans);
            GameFacade.Instance.Set_AllCamControll(false);
            trans.DOMove(transform.position, moveTime);
            trans.DOLocalRotateQuaternion(transform.localRotation, moveTime);

        }

        public override void CamArrived()
        {
            base.CamArrived();
            GameFacade.Instance.Set_AllCamControll(true);
            moveTime = 3;
        }

        public override void Leave()
        {
            base.Leave();
        }
    }
}
