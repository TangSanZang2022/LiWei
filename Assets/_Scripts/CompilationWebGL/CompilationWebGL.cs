using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR 
          

public class CompilationWebGL : MonoBehaviour
{
    [MenuItem("Custom/CompilationWebGL")]
    static public void AddWebGL()
    {
        PlayerSettings.WebGL.emscriptenArgs = "-s\"BINARYEN_TRAP_MODE='clamp'\"";
    }
}
#endif