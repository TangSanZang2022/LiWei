using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Tools;

namespace LiWei
{
    /// <summary>
    /// 设备控制器
    /// </summary>
    public class DevicesController : BaseController
    {
        /// <summary>
        /// 默认设备ID，此时为岸桥
        /// </summary>
        private string defaultDevicesID = "ShoreBridge";


        /// <summary>
        /// 当前选中的设备
        /// </summary>
        private LiWeiBaseDevices currentDevices;

        /// <summary>
        /// 相机移动到最佳视角的时间
        /// </summary>
        private float camMmoveToBestViewPosTime = 1f;
        /// <summary>
        /// 相机移动dotween
        /// </summary>
        Tweener camMoveTweener;

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
        private GameObject camTransCanvas;
        /// <summary>
        /// 相机背景图片
        /// </summary>
        private GameObject CamTransCanvas
        {
            get
            {
                if (camTransCanvas == null)
                {
                    camTransCanvas = CamTrans.FindChildForName(GameObjIDTool.CamTransCanvas).gameObject;
                }
                return camTransCanvas;
            }
        }
        private GameObject sceneOtherModel;
        /// <summary>
        /// 游戏场景中其他物体
        /// </summary>
        private GameObject SceneOtherModel
        {
            get
            {
                if (sceneOtherModel == null)
                {
                    sceneOtherModel = GameObject.Find(GameObjIDTool.SceneOtherModel);
                }
                return sceneOtherModel;
            }
        }
        public DevicesController(GameFacade gameFacade) : base(gameFacade)
        { }
        /// <summary>
        /// 存放所有设备的字典
        /// </summary>
        private Dictionary<string, LiWeiBaseDevices> devicesDict = new Dictionary<string, LiWeiBaseDevices>();

