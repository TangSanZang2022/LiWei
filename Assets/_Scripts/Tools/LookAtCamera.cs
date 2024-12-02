using DFDJ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// 始终朝向相机的物体
 /// </summary>
public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private Transform targetCam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetCam == null)
        {
           // targetCam = GetComponent<BaseWorldUIIcon>().targetCam.transform;
            //if (targetCam==null)
            //{
                targetCam = Camera.main.transform;
            //}
            return;
        }
        transform.LookAt(targetCam);//始终看向相机 
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0 );
    }
    /// <summary>
    /// 获取当前相机
    /// </summary>
    /// <returns></returns>
    public Transform Get_targetCam()
    {
        return targetCam;
    }
    /// <summary>
    /// 设置当前相机
    /// </summary>
    /// <param name="trans"></param>
    public void Set_targetCam(Transform trans)
    {
        targetCam = trans;
    }
}
