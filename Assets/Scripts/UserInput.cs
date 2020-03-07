using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static UserInput Instance
    {
        get { return s_Instance; }
    }

    protected static UserInput s_Instance;
    protected Vector2 m_Movement;
    protected bool m_MoveRequest;
    protected bool m_ExternalInputBlocked;
    public bool playerControllerInputBlocked;
    protected bool m_MouseControl;

    public bool MouseControl
    {
        get
        {
            return (m_MouseControl);
        }
    }

    public Vector2 MoveInput
    {
        get
        {
            if (playerControllerInputBlocked || m_ExternalInputBlocked)
                return Vector2.zero;
            return m_Movement;
        }
    }

    public bool MoveRequest
    {
        get { return m_MoveRequest && !m_ExternalInputBlocked && !playerControllerInputBlocked; }
    }

    void Awake()
    {

        if (s_Instance == null)
            s_Instance = this;
        else if (s_Instance != this)
            throw new UnityException("There cannot be more than one UserInput script.  The instances are " + s_Instance.name + " and " + name + ".");
    }

    void Update()
    {
        //m_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_MoveRequest = Input.GetMouseButton(0);
    }

    public bool HaveControl()
    {
        return !m_ExternalInputBlocked;
    }

    public void ReleaseControl()
    {
        m_ExternalInputBlocked = true;
    }

    public void GainControl()
    {
        m_ExternalInputBlocked = false;
    }
}
