using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveObjTool;
namespace Cigarette
{
    /// <summary>
    /// 激光打印点
    /// </summary>
    public class CodingMachinePoint : BaseRoadPoint
    {
        public override void ArrivedPoint(BaseMoveObj currentBaseMoveObj)
        {
            base.ArrivedPoint(currentBaseMoveObj);
            currentBaseMoveObj.GetComponent<BaseCigarette>().Set_BarCodeState(true);
            GameFacade.Instance.CreateBaseCigarette();
            
        }
    }
}
