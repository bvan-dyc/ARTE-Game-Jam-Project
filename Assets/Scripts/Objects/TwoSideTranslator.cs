using System;
using System.Collections;
using System.Collections.Generic;
using Gamekit3D.GameCommands;
using UnityEngine;

public class TwoSideTranslator : SimpleTranslator
{
    private float twoSideTranslation;

    public void FixedUpdate()
    {
        if (activate && twoSideTranslation < 1.0f)
        {
            twoSideTranslation += Time.deltaTime / duration;
        }
        else if (twoSideTranslation > 0.0f)
        {
            twoSideTranslation -= Time.deltaTime / duration;
        }

        if (twoSideTranslation > 0.0f && twoSideTranslation < 1.0f)
        {
            base.PerformTransform(Mathf.Clamp01(twoSideTranslation));
        }
    }

    public void Activate()
    {
        Debug.Log("activate");
        activate = true;
    }

    public void Deactivate()
    {
        Debug.Log("activate");
        activate = false;
    }
}
