using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DFDJ
{
    /// <summary>
    /// 厂区FPS漫游开始位置
    /// </summary>
    public class FactoryFPSStartPos : BaseFPSPos
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
        }

        public override void Leave()
        {
            base.Leave();
        }
    }
}
