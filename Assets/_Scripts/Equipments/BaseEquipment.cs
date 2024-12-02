using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOprationalObj;

namespace Equipment
{
    /// <summary>
    /// 设备基类
    /// </summary>
    public class BaseEquipment : OperationalObj
    {

        protected override void Start()
        {
            base.Start();
        }


        protected override void Update()
        {
            base.Update();
        }
        /// <summary>
        ///初始化
        /// </summary>
        protected override void OnInit()
        {
            base.OnInit();
        }

        protected override void MouseEnterHandle()
        {
            base.MouseEnterHandle();
        }

        protected override void MouseDownHandle()
        {
            base.MouseDownHandle();
        }


        protected override void MouseExitHandle()
        {
            base.MouseExitHandle();
        }
        /// <summary>
        /// 更新物体数据，状态等
        /// </summary>
        /// <param name="data"></param>
        public override void UpdateObj(object data)
        {
            base.UpdateObj(data);
        }
        /// <summary>
        /// 恢复为初始状态
        /// </summary>
        public override void Reduction()
        {
            base.Reduction();
        }
    }
}
