using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;
namespace Cigarette
{
    /// <summary>
    /// 香烟基类
    /// </summary>
    public class BaseCigarette : OperationalObj
    {
        private GameObject barCode;
        /// <summary>
        /// 条码
        /// </summary>
        private GameObject BarCode
        {
            get
            {
                if (barCode==null)
                {
                    barCode = transform.FindChildForName("BarCodeCanvas").gameObject;
                }
                return barCode;
            }
        }

        protected override void Start()
        {
            base.Start();
            Set_BarCodeState(false);//开始隐藏条码
        }
        /// <summary>
        /// 设置条码的状态
        /// </summary>
        /// <param name="state"></param>
        public void Set_BarCodeState(bool state)
        {
            BarCode.SetActive(state);
        }

        public void SetChildCigarette(int index)
        {
            if (index>transform.childCount|| index==-1)
            {
                index = 0;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            transform.GetChild(index).gameObject.SetActive(true);
        }
    }
}
