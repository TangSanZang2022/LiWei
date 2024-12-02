using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
/// <summary>
/// 物体移动
/// </summary>
public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ID
    /// </summary>
    public string ID
    {
        get;
        set;
    }
    /// <summary>
    /// 回放时得到下个点的速度
    /// </summary>
    public float getPointSpeed;
    /// <summary>
    /// 回放时移动速度
    /// </summary>
    public float replayMoveSpeed;
    /// <summary>
    /// 存放所有行走的路径点
    /// </summary>
    private List<Vector3> roadPoints = new List<Vector3>();
    /// <summary>
    /// 寻路组件
    /// </summary>
    private NavMeshAgent meshAgent;
    /// <summary>
    /// 轨迹回放控制器
    /// </summary>
    ReplayController replayController;
    // Start is called before the first frame update
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        replayController = GameObject.Find("ReplayController").GetComponent<ReplayController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!replayController.isPlaying)//按下鼠标左键
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in raycastHits)
            {

                if (hit.transform.CompareTag("Road"))
                {
                    roadPoints.Add(transform.position);//添加到路径点列表，以便回放
                    meshAgent.SetDestination(hit.point);
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            roadPoints.Add(transform.position);//添加到路径点列表，以便回放
            replayController.OnInit(roadPoints, meshAgent);
            replayController.ReplayRuningData();
        }
    }

 
}
