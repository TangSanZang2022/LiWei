using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveObjTool;
using DG.Tweening;

namespace Cigarette
{
    /// <summary>
    ///移动的UI
    /// </summary>
    public class CigaretteMoveUI : BaseMoveObj
    {
      
        /// <summary>
        /// 移动类型
        /// </summary>
        [SerializeField]
        private Ease ease;


        private void OnEnable()
        {
            //currentPointIndex = 1;
            //transform.position = Get_roadPointList()[0].transform.position;
            //currentPointIndex = 0;

            MoveToNextPoint();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override void MoveToNextPoint()
        {
            //base.MoveToNextPoint();
            if (roadPointList.Count <= currentPointIndex)
            {
                //tweener.Kill();
                currentBaseRoadPoint = null;
                currentPointIndex = 0;
                tweener = null;
                if (!isLoop)//不循环
                {
                  return;
                }  
            }
          
            currentBaseRoadPoint = roadPointList[currentPointIndex];
            //float distance = Vector3.Distance(transform.position, currentBaseRoadPoint.transform.position);
            //float time = distance / moveSpeed;


            //currentBaseRoadPoint.LeavedPoint();
            int index = currentPointIndex - 1<0?0 : currentPointIndex - 1;
            if (index < roadPointList.Count&& index>=0)
            {
                if (index==0)
                {
                    index = roadPointList.Count - 1;
                }
                BaseRoadPoint lastBaseRoadPoint = roadPointList[index];
                lastBaseRoadPoint.LeavedPoint();
            }
            
            tweener = transform.GetComponent<RectTransform>().DOLocalMove(currentBaseRoadPoint.GetComponent<RectTransform>().localPosition, currentBaseRoadPoint.arrivedTime).OnComplete(() => {
                currentBaseRoadPoint.ArrivedPoint(this);
                currentPointIndex++; MoveToNextPoint();
                
                ;
            }
            );
            tweener.SetEase(ease);
        }
    }
}
