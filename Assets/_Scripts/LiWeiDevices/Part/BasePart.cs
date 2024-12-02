using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using System;
namespace LiWei
{
    /// <summary>
    /// 部件基类
    /// </summary>
    public class BasePart : MonoBehaviour
    {
        [SerializeField]
        /// <summary>
        /// 设备ID
        /// </summary>
        protected string id;
        [SerializeField]
        /// <summary>
        /// 设备名称
        /// </summary>
        protected string partName;
        /// <summary>
        /// 相机移动到最佳视角时间
        /// </summary>
        protected float camMmoveToBestViewPosTime =1f;
        /// <summary>
        /// 此部件属于哪个组
        /// </summary>
        protected BasePartGroup partGroup;
        [SerializeField]
        /// <summary>
        /// 部件数据
        /// </summary>
        private PartData partData;
        /// <summary>
        /// 是否是透视模式
        /// </summary>
        private bool isFadeState;
        // Start is called before the first frame update
      protected virtual  void Start()
        {
            boxCollider.enabled = false;
            Set_DetailsActive(false);
            isFadeState = false;
        }
        private Transform bestViewPos;
        /// <summary>
        /// 最佳视角位置
        /// </summary>
        public Transform BestViewPos
        {
            get
            {
                if (bestViewPos == null)
                {
                    bestViewPos = transform.FindChildForName("BestViewPos");
                }
                return bestViewPos;
            }
        }

        private Transform rotCenter;
        /// <summary>
        /// 旋转中心
        /// </summary>
        public Transform RotCenter
        {
            get
            {
                if (rotCenter == null)
                {
                    rotCenter = transform.FindChildForName("RotCenter");
                }
                return rotCenter;
            }
        }
        private Transform zoomCenter;
        /// <summary>
        /// 缩放中心
        /// </summary>
        public Transform ZoomCenter
        {
            get
            {
                if (zoomCenter == null)
                {
                    zoomCenter = transform.FindChildForName("ZoomCenter");
                }
                return zoomCenter;
            }
        }

        private GameObject models;
        /// <summary>
        /// 设备模型，用于显示隐藏
        /// </summary>
        public GameObject Models
        {
            get
            {
                if (models == null)
                {
                    models = transform.FindChildForName("Models").gameObject;
                }
                return models;
            }
        }
        private Transform camTrans;


        /// <summary>
        /// 相机
        /// </summary>
        private Transform CamTrans
        {
            get
            {
                if (camTrans == null)
                {
                    camTrans = Camera.main.transform;
                }
                return camTrans;
            }
        }

        private BoxCollider _boxCollider;
        /// <summary>
        /// 用于检测鼠标点击的碰撞器
        /// </summary>
        public BoxCollider boxCollider
        {
            get
            {
                if (_boxCollider == null)
                {
                    _boxCollider = GetComponent<BoxCollider>();
                }
                return _boxCollider;
            }
        }

        private MaterialStateChange fadeObj;
        /// <summary>
        /// 可透明物体
        /// </summary>
        public MaterialStateChange FadeObj
        {
            get
            {
                if (fadeObj == null)
                {
                    fadeObj =transform.FindChildForName(GameObjIDTool.FadeObj). GetComponent<MaterialStateChange>();
                }
                return fadeObj;
            }
        }

        private Animator _animator;
        /// <summary>
        /// 动画状态机
        /// </summary>
        public Animator animator
        {
            get
            {
                if (_animator==null)
                {
                    _animator = transform.FindChildForName(GameObjIDTool.AniObj).GetChild(0).GetComponent<Animator>();
                }
                return _animator;
            }
        }

        private HighlighterObj _highlighterObj;
        /// <summary>
        /// 高亮组件
        /// </summary>
        public HighlighterObj highlighterObj
        {
            get
            {
                if (_highlighterObj==null)
                {
                    _highlighterObj = GetComponent<HighlighterObj>();
                    if (_highlighterObj==null)
                    {
                        _highlighterObj = gameObject.AddComponent<HighlighterObj>();
                    }
                }
                return _highlighterObj;
            }
        }
        private GameObject details;
        /// <summary>
        /// 细节UI
        /// </summary>
        public GameObject Details
        {
            get
            {
                if (details==null)
                {
                    details = transform.FindChildForName(GameObjIDTool.Details).gameObject;
                }
                return details;
            }
        }

