using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD_Player_Foley : MonoBehaviour
{
    #region TEMP test code
    Vector3 last_Position;
    float distanceWalked = 0f;
    [SerializeField] float stepDistance = .6f;
    [SerializeField] [Range(0f, 1f)] float preStepTiming = .43f;
    bool isLeftStep = true;
    bool preStepped = false;

    void Awake()
    {
        last_Position = transform.position;
    }

    void Update()
    {
        distanceWalked += Vector3.Distance(transform.position, last_Position);
        if (!preStepped && distanceWalked > stepDistance * preStepTiming) PreStep();
        if (distanceWalked > stepDistance) FootStep();
        last_Position = transform.position;
    }



    void PreStep()
    {
        isLeftStep = !isLeftStep;
        if (isLeftStep) AD_PreStepLeft(); else AD_PreStepRight();
        preStepped = true;
    
    }

    void FootStep()
    {
        if (isLeftStep) AD_FootStepLeft(); else AD_FootStepRight();
        distanceWalked = 0f;
        preStepped = false;
    }
    #endregion


    #region Animation Events
    public void AD_PreStepLeft()
    {
        AkSoundEngine.SetSwitch("Foot", "left", gameObject); 
        AkSoundEngine.PostEvent("Prestep", gameObject);
    }

    public void AD_PreStepRight()
    {
        AkSoundEngine.SetSwitch("Foot", "right", gameObject);
        AkSoundEngine.PostEvent("Prestep", gameObject);
    }

    public void AD_FootStepLeft()
    {
        AkSoundEngine.PostEvent("Footstep", gameObject);
    }

    public void AD_FootStepRight()
    {
        AkSoundEngine.PostEvent("Footstep", gameObject);
    }

    #endregion
}
