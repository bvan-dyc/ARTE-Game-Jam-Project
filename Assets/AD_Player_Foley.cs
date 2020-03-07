using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD_Player_Foley : MonoBehaviour
{
    #region TEMP test code
    Vector3 last_Position;
    float distanceWalked;
    [SerializeField] float stepDistance = .6f;
    bool isLeftStep = true;

    void Awake()
    {
        last_Position = transform.position;
        distanceWalked = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        distanceWalked += Vector3.Distance(transform.position, last_Position);
        if (distanceWalked > stepDistance) FootStep();
        last_Position = transform.position;
    }

    void FootStep()
    {
        if (isLeftStep) AD_FootStepLeft(); else AD_FootStepRight();
        isLeftStep = !isLeftStep;
        distanceWalked = 0f;
    }
    #endregion


    #region Animation Events
    public void AD_FootStepLeft()
    {
        AkSoundEngine.PostEvent("Footstep", gameObject);
        AkSoundEngine.SetSwitch("Foot", "left", gameObject);
    }

    public void AD_FootStepRight()
    {
        AkSoundEngine.PostEvent("Footstep", gameObject);
        AkSoundEngine.SetSwitch("Foot", "right", gameObject);
    }

    #endregion
}
