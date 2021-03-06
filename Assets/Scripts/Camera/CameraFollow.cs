﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private float offset = 60f;
	private Transform target;
    void Start()
    {
		target = PlayerController.instance.gameObject.transform;
    }

    void LateUpdate()
    {
		transform.rotation = Quaternion.Euler(30, 45, 0);
		transform.position = target.position - (Quaternion.Euler(30, 45, 0) * Vector3.forward * offset);
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
}
