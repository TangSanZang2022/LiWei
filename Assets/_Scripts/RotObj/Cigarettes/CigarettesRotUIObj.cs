using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRotObjTool;

namespace Cigarette
{
    /// <summary>
    /// 香烟UI旋转
    /// </summary>
    public class CigarettesRotUIObj : BaseRotObj
    {
        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnEnable()
        {
            StartChangeRot();
        }
        public override void StartChangeRot()
        {
            base.StartChangeRot();
        }

       
        public override void On_tweener_Complete_Everytime()
        {
            base.On_tweener_Complete_Everytime();
        }
    }
}
