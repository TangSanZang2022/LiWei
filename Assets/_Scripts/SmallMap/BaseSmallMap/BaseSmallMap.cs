using System.Collections;
using System.Collections.Generic;
using UIFramework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MySmallMap
{
    /// <summary>
    /// 小地图基类
    /// </summary>
    public abstract class BaseSmallMap : MonoBehaviour
    {
        /// <summary>
        /// 玩家
        /// </summary>
        protected Transform player;
        /// <summary>
        /// 玩家在地图上的Icon
        /// </summary>
        protected RectTransform targetIconImage;
        /// <summary>
        /// 小地图图片
        /// </summary>
        protected Image mapImage;

        /// <summary>
        /// 玩家开始的Y轴旋转值
        /// </summary>
        protected float playerStartRotY;
        /// <summary>
        /// 世界坐标和玩家坐标系转换
        /// </summary>
        protected GisPointTo3DPointController worldToIconPointController;
        protected virtual void Awake()
        {
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected abstract void Init();

        /// <summary>
        /// 设置小地图状态，显示隐藏
        /// </summary>
        /// <param name="state"></param>
        public abstract void SetSmallMapState(bool state);
        /// <summary>
        /// 设置玩家位置
        /// </summary>
        protected abstract void SetPlayerPos(Vector3 playerPos);
        /// <summary>
        /// 设置小地图的图片
        /// </summary>
        /// <param name="newImage"></param>
        public abstract void SetSmallMapImage(Image newImage);
    }
}

