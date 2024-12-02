using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Tools;
namespace MyPos
{
    /// <summary>
    /// 位置控制器
    /// </summary>
    public class PosController : BaseController
    {
        public PosController(GameFacade facade) : base(facade)
        { }


        Tweener moveTweener;
        /// <summary>
        /// 设置移动DoTween
        /// </summary>
        /// <param name="newTweener"></param>
        public void Set_moveTweener(Tweener newTweener)
        {
            if (moveTweener!=null)
            {
                moveTweener.Kill();
            }
            moveTweener = newTweener;
        }
        /// <summary>
        /// 存放所有相机要去的点
        /// </summary>
        private Dictionary<string, BasePos> allCamPosDict = new Dictionary<string, BasePos>();
        /// <summary>
        /// 当前相机所处的位置
        /// </summary>
        private BasePos currentCamPos;
        /// <summary>
        /// 其他物体当前位置
        /// </summary>
        private BasePos currentOtherPos;

        public override void OnInit()
        {
            InitDict();
            SetTarnsToPos(GameObjIDTool.NearPos, Camera.main.transform,5f);
            
        }

        public override void OnUpdate()
        {

        }

        public override void OnDestory()
        {

        }
       
        /// <summary>
        /// 初始化字典，将所有相机点存放到字典
        /// </summary>
        private void InitDict()
        {
            BasePos[] allBaseCamPos = GameObject.FindObjectsOfType<BasePos>();
            foreach (BasePos item in allBaseCamPos)
            {
                if (!allCamPosDict.ContainsKey(item.GetID()))
                {
                    allCamPosDict.Add(item.GetID(), item);
                    item.Init();
                }
                else
                {
                    Debug.LogError(string.Format("已经存在ID为{0}的相机点", item.GetID()));
                }
            }
        }
        /// <summary>
        /// 通过ID得到点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private BasePos GetBasePos(string id)
        {
            BasePos basePos;
            allCamPosDict.TryGetValue(id, out basePos);
            return basePos;
        }
        /// <summary>
        /// 设置相机到目标点
        /// </summary>
        /// <param name="id"></param>
        /// <param name="targetCam"></param>
        public BasePos SetTarnsToPos(string id, Transform targetTrans,float time=-1f)
        {
            if (currentCamPos!=null)
            {
                currentCamPos.Leave();
            }
            if (currentOtherPos != null)
            {
                currentOtherPos.Leave();
            }
            BasePos baseCamPos = GetBasePos(id);
            baseCamPos.MoveToPoint(targetTrans,time);
            if (targetTrans.GetComponent<Camera>()!=null)
            {
                currentCamPos = baseCamPos; 

            }
            else
            {
                currentOtherPos = baseCamPos;
            }
            return baseCamPos;
        }
        /// <summary>
        /// 获取当前获取当前相机所在位置
        /// </summary>
        /// <returns></returns>
        public BasePos GetCurrentCamPos()
        {
            return currentCamPos;
        }
    }
}
