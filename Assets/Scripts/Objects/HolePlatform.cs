using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class HolePlatform : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Transform platform;
    [SerializeField] public float speed = 1.0f;

    private Vector3 _startPosition;
    private bool _active = false;

    private void Start()
    {
        _startPosition = platform.transform.position;
    }

    private void Update()
    {
        var translate = (_active ? target.position : _startPosition) * (speed * Time.deltaTime);
        platform.transform.Translate(translate);
    }

    public void Activate()
    {
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }
}
