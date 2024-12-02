using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace LiWei
{
    /// <summary>
    /// 游戏状态
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// 港口概览
        /// </summary>
        HarbourOverview,
        /// <summary>
        /// 设备详情
        /// </summary>
        DeviceInfo,
        /// <summary>
        /// 部件详情
        /// </summary>
        PartDetails
    }
    /// <summary>
    /// 游戏状态控制
    /// </summary>
    public class GameStateController : BaseController
    {

        public GameStateController(GameFacade gameFacade) : base(gameFacade)
        {

        }
        /// <summary>
        /// 当前的游戏状态
        /// </summary>
        private GameState gameState;


        public override void OnInit()
        {
            base.OnInit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
        /// <summary>
        /// 获取相机状态
        /// </summary>
        /// <returns></returns>
        public GameState Get_gameState()
        {
            return gameState;
        }
        /// <summary>
        /// 设置游戏状态
        /// </summary>
        /// <param name="state"></param>
        public void Set_gameState(GameState state, UnityAction unityAction = null)
        {
            if (gameState == GameState.HarbourOverview)//如果之前在港口页面，然后切换到设备或者部件页面，则需要切换时间为晴天中午
            {
                switch (state)
                {
                    case GameState.HarbourOverview:
                       
                        break;
                    case GameState.DeviceInfo:
                        facade.SetBestWeatherAndTime();
                        break;
                    case GameState.PartDetails:
                        facade.SetBestWeatherAndTime();

                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (state == GameState.HarbourOverview)//回到港口总览，则天气应该恢复为原来状态
                {
                    facade.WeatherTime_Back();
                }
                
            }
            gameState = state;

            if (unityAction != null)
            {
                unityAction();
            }
        }
        public override void OnDestory()
        {
            base.OnDestory();
        }
    }
}
