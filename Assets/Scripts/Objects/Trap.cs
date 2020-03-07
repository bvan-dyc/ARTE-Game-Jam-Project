using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Trap : MonoBehaviour
{
    private BoxCollider _collider;
    private Rigidbody _rigidbody;
    private bool _triggered;
    
    private void Awake()
    {
        _triggered = false;
        
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var player = other.GetComponent<PlayerController>();
        if (player == null && !_triggered) return;
        _triggered = true;
        player.OnDie();
    }
}
