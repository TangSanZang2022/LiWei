using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPanel : BasePanel
{
    public override void OnEnter()
    {
        gameObject.SetActive(true);
    }

    public override void OnPause()
    {
        gameObject.SetActive(false);
    }

    public override void OnResume()
    {
        gameObject.SetActive(true);
    }

    public override void OnExit()
    {
        gameObject.SetActive(false);
    }
}
