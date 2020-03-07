using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class BodyController : MonoBehaviour
{
    protected Animator animator;
    protected NavMeshAgent agent;

    readonly int hashForwardSpeed = Animator.StringToHash("Speed");
    readonly int hashPossessed = Animator.StringToHash("Possessed");

    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        animator.SetFloat(hashForwardSpeed, agent.velocity.magnitude);
    }

    public void ResetTarget()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void ResetBody()
    {
        ResetTarget();
    }

    public void LeaveBody()
    {
        ResetTarget();
        animator.SetBool(hashPossessed, false);
    }

    public void EnterBody()
    {
        ResetTarget();
        animator.SetBool(hashPossessed, true);
    }

    private void PlayAudio()
    {

    }

    public void MoveTo(Vector3 newDestination)
    {
        transform.LookAt(newDestination);
        agent.destination = newDestination;
    }
}

