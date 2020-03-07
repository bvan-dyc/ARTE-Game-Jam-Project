using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionnalTrap : Trap
{
    private bool _activate = false;
    
    public void OnTriggerEnter(Collider other)
    {
        if (_activate) ItsATrap(other);
    }

    public void Activate()
    {
        _activate = true;
    }

    public void Deactivate()
    {
        _activate = true;
    }
}
