using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD_Door : MonoBehaviour
{
    [SerializeField] GameObject doorObject;
    private bool isSliding = false;
    private Transform lastPos;

    private void Start()
    {
        lastPos = doorObject.transform;
    }

    void Update()
    {
        if (!isSliding && doorObject.transform != lastPos)
        {
            AkSoundEngine.PostEvent("Open_Door", doorObject);
            isSliding = true;
        }

        if (isSliding && doorObject.transform == lastPos)
        {
            AkSoundEngine.PostEvent("Stop_Door", doorObject);
            isSliding = false;
        }
    }
}
