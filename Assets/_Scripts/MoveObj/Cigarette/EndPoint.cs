using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveObjTool;
namespace Cigarette
{
    /// <summary>
    /// 结束点
    /// </summary>
    public class EndPoint : BaseRoadPoint
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        public override void ArrivedPoint(BaseMoveObj currentBaseMoveObj)
        {
            base.ArrivedPoint(currentBaseMoveObj);
            BaseCigarette baseCigarette = currentBaseMoveObj.GetComponent<BaseCigarette>();
            baseCigarette.Set_BarCodeState(false);
            GameFacade.Instance.RemoveBaseCigarette(baseCigarette);
            //Destroy(currentBaseMoveObj.gameObject);
            currentBaseMoveObj. GetComponent<CigaretteMemoryObj>().InPool();
        }
    }
}
