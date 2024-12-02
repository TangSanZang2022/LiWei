using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UnityCallJs : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void StartTime();
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str,int a);
    [DllImport("__Internal")]
    private static extern string GetMsg();

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);

    void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            UnityEngine.WebGLInput.captureAllKeyboardInput = false; // or true
         //StartTime();
        StartCoroutine(IWaitToCallStartTime());
#endif


        //Hello();

        // HelloString("This is a string.",1);

        // Debug.Log("收到JS的信息" + GetMsg());

        //float[] myArray = new float[10];
        //PrintFloatArray(myArray, myArray.Length);

        //int result = AddNumbers(5, 7);
        //Debug.Log(result);

        //Debug.Log(StringReturnValueFunction());

        //var texture = new Texture2D(0, 0, TextureFormat.ARGB32, false);
        //BindWebGLTexture((int)texture.GetNativeTexturePtr());

        // Application.ExternalCall("UnityLoadCompleted");
    }


    private void Btn1Click()
    {
        Debug.Log("按钮1点击");
       // Application.ExternalCall("MyFunction3", "one", 2, 3.2f);

      
    }
    private void Btn2Click()
    {

    }
    private void Btn3Click()
    {
        
    }

    IEnumerator IWaitToCallStartTime()
    {
        yield return new WaitForSeconds(0.1f);
        StartTime();
    }
}

// Update is called once per frame


