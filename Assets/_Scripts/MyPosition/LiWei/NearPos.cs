using DG.Tweening;
using MyPos;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
namespace LiWei
{
    /// <summary>
    /// 贴近港口位置
    /// </summary>
    public class NearPos : BasePos
    {
        public override void Init()
        {
            base.Init();
        }

        public override void MoveToPoint(Transform trans, float time = -1f)
        {
            if (time>0)
            {
                moveTime = time; 
            }
            base.MoveToPoint(trans);
            trans.DOMove(transform.position, moveTime).SetEase(Ease.Linear);
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
           GameFacade.Instance. SetTarnsToPos(GameObjIDTool.PortBestPos, Camera.main.transform, 5f);
        }
    }
}
