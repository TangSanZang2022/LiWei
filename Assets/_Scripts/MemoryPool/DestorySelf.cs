using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    /// <summary>
    /// 多长时间之后自己消失
    /// </summary>
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnEnable()
    {
        StartCoroutine(IDestorySelf());
    }

    IEnumerator IDestorySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        GetComponent<BaseMemoryObj>().InPool();
    }
}
