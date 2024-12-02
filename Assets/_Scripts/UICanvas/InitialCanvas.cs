using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialCanvas : MonoBehaviour
{
    private int screenWidth;
    private int screenHeight;
    private float normalScale;
    // Start is called before the first frame update
    void Start()
    {
        normalScale = 1960.0f / 1080.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(300,100,100,50),"自适应分辨率"))
        {
            float realScale = (float)Screen.width / (float)Screen.height;
            if (normalScale> realScale)
            {
                screenHeight = Screen.height;
                GetComponent<CanvasScaler>().scaleFactor = screenHeight / (float)1080;
            }
            else if (normalScale<realScale)
            {
                screenWidth= Screen.width;
                GetComponent<CanvasScaler>().scaleFactor = screenWidth / (float)1960;
            }
            //screenWidth = Screen.width;

            //transform.FindChildForName("Panel").localScale = new Vector3(screenWidth / (float)1960, screenHeight / (float)1080, 1);
        }
    }
}
