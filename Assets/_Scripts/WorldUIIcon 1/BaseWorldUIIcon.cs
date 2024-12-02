using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DFDJ
{
    /// <summary>
    /// 物体的世界UI介绍
    /// </summary>
    public class BaseWorldUIIcon : MonoBehaviour
    {
        /// <summary>
        /// 用于同步UI角度和大小的相机
        /// </summary>
        public Camera targetCam;
        // Start is called before the first frame update
       public void Start()
        {

        }

        // Update is called once per frame
      public  void Update()
        {

        }

        /// <summary>
        /// 设置同步位置的相机
        /// </summary>
        /// <param name="targetCam"></param>
        public void Set_targetCam(Camera targetCam)
        {
            //if (targetCam == null)
            //{
            //    targetCam = Camera.main;
            //}
            this.targetCam = targetCam;
            GetComponent<LookAtCamera>().Set_targetCam(targetCam.transform);

            //Debug.Log(targetCam.name+"1111111111111");
        }
        /// <summary>
        /// 设置ICon数据
        /// </summary>
        /// <param name="data"></param>
        public virtual void SetIconData(object data)
        {
           // transform.FindChildForName("EquipmentScreenIcon_New").GetComponent<EquipmentScreenIcon>().SetIconData(data);
        }
    }
}
