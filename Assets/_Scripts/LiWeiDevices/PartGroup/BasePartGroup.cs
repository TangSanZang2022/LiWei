using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
namespace LiWei
{
    /// <summary>
    /// 利维港口部件父物体
    /// </summary>
    public class BasePartGroup : MonoBehaviour
    {
        [Tooltip("默认部件ID")]
        [SerializeField]
        /// <summary>
        /// 默认部件ID
        /// </summary>
        private string defaultPartID= "ElectricMachine01";
        /// <summary>
        /// 相机移动到最佳视角时间
        /// </summary>
        private float camMmoveToBestViewPosTime = 1f;

        /// <summary>
        /// 当前选中的部件
        /// </summary>
        private BasePart currentPart;
        // Start is called before the first frame update
        void Start()
        {
            //boxColliders.enabled = false;
            ShowHide_boxColliders(false);
            Add_allBasePartDic();
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

        private List< BoxCollider> _boxColliders;
        /// <summary>
        /// 用于检测鼠标点击的碰撞器
        /// </summary>
        public List<BoxCollider> boxColliders
        {
            get
            {
                if (_boxColliders==null)
                {
                    _boxColliders = new List<BoxCollider>();
                    _boxColliders .AddRange( GetComponents<BoxCollider>());
                }
                return _boxColliders;
            }
        }

        private LiWeiBaseDevices _baseDevices;
        /// <summary>
        /// 父物体的设备
        /// </summary>
        public LiWeiBaseDevices baseDevices
        {
            get
            {
                if (_baseDevices==null)
                {
                    _baseDevices = GetComponentInParent<LiWeiBaseDevices>();
                }
                return _baseDevices;
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
                    fadeObj = transform.FindChildForName("Models").FindChildForName(GameObjIDTool.FadeObj).GetComponent<MaterialStateChange>();
                }
                return fadeObj;
            }
        }
        /// <summary>
        /// 存放所有部件的字典
        /// </summary>
        private Dictionary<string, BasePart> allBasePartDic = new Dictionary<string, BasePart>();

