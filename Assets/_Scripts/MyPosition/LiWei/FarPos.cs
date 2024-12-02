using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPos;
using DG.Tweening;
namespace LiWei
{
    /// <summary>
    /// 在海面上的最远距离
    /// </summary>
    public class FarPos : BasePos
    {
        public override void Init()
        {
            base.Init();
        }

        public override void MoveToPoint(Transform trans, float time = -1f)
        {
            base.MoveToPoint(trans);
            trans.DOMove(transform.position, moveTime);
            trans.DOLocalRotateQuaternion(transform.localRotation, moveTime);
            //在此过程中禁用所有相机操作
            GameFacade.Instance.Set_AllCamControll(false);
           
        }

        public override void Leave()
        {
            base.Leave();
        }

        public override void CamArrived()
        {
            base.CamArrived();
            GameFacade.Instance.Set_AllCamControll(true);
        }
    }
}