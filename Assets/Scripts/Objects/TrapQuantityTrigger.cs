using System.Collections;
using System.Collections.Generic;
using Gamekit3D;
using UnityEngine;

public class TrapQuantityTrigger : InteractOnTrigger
{
    public int quantity;

    private int _count;
    
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        var body = other.GetComponent<BodyController>();
        if (body == null) return;
        _count += 1;
        if (_count < quantity) return;
        
        if (0 != (layers.value & 1 << other.gameObject.layer))
        {
            ExecuteOnEnter(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        var body = other.GetComponent<BodyController>();
        if (body == null) return;

        if (_count == quantity)
        {
            if (0 != (layers.value & 1 << other.gameObject.layer))
            {
                ExecuteOnExit(other);
            }
        }
        
        _count -= 1;
    }
}