        [Tooltip("设备状态为正常的时候的颜色")]
        [SerializeField]
        /// <summary>
        /// 设备状态为正常的时候的颜色
        /// </summary>
        private Color normalColor = new Color32(0, 161, 254, 255);
        [Tooltip("设备状态为异常的时候的颜色")]
        [SerializeField]
        /// <summary>
        /// 设备状态为异常的时候的颜色
        /// </summary>
        private Color abnormalColor = new Color32(255, 66, 66, 255);

      
        /// <summary>
        /// 获取ID
        /// </summary>
        /// <returns></returns>
        public string Get_id()
        {
            return id;
        }
        /// <summary>
        /// 获取部件名称
        /// </summary>
        /// <returns></returns>
        public string Get_partNamee()
        {
            return partName;
        }
        /// <summary>
        /// 设置组
        /// </summary>
        /// <param name="partGroup"></param>
        public void Set_partGroup(BasePartGroup partGroup)
        {
            this.partGroup = partGroup;
        }
        /// <summary>
        /// 获取当前组
        /// </summary>
        /// <returns></returns>
        public BasePartGroup Get_partGroup()
        {
            return partGroup;
        }
        private void OnMouseDown()
        {
          
           partGroup.Set_currentPart(this);

        }
        /// <summary>
        /// 相机到达之后委托
        /// </summary>
        public virtual void ArriveBestViewPos()
        {
            GameFacade.Instance.Set_lock_rotTarget(true);
            GameFacade.Instance.Set_lock_ZoomTarget(true);
            GameFacade.Instance.Set_canRot(true);
            GameFacade.Instance.Set_canZoom(true);
            Get_partGroup().Models.SetActive(false);
            Get_partGroup(). baseDevices.Models.gameObject.SetActive(false);
            GameFacade.Instance.Set_SceneOtherModel_Active(false);
            GameFacade.Instance.Set_CamTransCanvas_Active(true);
            GameFacade.Instance.ShowCurrentDevices();
            Get_partGroup().baseDevices.Models.SetActive(false);
            boxCollider.enabled = false;
            Set_DetailsActive(true);
        }
        /// <summary>
        /// 设置细节的显示隐藏状态
        /// </summary>
        /// <param name="active"></param>
        public void Set_DetailsActive(bool active)
        {
            if (Details != null)
            {
                Details.SetActive(active);
             }
        }
        /// <summary>
        /// 将外壳变为半透明
        /// </summary>
        public void Fade(float alpha=0.1f,float fadeTime=5f)
        {
            FadeObj.Fade(alpha, fadeTime);
        }

        /// <summary>
        /// 变回原来的颜色
        /// </summary>
        /// <param name="returnTime"></param>
        public void Return(float returnTime = 2f)
        {
            FadeObj.Return(returnTime);
        }
        /// <summary>
        /// 透视模式
        /// </summary>
        public void SetToFadeMode(float alpha = 0.1f, float fadeTime = 5f)
        {
            //FadeObj.gameObject.SetActive(true);
            //Set_DetailsActive(true);
            //Fade(alpha, fadeTime);
            if (!isFadeState)
            {
                
                ReturnTOBestViewPos();
                Fade(alpha, fadeTime);
                animator.ResetTrigger("Play");
                animator.ResetTrigger("Return");
                animator.SetTrigger("Return");
                isFadeState = true;
            }
           
        }

        /// <summary>
        /// 爆炸模式
        /// </summary>
        public void SetToBombMode()
        {
            //if (isFadeState)
            //{
                ReturnTOBestViewPos();
                FadeObj.gameObject.SetActive(false);
                Set_DetailsActive(false);
                animator.ResetTrigger("Play");
                animator.ResetTrigger("Return");
                animator.SetTrigger("Play");
                isFadeState = false;
            //}
           

        }
        /// <summary>
        /// 恢复为默认状态
        /// </summary>
        public void ReturnToNormalState()
        {
            //SetToBestViewPos();
            FadeObj.gameObject.SetActive(true);
           
            Return();
            animator.ResetTrigger("Play");
            animator.ResetTrigger("Return");
            animator.SetTrigger("Return");
            isFadeState = false;

        }

        private void ReturnTOBestViewPos()
        {
           
            CamTrans.DOKill();
            CamTrans.DOMove(BestViewPos.position, camMmoveToBestViewPosTime);
            CamTrans.DOLocalRotate(BestViewPos.localEulerAngles, camMmoveToBestViewPosTime);
            GameFacade.Instance.Set_zoomTarget(ZoomCenter.position);
            GameFacade.Instance.Set_rotTarget(RotCenter.position);
        }
        /// <summary>
        /// 设置到最佳视角
        /// </summary>
        public virtual void SetToBestViewPos()
        {
            GameFacade.Instance.Set_canRot(false);
            GameFacade.Instance.Set_canZoom(false);
            CamTrans.DOKill();
            CamTrans.DOMove(BestViewPos.position, camMmoveToBestViewPosTime).OnComplete(() => ArriveBestViewPos());
            CamTrans.DOLocalRotate(BestViewPos.localEulerAngles, camMmoveToBestViewPosTime);
            GameFacade.Instance.Set_zoomTarget(ZoomCenter.position);
            GameFacade.Instance.Set_rotTarget(RotCenter.position);
            GameFacade.Instance.Set_currentDevicesOnlyChangeValue(Get_partGroup().baseDevices);
            //GameFacade.Instance.ShowCurrentDevices();
            //if (Get_partGroup().baseDevices)
            //{
            //    Set_partGroup
            //}
        }
        /// <summary>
        /// 设置设备数据
        /// </summary>
        /// <param name="partData"></param>
        public virtual void Set_partData(PartData partData)
        {
            this.partData = partData;
            if (partData.state=="正常")
            {
                highlighterObj.Set_Color(normalColor, normalColor);
            }
            else
            {
                highlighterObj.Set_Color(abnormalColor, abnormalColor);
            }
        }

        /// <summary>
        /// 开始高亮
        /// </summary>
        public void StartHighLighting()
        {
            if (partData.state == "正常")
            {
                highlighterObj.Set_Color(normalColor, normalColor);
            }
            else
            {
                highlighterObj.Set_Color(abnormalColor, abnormalColor);
            }
            highlighterObj.StartHighLighting();
        }

        /// <summary>
        /// 停止高亮
        /// </summary>
        public void StopHighLighting()
        {
            highlighterObj.StopHighLighting();
        }

    }
    /// <summary>
    /// 部件数据
    /// </summary>
    [Serializable]
    public class PartData
    {
        /// <summary>
        /// 正常异常状态
        /// </summary>
        public string state;
    }
}