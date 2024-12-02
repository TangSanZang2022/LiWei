using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIFramework;
using Common;
using System;
using UnityEngine.EventSystems;
using UnityEngine.AI;
namespace MySmallMap
{
    /// <summary>
    /// 厂区漫游小地图
    /// </summary>
    public class FactoryRoamtSmallMap : BaseSmallMap
    {
       
       
        protected override void Awake()
        {
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            player = GameObject.Find("FPSController").transform;
            mapImage = transform.FindChildForName("MapImage").GetComponent<Image>();

            targetIconImage = transform.FindChildForName("TargetIconImage").GetComponent<RectTransform>();
            Debug.Log(targetIconImage.name);
          //  UIEventListener.GetUIEventListener(mapImage.transform).pointClickHandler += OnClickMapImage;//添加点击委托

            playerStartRotY = player.localEulerAngles.y;
            worldToIconPointController = new GisPointTo3DPointController();
            worldToIconPointController.SetGPS_PointAAndB(new Vector2(72.3f, 412.4f), new Vector2(403.4302f, 886.23f));
            worldToIconPointController.SetUnityPointAAndB(GameObject.Find("PointA").transform, GameObject.Find("PointB").transform);
            worldToIconPointController.OnInit();
            SetSmallMapState(false);
        }
        /// <summary>
        /// 设置小地图状态，显示隐藏
        /// </summary>
        /// <param name="state"></param>
        public override void SetSmallMapState(bool state)
        {
            mapImage.gameObject.SetActive(state);
            targetIconImage.gameObject.SetActive(state);
        }
        /// <summary>
        /// 点击小地图
        /// </summary>
        /// <returns></returns>
        private void OnClickMapImage(PointerEventData eventData)
        {

            Vector2 uiLocalPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, eventData.pressPosition, null, out uiLocalPos);//将屏幕坐标转换为
            Debug.Log(uiLocalPos);
            Vector3 playerNewPos = worldToIconPointController.GetWorldPoint(uiLocalPos.y, uiLocalPos.x);

            SetPlayerPos(new Vector3(playerNewPos.x, player.position.y, playerNewPos.z));
        }
        /// <summary>
        /// 设置玩家位置
        /// </summary>
        protected override void SetPlayerPos(Vector3 playerPos)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.position = playerPos;
            player.GetComponent<NavMeshAgent>().enabled = true;
            player.GetComponent<CharacterController>().enabled = true;
           
        }

        private void Update()
        {
            targetIconImage.localRotation = Quaternion.Euler(0, 0, -(player.localEulerAngles.y - playerStartRotY));
            targetIconImage.localPosition = new Vector2(worldToIconPointController.GetLatLon(player.position).y, worldToIconPointController.GetLatLon(player.position).x);
        }
        /// <summary>
        /// 设置小地图的图片
        /// </summary>
        /// <param name="newImage"></param>
        public override void SetSmallMapImage(Image newImage)
        {
           
        }
    }
}
