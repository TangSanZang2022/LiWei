using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseScaleObjTool;
namespace Cigarette
{
    /// <summary>
    /// 烟草缩放UI
    /// </summary>
    public class CigaretteScaleUIIcon : BaseScaleObj
    {
        private void OnEnable()
        {
           
            StartChangeScale_Forward();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public override void StartChangeScale_Forward()
        {
            base.StartChangeScale_Forward();
        }

        public override void StartChangeScale_Reverse()
        {
            base.StartChangeScale_Reverse();
        }


        public override void On_tweener_Complete_Forward()
        {
            base.On_tweener_Complete_Forward();
        }
        public override void On_tweener_Complete_Reverse()
        {
            base.On_tweener_Complete_Reverse();
        }

        private void OnDisable()
        {
            StartChangeScale_Reverse();
        }
    }
}
