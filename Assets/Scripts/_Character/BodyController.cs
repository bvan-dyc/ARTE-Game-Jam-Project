using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BodyController : MonoBehaviour
{
    protected Animator animator;
    protected NavMeshAgent agent;

    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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

    private void PlayAudio()
    {

    }

    public void OnDie()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void MoveTo(Vector3 newDestination)
    {
        transform.LookAt(newDestination);
        agent.destination = newDestination;
    }
}

