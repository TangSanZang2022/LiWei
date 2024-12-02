using GlobalSnowEffect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LiWei
{
    /// <summary>
    /// 相机屏幕雪效果
    /// </summary>
    public class CamScreenSnow : MonoBehaviour
    {
        public float screenSnowSpeed = 5;
        // Start is called before the first frame update
        void Start()
        {
            globalSnow.enabled = false;
        }

        private GlobalSnow _globalSnow;
        /// <summary>
        /// 雪的覆盖效果
        /// </summary>
        private GlobalSnow globalSnow
        {
            get
            {
                if (_globalSnow == null)
                {
                    _globalSnow = Camera.main.GetComponent<GlobalSnow>();
                }
                return _globalSnow;
            }
        }



        /// <summary>
        /// 开始屏幕雪效果
        /// </summary>
        public void Start_globalSnow(bool isStartIAddScreenSnow=true)
        {
            StopAllCoroutines();
            if (isStartIAddScreenSnow)
            {
                StartCoroutine("IAddScreenSnow");
            }
            else
            {
                globalSnow.enabled = true;
                globalSnow.altitudeBlending = 0;
            }
            
        }

        IEnumerator IAddScreenSnow()
        {
            globalSnow.showSnowInSceneView = true;
            globalSnow.enabled = true;
            globalSnow.altitudeBlending = 500;
            while (globalSnow.altitudeBlending>0)
            {
                yield return 0;
                globalSnow.altitudeBlending -= Time.deltaTime * screenSnowSpeed;
            }
            if (globalSnow.altitudeBlending < 0)
            {
                globalSnow.altitudeBlending = 0;
            }
        }
        /// <summary>
        /// 结束屏幕雪覆盖效果
        /// </summary>
        public void Stop_globalSnow()
        {
            globalSnow.showSnowInSceneView = false;
            globalSnow.altitudeBlending = 500;
            globalSnow.enabled = false;

        }
    }
}
