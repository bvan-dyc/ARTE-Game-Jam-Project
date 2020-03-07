using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FacingTrigger : MonoBehaviour
{
    [SerializeField] private Direction facing = Direction.left;
    protected Collider triggerCollider;
    protected List<Transform> bodies = new List<Transform>();
    [SerializeField] protected bool activated = false;
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
        if (bodies.Count == 0)
            return;
        activated = BodiesFacing() == facing;
    }

    private Direction BodiesFacing()
    {
        if (bodies[0].transform.rotation.y > 315f || bodies[0].transform.rotation.y <= 45f)
            return (Direction.forward);
        else if (bodies[0].transform.rotation.y > 45f && bodies[0].transform.rotation.y <= 135f)
            return (Direction.right);
        else if (bodies[0].transform.rotation.y > 135f && bodies[0].transform.rotation.y <= 225f)
            return (Direction.backward);
        else
            return (Direction.left);
    }

    private void OnTriggerEnter(Collider other)
    {
        bodies.Add(other.transform);
        if (other.tag == "Player" || other.tag == "Corpse")
        {
            bodies[0] = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bodies.Remove(other.transform);
    }
}
