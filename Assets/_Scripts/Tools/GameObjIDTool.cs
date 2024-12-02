using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// 物体ID
    /// </summary>
    public class GameObjIDTool 
    {
        #region //相机位置
        /// <summary>
        /// 相机开始时海面最远距离
        /// </summary>
        public static string FarPos="FarPos";
        /// <summary>
        /// 相机在港口时最佳视角
        /// </summary>
        public static string PortBestPos = "PortBestPos";
        /// <summary>
        /// 相机贴近港口的位置
        /// </summary>
        public static string NearPos = "NearPos";
        


        #endregion

        #region//物体名称
        /// <summary>
        /// 场景中其他物体
        /// </summary>
        public static string SceneOtherModel = "SceneOtherModel";
        /// <summary>
        /// 相机背景
        /// </summary>
        public static string CamTransCanvas = "Canvas";
        /// <summary>
        /// 可透明物体
        /// </summary>
        public static string FadeObj = "FadeObj";
        /// <summary>
        /// 存放动画的父物体
        /// </summary>
        public static string AniObj = "AniObj";
        /// <summary>
        /// 部件细节UI
        /// </summary>
        public static string Details = "Details";

        #endregion
    }
}
