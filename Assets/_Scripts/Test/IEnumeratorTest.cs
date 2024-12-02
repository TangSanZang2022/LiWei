using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumeratorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(100,100,100,100),"开启等待2秒协程"))
        {
            StartCoroutine(ITest(2, "等待2秒协程"));
        }
        if (GUI.Button(new Rect(100, 300, 100, 100), "开启等待5秒协程"))
        {
            StartCoroutine(ITest(5, "等待5秒协程"));
        }
    }

    private IEnumerator ITest(float f, string s)
    {
        yield return new WaitForSeconds(f);
        Debug.Log(s);
    }
}
