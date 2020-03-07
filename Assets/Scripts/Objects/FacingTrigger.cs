using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FacingTrigger : MonoBehaviour
{
    [SerializeField] private Direction facing;
    protected Collider triggerCollider;
    protected Transform body;
    protected bool activated = false;
    protected int numberOfBodies = 0;

    public bool IsActivated
    {
        get
        {
            return (activated);
        }
    }

    private enum Direction
    {
        left,
        right,
        backward,
        forward
    }

    private void FixedUpdate()
    {
        if (!body)
            return;
        activated = CheckBodyFacing() == facing;
    }

    private Direction CheckBodyFacing()
    {
        if (body.transform.rotation.y > 315f || body.transform.rotation.y <= 45f)
            return (Direction.forward);
        else if (body.transform.rotation.y > 45f && body.transform.rotation.y <= 135f)
            return (Direction.right);
        else if (body.transform.rotation.y > 135f && body.transform.rotation.y <= 225f)
            return (Direction.backward);
        else
            return (Direction.left);
    }

    private void OnTriggerEnter(Collider other)
    {
        numberOfBodies++;
        if (body)
            return;
        if (other.tag == "Player" || other.tag == "Corpse")
        {
            body = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        numberOfBodies--;
        if (numberOfBodies > 0)
            return;
        else
            body = null;
    }
}
