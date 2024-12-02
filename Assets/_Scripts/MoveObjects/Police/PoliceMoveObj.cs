using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
/// <summary>
/// 警员移动脚本
/// </summary>
public class PoliceMoveObj : BaseMoveObject
{

    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(1) && !replayController.isPlaying)//按下鼠标右键
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in raycastHits)
            {

                if (hit.transform.CompareTag("Road"))
                {
                    // roadPoints.Add(transform.position);//添加到路径点列表，以便回放
                    //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //go.transform.position = transform.position;
                    UpdateObjSync(hit.point);
                    //roadPoints.Add(hit.point);//添加到路径点列表，以便回放
                    break;
                }
            }
        }
       
    }
    public override void UpdateObj(object data)
    {
        base.UpdateObj(data);
        Stopimer();
        StartTimer();
    }
    /// <summary>
    /// 创建介绍UI
    /// </summary>
    protected override void CreateIntroductionUI()
    {
        base.CreateIntroductionUI();
    }

    protected override void MouseDownHandle()
    {
        base.MouseDownHandle();
        //此处为测试用，测试
        if (Input.GetKey(KeyCode.LeftShift))
        {
            meshAgent.enabled = false;
            transform.position = transform.position;
            meshAgent.enabled = true;
            trackPpintsList.Add(transform.position);
            //UpdateObjSync(transform.position);
            replayController.OnInit(trackPpintsList, meshAgent);
            replayController.ReplayRuningData();
            Stopimer();
           
        }
       
    }
     /// <summary>
     /// 开始删除倒计时
     /// </summary>
    public void StartTimer()
    {
        StartCoroutine("IDestorySelf");
    }
    /// <summary>
    /// 开始删除倒计时
    /// </summary>
    public void Stopimer()
    {
        StopCoroutine("IDestorySelf");
    }

    private IEnumerator IDestorySelf()
    {
        yield return new WaitForSeconds(3);//三秒之后删除
        GameFacade.Instance.RemoveMoveObjInDic(id);
        Destroy(gameObject);
    }

    


}