        public override void OnInit()
        {
            base.OnInit();
            AddAllBaseDevices();
        }
        /// <summary>
        /// 添加所有的部件到字典中
        /// </summary>
        private void AddAllBaseDevices()
        {
            LiWeiBaseDevices[] baseDevices = GameObject.FindObjectsOfType<LiWeiBaseDevices>();
            foreach (LiWeiBaseDevices item in baseDevices)
            {
                AddBaseDevices(item);
                //item.gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// 添加部件到字典
        /// </summary>
        /// <param name="baseDevicesPart"></param>
        public void AddBaseDevices(LiWeiBaseDevices baseDevicesPart)
        {
            if (devicesDict.ContainsKey(baseDevicesPart.Get_id()))
            {
                Debug.Log("vehicelPartDict中已经存在键" + baseDevicesPart.Get_id());
            }
            else
            {
                devicesDict.Add(baseDevicesPart.Get_id(), baseDevicesPart);
            }
        }
        /// <summary>
        /// 根据ID从字典中获取部件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public LiWeiBaseDevices Get_BaseDevicesInDict(string key)
        {
            return devicesDict.GetValueInDictionary<string, LiWeiBaseDevices>(key);
        }
        /// <summary>
        /// 设置当前选中的设备
        /// </summary>
        /// <param name="baseDevices"></param>
        public void Set_currentDevices(LiWeiBaseDevices baseDevices)
        {
            currentDevices = baseDevices;
            facade.Set_AllCamControll(false);
            if (currentDevices != null)//不为空
            {
                CamTrans.DOKill();
                CamTrans.DOMove(currentDevices.BestViewPos.position, camMmoveToBestViewPosTime).OnComplete(() => ArriveBestViewPos());
                CamTrans.DOLocalRotate(currentDevices.BestViewPos.localEulerAngles, camMmoveToBestViewPosTime);
                facade.Set_gameState(GameState.DeviceInfo);
                ShowCurrentDevices();
                currentDevices.Set_PartGroupClickable(true);
                currentDevices.ShowPartGroup(false);
                HideAllDevicesCollider();
                //currentDevices.boxCollider.enabled = false;
                currentDevices.StartHighLighting();
                currentDevices.PartGroup.Fade();
            }
            else//恢复港口最佳视角
            {
                ShowAllDevices();
                CamTrans.DOKill();
                facade.SetTarnsToPos(GameObjIDTool.PortBestPos, CamTrans);
                Set_SceneOtherModel_Active(true);
                Set_CamTransCanvas_Active(false);
                facade.Set_lock_rotTarget(false);
                facade.Set_lock_ZoomTarget(false);
                
            }
            SetAllPartsDetialsActive(false);
        }

        /// <summary>
        /// 设置当前选中的设备,只改变值，不做任何其他操作
        /// </summary>
        /// <param name="baseDevices"></param>
        public void Set_currentDevicesOnlyChangeValue(LiWeiBaseDevices baseDevices)
        {
            currentDevices = baseDevices;
        }
        /// <summary>
        /// 得到当前部件
        /// </summary>
        /// <returns></returns>
        public LiWeiBaseDevices Get_currentDevices()
        {
            return currentDevices;
        }
        /// <summary>
        /// 仅仅显示当前模型
        /// </summary>
        public void ShowCurrentDevices()
        {
            currentDevices.Models.SetActive(true);
            foreach (var item in devicesDict.Values)
            {
                if (item != currentDevices)
                {
                    item.Models.SetActive(false);
                    item.PartGroup.Models.SetActive(false);
                    
                    item.PartGroup.ShowHide_boxColliders(false);
                    item.PartGroup.HideAllPart();

                }
            }
        }
        /// <summary>
        /// 显示所有设备
        /// </summary>
        private void ShowAllDevices()
        {
            foreach (var item in devicesDict.Values)
            {
                item.ShowPartGroup(false);
                item.boxCollider.enabled = true;
                item.Models.SetActive(true);
                item.StopHighLighting();
                item.PartGroup.Return();

            }
        }
        /// <summary>
        /// 隐藏所有设备的碰撞器
        /// </summary>
        private void HideAllDevicesCollider()
        {
            foreach (var item in devicesDict.Values)
            {
               
                item.boxCollider.enabled = false;
                
            }
        }
        /// <summary>
        /// 到达最佳视角之后委托
        /// </summary>
        private void ArriveBestViewPos()
        {
            facade.Set_AllCamControll(true);
            Set_SceneOtherModel_Active(false);
            Set_CamTransCanvas_Active(true);
            facade.Set_lock_rotTarget(true);
            facade.Set_lock_ZoomTarget(true);
            facade.Set_zoomTarget(currentDevices.ZoomCenter.position);
            facade.Set_rotTarget(currentDevices.RotCenter.position);
            facade.Set_canMoveHV(false);
            SetAllPartsDetialsActive(false);//隐藏所有设备的细节UI

        }
        /// <summary>
        /// 设置所有部件的细节显示隐藏状态
        /// </summary>
        /// <param name="active"></param>
        private void SetAllPartsDetialsActive(bool active)
        {
            foreach (var devices in devicesDict.Values)
            {
                devices.PartGroup.SetAllPartsDetialsActive(active);
            }
        }

        /// <summary>
        /// 设置场景其他模型的显示隐藏
        /// </summary>
        /// <param name="active"></param>
        public void Set_SceneOtherModel_Active(bool active)
        {
            SceneOtherModel.SetActive(active);
        }
        /// <summary>
        /// 设置相机背景图片的显示隐藏状态
        /// </summary>
        /// <param name="active"></param>
        public void Set_CamTransCanvas_Active(bool active)
        {
            CamTransCanvas.SetActive(active);
        }
        /// <summary>
        /// 根据设备ID到设备视角
        /// </summary>
        /// <param name="id"></param>
        public void GoToDevicesForID(string id = "")
        {
            LiWeiBaseDevices devices = null;
            devices = Get_BaseDevicesInDict(id);
            if (devices == null)
            {
                devices = currentDevices;
                if (devices == null)
                {
                    devices = Get_BaseDevicesInDict(defaultDevicesID);
                    Debug.Log(string.Format("传入的设备ID：{0}，不存在，前往默认设备", id));
                }
                else
                {
                    Debug.Log(string.Format("传入的设备ID：{0}，不存在，但当前设备已被赋值，前往当前设备", id));
                }
            }
            Set_currentDevices(devices);
        }
        /// <summary>
        /// 回到当前设备
        /// </summary>
        public void BackToCurrentDevices()
        {
            Set_currentDevices(currentDevices);
        }
        /// <summary>
        /// 回到设备的最佳视角
        /// </summary>
        public void SetCamToCurrentDevicesBestViewPos()
        {
            currentDevices.Models.SetActive(true);
            currentDevices.PartGroup.ShowHide_boxColliders(true);
            
            GameFacade.Instance.Set_canRot(false);
            GameFacade.Instance.Set_canZoom(false);
            CamTrans.DOKill();
            CamTrans.DOMove(currentDevices.BestViewPos.position, camMmoveToBestViewPosTime).OnComplete(() => ArriveBestViewPos());
            CamTrans.DOLocalRotate(currentDevices.BestViewPos.localEulerAngles, camMmoveToBestViewPosTime);
        }
        /// <summary>
        /// 获取默认设备
        /// </summary>

        public LiWeiBaseDevices Get_defaultDevices()
        {
            return Get_BaseDevicesInDict(defaultDevicesID);
        }
        /// <summary>
        /// 根据部件ID到部件视角
        /// </summary>
        /// <param name="id"></param>
        public void GoToPartForID(string id = "")
        {
            LiWeiBaseDevices baseDevices = null;
            baseDevices = Get_DevicesForPartID(id);
            if (baseDevices == null)//部件为空,则为默认部件
            {
                baseDevices = currentDevices;
                if (baseDevices==null)
                {
                    baseDevices= Get_defaultDevices();
                }
            }
            currentDevices = baseDevices;
            currentDevices.GoToPartForID(id);


        }
        /// <summary>
        /// 根据部件ID获取设备
        /// </summary>
        /// <param name="partID"></param>
        /// <returns></returns>

        public LiWeiBaseDevices Get_DevicesForPartID(string partID)
        {
            LiWeiBaseDevices baseDevices = null;
            foreach (var devices in devicesDict.Values)
            {
                if (devices.PartGroup.Get_BasePartInDict(partID) != null)
                {
                    baseDevices = devices;
                    break;
                }

            }
            return baseDevices;
        }

        /// <summary>
        /// 透视模式
        /// </summary>
        public void SetToFadeMode(float alpha = 0.01f, float fadeTime = 5f)
        {
            if (Get_currentDevices() == null)
            {
                Debug.Log("当前设备为空，无法设置设备部件透视模式");
                return;
            }
            Get_currentDevices().PartGroup.SetToFadeMode(alpha, fadeTime);
        }
        /// <summary>
        /// 爆炸模式
        /// </summary>
        public void SetToBombMode()
        {
            if (Get_currentDevices() == null)
            {
                Debug.Log("当前设备为空，无法设置设备部件爆炸模式");
                return;
            }
            Get_currentDevices().PartGroup.SetToBombMode();
        }
    }
}