        /// <summary>
        /// 获取所有部件字典
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, BasePart> Get_allBasePartDic()
        {
            return allBasePartDic;
        }
        /// <summary>
        /// 添加所有的部件到字典中
        /// </summary>
        private void Add_allBasePartDic()
        {
            BasePart[] baseDevices = transform.GetComponentsExceptParentAndChildedChild<BasePart>();
            foreach (BasePart item in baseDevices)
            {
                AddBasePart(item);
                //item.gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// 添加部件到字典
        /// </summary>
        /// <param name="baseDevicesPart"></param>
        public void AddBasePart(BasePart basePart)
        {
            if (allBasePartDic.ContainsKey(basePart.Get_id()))
            {
                Debug.Log("allBasePartDic中已经存在键" + basePart.Get_id());
            }
            else
            {
                allBasePartDic.Add(basePart.Get_id(), basePart);
                basePart.Set_partGroup(this);
            }
        }
        /// <summary>
        /// 根据ID从字典中获取部件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BasePart Get_BasePartInDict(string key)
        {
            return allBasePartDic.GetValueInDictionary<string, BasePart>(key);
        }


        private void OnMouseDown()
        {
            GameFacade.Instance.Set_canRot(false);
            GameFacade.Instance.Set_canZoom(false);
            CamTrans.DOKill();
            CamTrans.DOMove(BestViewPos.position, camMmoveToBestViewPosTime).OnComplete(() => ArriveBestViewPos());
            CamTrans.DOLocalRotate(BestViewPos.localEulerAngles, camMmoveToBestViewPosTime);
            GameFacade.Instance.Set_zoomTarget(ZoomCenter.position);
            GameFacade.Instance.Set_rotTarget(RotCenter.position);

        }
        /// <summary>
        /// 相机到达之后委托
        /// </summary>
        private void ArriveBestViewPos()
        {
            GameFacade.Instance.Set_canRot(true);
            GameFacade.Instance.Set_canZoom(true);
            //boxColliders.enabled = false;
            ShowHide_boxColliders(false);
            ShowAllPart(true);
            baseDevices.Models.SetActive(false);
            GameFacade.Instance.Set_currentDevicesOnlyChangeValue(baseDevices);
            SetAllPartsDetialsActive(true);
        }
        /// <summary>
        /// 设置碰撞检测
        /// </summary>
        /// <param name="enabled"></param>
        public void ShowHide_boxColliders(bool enabled)
        {
            foreach (var item in boxColliders)
            {
                item.enabled = enabled;
            }

        }
        /// <summary>
        /// 设置当前选中的部件
        /// </summary>
        /// <param name="basePart"></param>
        public void Set_currentPart(BasePart basePart)
        {
            baseDevices.Set_PartGroupClickable(false);
            ShowHide_boxColliders(false);
            currentPart = basePart;
            GameFacade.Instance.Set_canZoom(false);
            GameFacade.Instance.Set_canRot(false);

            if (currentPart != null)//不为空
            {
                //CamTrans.DOKill();
                //CamTrans.DOMove(currentPart.BestViewPos.position, camMmoveToBestViewPosTime).OnComplete(() => Arrive_currentPartBestViewPos());
                //CamTrans.DOLocalRotate(currentPart.BestViewPos.localEulerAngles, camMmoveToBestViewPosTime);
                currentPart.SetToBestViewPos();
                currentPart.StopHighLighting();
                GameFacade.Instance.Set_gameState(GameState.PartDetails);
               
                ShowCurrentPart();
                
            }
            else//恢复到partgroup最佳视角
            {
                ShowAllPart(false);
                CamTrans.DOKill();
                CamTrans.DOMove(BestViewPos.position, camMmoveToBestViewPosTime);
                CamTrans.DOLocalRotate(BestViewPos.localEulerAngles, camMmoveToBestViewPosTime);
                
                //baseDevices.Models.SetActive(true);
            }
        }
        /// <summary>
        /// 到达当前设备最佳视角
        /// </summary>
        private void Arrive_currentPartBestViewPos()
        {
            currentPart.ArriveBestViewPos();
        }
        /// <summary>
        /// 隐藏所有部件
        /// </summary>
        public void HideAllPart()
        {
            Models.SetActive(false);
            foreach (var item in allBasePartDic.Values)
            {
                item.boxCollider.enabled = false;//所有部件是否可以点击
                item.Models.SetActive(false);
                item.ReturnToNormalState();

            }
        }
        /// <summary>
        /// 显示所有部件
        /// </summary>
        public void ShowAllPart(bool isPartCanClick)
        {
            Models.SetActive(true);
            foreach (var item in allBasePartDic.Values)
            {
                item.boxCollider.enabled = isPartCanClick;//所有部件是否可以点击
                item.Models.SetActive(true);
                item.ReturnToNormalState();
                item.Set_DetailsActive(true);

            }
        }
        /// <summary>
        /// 设置所有部件的细节显示隐藏状态
        /// </summary>
        /// <param name="active"></param>
        public void SetAllPartsDetialsActive(bool active)
        {
            foreach (var item in allBasePartDic.Values)
            {
               
                item.Set_DetailsActive(active);

            }
        }
        /// <summary>
        /// 显示当前部件
        /// </summary>
        private void ShowCurrentPart()
        {
           
            //Models.SetActive(false);
            currentPart.Models.SetActive(true);
            currentPart.boxCollider.enabled = false;
            foreach (var item in allBasePartDic.Values)
            {
                if (item!= currentPart)
                {
                    item.Models.SetActive(false); 
                }
            }
        }

        /// <summary>
        /// 根据部件ID到部件视角
        /// </summary>
        /// <param name="id"></param>
        public void GoToPartForID(string id = "")
        {
            BasePart part = null;
            part = Get_BasePartInDict(id);

            if (part==null)//如果找不到部件，则前往默认部件
            {
                part = currentPart;
                if (part==null)
                {
                    part = Get_BasePartInDict(defaultPartID);
                    Debug.Log(string.Format("传入的部件ID：{0}，不存在，前往默认设备的默认部件", id));
                }
                else
                {
                    Debug.Log(string.Format("传入的部件ID：{0}，不存在，前往当前认设备的当前部件", id));
                }
               
            }
            Set_currentPart(part);
            
        }

      
        /// <summary>
        /// 透视模式
        /// </summary>
        public void SetToFadeMode(float alpha = 0.1f, float fadeTime = 5f)
        {
            if (currentPart == null)
            {
                Debug.Log("当前部件为空，无法设置透视模式");
                return;
            }
            currentPart.SetToFadeMode(alpha, fadeTime);
        }
        /// <summary>
        /// 爆炸模式
        /// </summary>
        public void SetToBombMode()
        {
            if (currentPart == null)
            {
                Debug.Log("当前部件为空，无法设置爆炸模式");
                return;
            }
            currentPart.SetToBombMode();
        }

        /// <summary>
        /// 开始高亮
        /// </summary>
        public void StartHighLighting()
        {
            foreach (var item in allBasePartDic.Values)
            {
                item.StartHighLighting();
            }
           
        }

        /// <summary>
        /// 停止高亮
        /// </summary>
        public void StopHighLighting()
        {
            foreach (var item in allBasePartDic.Values)
            {
                item.StopHighLighting();
            }
        }
        /// <summary>
        /// 变半透明物体
        /// </summary>
        public void Fade()
        {
            if (FadeObj==null)
            {
                return;
            }
            FadeObj.Fade(0f,5);
        }

        /// <summary>
        /// 变半透明物体
        /// </summary>
        public void Return()
        {
            if (FadeObj == null)
            {
                return;
            }
            FadeObj.Return(1);
        }
    }
}
