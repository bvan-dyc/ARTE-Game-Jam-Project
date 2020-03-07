using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantityTrap : Trap
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
        ItsATrap(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var body = other.GetComponent<BodyController>();
        if (body == null) return;
        _count -= 1;
    }
}
