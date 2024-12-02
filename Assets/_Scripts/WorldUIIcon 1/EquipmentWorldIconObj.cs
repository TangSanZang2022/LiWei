using Cigarette;
using DFDJ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DFDJ
{
    public class EquipmentWorldIconObj : MonoBehaviour
    {
        /// <summary>
        /// Icon上展示的数据
        /// </summary>
        public CigaretteWorldUIIconData data;

        public MyCullingGroup myCullingGroup;
        /// <summary>
        /// 世界UIIcon
        /// </summary>
        public BaseWorldUIIcon worldIcon;
        /// <summary>
        /// 此Icon对应的
        /// </summary>
        public Equipment.BaseEquipment baseEquipment
        {
            get;
            private set;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            baseEquipment = GetComponent<Equipment.BaseEquipment>();
            //data = baseEquipment.GetComponent<LaserCodingMachine>().Get_laserBase();
            //SetIconData(data);
            //baseScreenIcon.GetComponent<EquipmentScreenIcon>().SetNameText(baseEquipment.GetObjName());
            myCullingGroup = GetComponent<MyCullingGroup>();
            if (myCullingGroup == null)
            {
               // myCullingGroup = transform.FindChildForName("UITargetTrans").GetComponent<MyCullingGroup>();
            }
            //myCullingGroup.SeeObjOnDistance += delegate { baseScreenIcon.gameObject.SetActive(true);  };
            //myCullingGroup.LoseSightObjOnDistance += delegate { baseScreenIcon.gameObject.SetActive(false); };
            //myCullingGroup.LoseSightObjOnDistance += delegate { baseScreenIcon.gameObject.SetActive(false); GameFacade.Instance.GetNearestEquipmentAndClick(); };
            //myCullingGroup.SeeObjOnDistance += delegate { GameFacade.Instance.ShowOneIcon(baseScreenIcon); GameFacade.Instance.GetNearestEquipmentAndClick(); };
           // myCullingGroup.LoseSightObjOnDistance += delegate { worldIcon.gameObject.SetActive(false); };
            //myCullingGroup.SeeObjOnDistance += delegate { GameFacade.Instance.ShowOneWorldIcon(worldIcon); };

        }


        /// <summary>
        /// 设置屏幕UI同步位置的相机
        /// </summary>
        /// <param name="targetCam"></param>
        public void Set_baseWorldIcon_targetCam(Camera targetCam)
        {
            worldIcon.Set_targetCam(targetCam);
            //worldIcon.transform.localScale = v3;
        }
        /// <summary>
        /// 设置包围球的相机
        /// </summary>
        /// <param name="cam"></param>
        public void SetTargetCamera(Camera cam)
        {
            if (myCullingGroup == null)
            {
                myCullingGroup = transform.FindChildForName("UITargetTrans").GetComponent<MyCullingGroup>();
            }
            myCullingGroup.SetTargetCamera(cam);


        }
        /// <summary>
        /// 设置Icon数据
        /// </summary>
        /// <param name="data"></param>
        public void SetIconData(CigaretteWorldUIIconData data)
        {
            if (worldIcon != null)
            {
                worldIcon.SetIconData(data);
            }
        }
        protected void Start()
        {
            Init();
            worldIcon.gameObject.SetActive(false);
           // Debug.Log(2222);
        }


        /// <summary>
        /// 鼠标点击Icon
        /// </summary>
        public void OnMouseClickIcon()
        {

        }
        /// <summary>
        /// 鼠标进入Icon
        /// </summary>
        public void OnMouseEnterIcon()
        {

        }
        /// <summary>
        /// 鼠标移出Icon
        /// </summary>
        public void OnMouseExitIcon()
        {

        }
    }
}
