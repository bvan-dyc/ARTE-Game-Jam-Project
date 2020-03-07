using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD_Player_Foley : MonoBehaviour
{
    [SerializeField] GameObject footLeft;
    [SerializeField] GameObject footRight;
    [SerializeField] GameObject kneeLeft;
    [SerializeField] GameObject kneeRight;
    [SerializeField] GameObject hipsLeft;
    [SerializeField] GameObject hipsRight;
    [SerializeField] GameObject shoulderLeft;
    [SerializeField] GameObject shoulderRight;
    [SerializeField] GameObject elbowLeft;
    [SerializeField] GameObject elbowRight;
    [SerializeField] GameObject handLeft;
    [SerializeField] GameObject handRight;
    [SerializeField] GameObject back;
    [SerializeField] GameObject neck;

    private void Awake()
    {
        InitAKSwitches();
    }

    private void InitAKSwitches()
    {
        AkSoundEngine.SetSwitch("Side", "left", footLeft);
        AkSoundEngine.SetSwitch("Side", "right", footRight);
        AkSoundEngine.SetSwitch("Side", "left", kneeLeft);
        AkSoundEngine.SetSwitch("Side", "right", kneeRight);
        AkSoundEngine.SetSwitch("Side", "left", hipsLeft);
        AkSoundEngine.SetSwitch("Side", "right", hipsRight);
        AkSoundEngine.SetSwitch("Side", "left", shoulderLeft);
        AkSoundEngine.SetSwitch("Side", "right", shoulderRight);
        AkSoundEngine.SetSwitch("Side", "left", elbowLeft);
        AkSoundEngine.SetSwitch("Side", "right", elbowRight);
        AkSoundEngine.SetSwitch("Side", "left", handLeft);
        AkSoundEngine.SetSwitch("Side", "right", handRight);
    }

    #region Animation Events
    public void AD_PreStepLeft()
    {
        AkSoundEngine.PostEvent("Prestep_Knee", kneeLeft);
        AkSoundEngine.PostEvent("Walk_Hips", hipsLeft);
        AkSoundEngine.PostEvent("Prestep_Shoulder", shoulderLeft);
    }

    public void AD_PreStepRight()
    {
        AkSoundEngine.PostEvent("Prestep_Knee", kneeRight);
        AkSoundEngine.PostEvent("Walk_Hips", hipsRight);
        AkSoundEngine.PostEvent("Prestep_Shoulder", shoulderRight);
    }

    public void AD_FootStepLeft()
    {
        AkSoundEngine.PostEvent("Footstep", footLeft);
        AkSoundEngine.PostEvent("Footstep_Elbow", elbowLeft);
        AkSoundEngine.PostEvent("Footstep_Hips", hipsLeft);
    }

    public void AD_FootStepRight()
    {
        AkSoundEngine.PostEvent("Footstep", footRight);
        AkSoundEngine.PostEvent("Footstep_Elbow", elbowRight);
    }

    #endregion
}
