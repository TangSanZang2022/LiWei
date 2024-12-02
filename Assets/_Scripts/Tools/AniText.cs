using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Tool
{
    public class AniText : MonoBehaviour
    {

        private float textNum;

        private float TextNum
        {
            get
            {
                return textNum;
            }
            set
            {
                GetComponent<Text>().text = value.ToString("f0");
                textNum = value;
            }
        }

        /// <summary>
        /// 数字变化速度
        /// </summary>
        [SerializeField]
        public float speed = 1;


        /// <summary>
        /// 目标值
        /// </summary>
        private float endValue;

        public void Set_endValue(float f)
        {
            if (endValue != f)
            {
                StopAllCoroutines();
                if (ChangeNum == null)
                {
                    ChangeNum = IChangeNum(f);
                    endValue = f;
                    StartCoroutine(ChangeNum);
                }
                else
                {
                    StopAllCoroutines();
                    ChangeNum = IChangeNum(f);
                    endValue = f;
                    StartCoroutine(ChangeNum);
                }
            }
        }
        IEnumerator ChangeNum;

        private IEnumerator IChangeNum(float num)
        {

            endValue = num;
            float f = Mathf.Abs(endValue - TextNum);
            speed = f;
            float symbol = endValue > TextNum ? 1 : -1;
            while (Mathf.Abs(endValue - TextNum) > speed* Time.deltaTime*2)
            {
                TextNum += speed * symbol * Time.deltaTime;
                yield return 0;

            }
            TextNum = endValue;
            ChangeNum = null;
        }

        //private void OnDisable()
        //{
        //    TextNum = endValue;
        //}
    }
}
