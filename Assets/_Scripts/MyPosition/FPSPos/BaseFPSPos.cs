using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;
using MyPos;

namespace DFDJ
{
    /// <summary>
    /// FPS位置基类
    /// </summary>
    public class BaseFPSPos : BasePos
    {
        /// <summary>
        /// 第一人称控制器
        /// </summary>
        protected FirstPersonController personController;
        /// <summary>
        /// 导航组件
        /// </summary>
        protected NavMeshAgent meshAgent;
        public override void Init()
        {
            base.Init();
        }

        public override void MoveToPoint(Transform trans,float time=-1f)
        {
            base.MoveToPoint(trans);
            personController = moveObjTransform.GetComponent<FirstPersonController>();
            meshAgent = moveObjTransform.GetComponent<NavMeshAgent>();
            meshAgent.enabled = false;
            personController.enabled = false;
            moveObjTransform.position = transform.position;
            moveObjTransform.rotation = transform.rotation;
            //StartCoroutine(IWaitCameraArrived());
        }

        public override void CamArrived()
        {
            base.CamArrived();
            meshAgent.enabled = true;
            personController.enabled = true;
            personController.Init();
           
        }

        public override void Leave()
        {
            base.Leave();
            meshAgent.enabled = false;
            personController.enabled = false;
        }
    }
}