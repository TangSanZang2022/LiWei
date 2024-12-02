using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTest : MonoBehaviour
{
    private static LoadSceneTest _instance;
    public static LoadSceneTest Instance
    {
        get
        {
            return _instance;
        }
    }

    private static bool isLoading = false;
    private void Awake()
    {
        isLoading = false;
        if (_instance != null)//当单例不为空的时候就删除此物体防止他在场景中存在多个
        {
            Destroy(this.gameObject); return;
        }
        else
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.N))
        {
            MySceneManager.LoadSceneSync("ErLian");

        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            MySceneManager.LoadSceneSync("ErLian2");

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //WriteTxtHelper.WriteString(WriteTxtHelper.errorMessageFromServerWritePath, "aaaaa");
            //WriteTxtHelper.WriteString("ww.txt", "aaaaa");

        }
       

    }
}
