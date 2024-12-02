using MyAnimEventTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LiWei
{
    public class LiWeiNormalPart : BasePart, IAnimEvent
    {
        protected override void Start()
        {
            base.Start();
            AddAnimEvent();
        }
        public bool IsAddEvent { get ; set ; }
        /// <summary>
        /// 给动画添加事件
        /// </summary>
        private void AddAnimEvent()
        {
            if (IsAddEvent)
            {
                return;
            }
            animator.AddAnimEvent("Return", "AniEndEvent", 0.1f);
            //RuntimeAnimatorController runtimeAnimatorController = animator.runtimeAnimatorController;
            //AnimationClip currentAnimClip;
            //for (int i = 0; i < runtimeAnimatorController.animationClips.Length; i++)
            //{
            //    Debug.Log(runtimeAnimatorController.animationClips[i].name);
            //    if (runtimeAnimatorController.animationClips[i].name == "Return")
            //    {
            //        currentAnimClip = runtimeAnimatorController.animationClips[i];
            //        AnimationEvent animationEvent = new AnimationEvent();
            //        animationEvent.functionName = "AniEndEvent";
            //        Debug.Log("动画时间为："+(currentAnimClip.length - 0.1f));
            //        animationEvent.time =  0.1f;
            //        currentAnimClip.AddEvent(animationEvent);

            //        break;
            //    }
            //}
            IsAddEvent = true;

        }
        public void AniEndEvent()
        {
            if (GameFacade.Instance.Get_gameState()==GameState.PartDetails)//为不见详情
            {
                FadeObj.gameObject.SetActive(true);
                Set_DetailsActive(true);
                Fade(0.1f, 5);
            }
            else
            {
                FadeObj.gameObject.SetActive(true);
                Set_DetailsActive(false);
                Return();
            }

           
        }
       
        public void AniStartEvent()
        {
            
        }

        public void QuitAniMidway()
        {
          
        }
    }
}