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
    protected Vector2 _Movement;
    protected bool _MoveRequest;
    protected bool _SwitchRequest;
    protected bool _ExternalInputBlocked;
    public bool playerControllerInputBlocked;
    protected bool _MouseControl;

    public bool MouseControl
    {
        get
        {
            return (_MouseControl);
        }
    }

    public Vector2 MoveInput
    {
        get
        {
            if (playerControllerInputBlocked || _ExternalInputBlocked)
                return Vector2.zero;
            return _Movement;
        }
    }

    public bool MoveRequest
    {
        get { return _MoveRequest && !_ExternalInputBlocked && !playerControllerInputBlocked; }
    }

    public bool SwitchRequest
    {
        get { return _SwitchRequest && !_ExternalInputBlocked && !playerControllerInputBlocked; }
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
        //_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _MoveRequest = Input.GetMouseButton(0);
        _SwitchRequest = Input.GetKeyDown(KeyCode.Space);
    }

    public bool HaveControl()
    {
        return !_ExternalInputBlocked;
    }

    public void ReleaseControl()
    {
        _ExternalInputBlocked = true;
    }

    public void GainControl()
    {
        _ExternalInputBlocked = false;
    }
}
