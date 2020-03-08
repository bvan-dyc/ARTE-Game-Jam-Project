using System;
using System.Collections;
using System.Collections.Generic;
using Gamekit3D.GameCommands;
using UnityEngine;

public class TwoSideTranslator : SimpleTranslator
{
    [SerializeField] AK.Wwise.Event soundStart;
    [SerializeField] AK.Wwise.Event soundStop;
    private float twoSideTranslation;
    private bool isSliding = false;

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
            if (!isSliding)
            {
                if (soundStart!=null)  soundStart.Post(gameObject);
                isSliding = true;
            }
        }

        else if (isSliding)
        {
            if (soundStop != null) soundStop.Post(gameObject);
            isSliding = false;
        }
    }

    public void Activate()
    {
        Debug.Log("activate");
        activate = true;
        //isSliding = true;
        //if (soundStart != null) soundStart.Post(gameObject);
    }

    public void Deactivate()
    {
        Debug.Log("activate");
        activate = false;
    }
}
