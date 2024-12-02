using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace UVAin
{
    /// <summary>
    /// UV动画物体
    /// </summary>
    public class BaseUVAniObj : MonoBehaviour
    {
        float tiling_Y = 1;
        /// <summary>
        /// UV 增长插值
        /// </summary>
        [SerializeField]
        private float tiling_Y_IDW = 0.1f;
        /// <summary>
        /// 每个插值变化的时间间隔
        /// </summary>
        [SerializeField]
        private float tiling_Y_Speed = 2f;

        Tweener tweener;

        Material objMat;
        Material ObjMat
        {
            get
            {
                if (objMat == null)
                {
                    objMat = GetComponent<MeshRenderer>().material;
                }
                return objMat;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
           // PlayUVAni();
        }

        public void StartUVAni()
        {
            tweener = ObjMat.DOTiling(new Vector2(1, tiling_Y), tiling_Y_Speed).OnComplete(() => { tiling_Y += tiling_Y_IDW; StartUVAni(); });
            tweener.SetEase(Ease.Linear);
        }
        /// <summary>
        /// 开始播放UV动画
        /// </summary>
        public void PlayUVAni()
        {
            if (tweener != null)
            {
                tweener.Play();
            }
            else
            {
                StartUVAni();

            }
        }
        /// <summary>
        /// 暂停UV动画
        /// </summary>
        public void PauseUVAni()
        {
            if (tweener != null)
            {
                tweener.Pause();
            }
        }
    }
}
