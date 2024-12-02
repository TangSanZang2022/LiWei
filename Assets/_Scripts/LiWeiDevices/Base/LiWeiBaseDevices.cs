using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace LiWei
{
    /// <summary>
    /// 利维设备基类
    /// </summary>
    public class LiWeiBaseDevices : MonoBehaviour
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
        protected string deviceName;
        /// <summary>
        /// 设备数据
        /// </summary>
        private LiWeiDeviceData liWeiDeviceData;
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

        private BasePartGroup partGroup;
        /// <summary>
        /// 部件组
        /// </summary>
        public BasePartGroup PartGroup
        {
            get
            {
                if (partGroup == null)
                {
                    partGroup = transform.FindChildForName("PartGroup").GetComponent<BasePartGroup>();
                }
                return partGroup;
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
        // Start is called before the first frame update
        void Start()
        {
            boxCollider.enabled = true;
        }
        /// <summary>
        /// 获取ID
        /// </summary>
        /// <returns></returns>
        public string Get_id()
        {
            return id;
        }
        /// <summary>
        /// 获取设备名称
        /// </summary>
        /// <returns></returns>
        public string Get_deviceNamee()
        {
            return deviceName;
        }

        private void OnMouseDown()
        {
            GameFacade.Instance.Set_currentDevices(this);

        }
        /// <summary>
        /// 设置部件组可点击状态
        /// </summary>
        /// <param name="isCanClick"></param>
        public void Set_PartGroupClickable(bool isCanClick)
        {
            if (PartGroup != null)
            {
                PartGroup.ShowHide_boxColliders(isCanClick);

                //PartGroup.boxColliders.enabled = isCanClick;
            }
        }
        /// <summary>
        /// 显示所有部件组
        /// </summary>
        public void ShowPartGroup(bool isPartCanClick)
        {
            PartGroup.ShowAllPart(isPartCanClick);
        }

        /// <summary>
        /// 根据部件ID到部件视角
        /// </summary>
        /// <param name="id"></param>
        public void GoToPartForID(string id = "")
        {
            PartGroup.GoToPartForID(id);
        }

        /// <summary>
        /// 透视模式
        /// </summary>
        public void SetToFadeMode(float alpha = 0.01f, float fadeTime = 5f)
        {
          
            PartGroup.SetToFadeMode(alpha, fadeTime);
        }
        /// <summary>
        /// 爆炸模式
        /// </summary>
        public void SetToBombMode()
        {
            PartGroup.SetToBombMode();
        }

        /// <summary>
        /// 开始当前设备部件高亮
        /// </summary>
        public void StartHighLighting()
        {
            PartGroup.StartHighLighting();

        }

        /// <summary>
        /// 停止当前设备部件高亮
        /// </summary>
        public void StopHighLighting()
        {
            PartGroup.StopHighLighting();
        }
    }
    /// <summary>
    /// 利维港口设备数据
    /// </summary>
    [Serializable]
    public class LiWeiDeviceData
    {
        /// <summary>
        /// 测试数据
        /// </summary>
        public string testData;
    }
}
