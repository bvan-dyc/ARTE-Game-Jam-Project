using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Checkpoint : MonoBehaviour
{
	[SerializeField] protected bool initialLevelSpawn = false;

	private void Awake()
	{
		//we make sure the checkpoint is part of the Checkpoint layer, which is set to interact ONLY with the player layer.
		gameObject.layer = LayerMask.NameToLayer("Checkpoint");
	}

	private void Start()
	{
		if (initialLevelSpawn)
		{
			PlayerController.instance.SetCheckpoint(this);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			PlayerController controller = other.GetComponent<PlayerController>();

			if (controller == null)
				return;

			controller.SetCheckpoint(this);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue * 0.75f;
		Gizmos.DrawSphere(transform.position, 0.1f);
		Gizmos.DrawRay(transform.position, transform.forward * 2);
	}
}