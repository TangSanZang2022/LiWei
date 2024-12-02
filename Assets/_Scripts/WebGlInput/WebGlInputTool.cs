using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGlInputTool : MonoBehaviour
{
    /// <summary>
    /// 是否打开键盘输入
    /// </summary>
    public bool openKeyboardInput;
    private void Awake()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            UnityEngine.WebGLInput.captureAllKeyboardInput = openKeyboardInput; //false or true
           
#endif
    }

}
