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
    [SerializeField] GameObject hips;
    [SerializeField] GameObject back;
    [SerializeField] GameObject neck;
    [SerializeField] GameObject head;

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
        AkSoundEngine.PostEvent("Bones_Knee", kneeLeft);
        AkSoundEngine.PostEvent("Walk_Hips", hipsLeft);
        AkSoundEngine.PostEvent("Prestep_Shoulder", shoulderLeft);
    }

    public void AD_PreStepRight()
    {
        AkSoundEngine.PostEvent("Bones_Knee", kneeRight);
        AkSoundEngine.PostEvent("Walk_Hips", hipsRight);
        AkSoundEngine.PostEvent("Prestep_Shoulder", shoulderRight);
    }

    public void AD_FootStepLeft()
    {
        AkSoundEngine.PostEvent("Footstep", footLeft);
        AkSoundEngine.PostEvent("Bones_Elbow", elbowLeft);
    }

    public void AD_FootStepRight()
    {
        AkSoundEngine.PostEvent("Footstep", footRight);
        AkSoundEngine.PostEvent("Bones_Elbow", elbowRight);
    }


    public void AD_ArmLeft()
    {
        AkSoundEngine.PostEvent("Prestep_Shoulder", shoulderLeft);
        AkSoundEngine.PostEvent("Bones_Elbow", elbowLeft);
    }

    public void AD_ArmRight()
    {
        AkSoundEngine.PostEvent("Prestep_Shoulder", shoulderRight);
        AkSoundEngine.PostEvent("Bones_Elbow", elbowRight);
    }

    public void AD_KneeLeft()
    {
        AkSoundEngine.PostEvent("Bones_Knee", kneeLeft);
    }

    public void AD_KneeRight()
    {
        AkSoundEngine.PostEvent("Bones_Knee", kneeRight);
    }

    public void AD_HitKneeLeft()
    {
        AkSoundEngine.PostEvent("Hit_Knee", kneeLeft);
    }

    public void AD_HitKneeRight()
    {
        AkSoundEngine.PostEvent("Hit_Knee", kneeRight);
    }

    public void AD_HitTorso()
    {
        AkSoundEngine.PostEvent("Hit_Torso", back);
    }

    public void AD_HitHips()
    {
        AkSoundEngine.PostEvent("Hit_Hips", hips);
    }

    public void AD_HitHead()
    {
        AkSoundEngine.PostEvent("Hit_Head", head);
    }


    public void AD_NeckSnap()
    {
        AkSoundEngine.PostEvent("Snap_Neck", neck);
    }

    public void AD_PushButton()
    {
        AkSoundEngine.PostEvent("Push_Button", handRight);
    }
    #endregion
}
