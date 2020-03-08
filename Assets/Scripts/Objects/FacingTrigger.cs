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
    private const float tolerance = 0.9f;

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
        Debug.Log(activated);
    }

    private Direction BodiesFacing()
    {
        float leftDot = Vector3.Dot(-Vector3.right, bodies[0].transform.forward);
        if (leftDot > tolerance)
            return Direction.left;
        if (leftDot < -tolerance)
            return Direction.right;
        float topDot = Vector3.Dot(-Vector3.forward, bodies[0].transform.forward);
        if (topDot > tolerance)
            return Direction.forward;
        else
            return Direction.backward;
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
