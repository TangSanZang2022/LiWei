using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DFDJ
{
    /// <summary>
    /// 重型装配车间FPS漫游开始位置
    /// </summary>
    public class HeavyEquipmentFPSStartPos : BaseFPSPos
    {
        public override void Init()
        {
            base.Init();
        }

        public override void MoveToPoint(Transform trans, float time = 1f)
        {
            base.MoveToPoint(trans);
        }

        public override void CamArrived()
        {
            base.CamArrived();
           // GameFacade.Instance.ShowObjForID(GameObjIDTool.EquipmentScreenIconCanvas);//显示UI
        }

        public override void Leave()
        {
            base.Leave();
           
        }
    }
}

