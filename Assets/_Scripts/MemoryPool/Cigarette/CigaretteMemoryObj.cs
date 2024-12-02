using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cigarette
{
    /// <summary>
    /// 要存放到内存池的香烟
    /// </summary>
    public class CigaretteMemoryObj : BaseMemoryObj
    {
        public Vector3 startRotAngle;
        protected override void Init(object[] obj = null)
        {
            base.Init(obj);
            transform.parent = (Transform)obj[0];
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles= startRotAngle;
        }

        public override void InPool()
        {
            base.InPool();
            GetComponent<BaseCigarette>().Set_BarCodeState(false);//将Ui隐藏
        }

        public override void OutPool(object[] obj = null)
        {
            base.OutPool(obj);

        }
    }
}
