using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    protected static PlayerController s_Instance;
    public static PlayerController instance { get { return s_Instance; } }

    protected UserInput m_Input;
    protected Animator m_Animator;
    protected NavMeshAgent m_Agent;
    [SerializeField] protected GameObject corpsePrefab = null;
    [SerializeField] protected AudioSource footstepsAudioSource = null;
    protected Checkpoint m_CurrentCheckpoint;
    protected bool m_Respawning;

    protected bool IsMoveInput
    {
        get { return !Mathf.Approximately(m_Input.MoveInput.sqrMagnitude, 0f); }
    }


    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();

        s_Instance = this;
    }

    private void Start()
    {
        m_Input = UserInput.Instance;
    }

    void FixedUpdate()
    {
        if (m_Input.MoveRequest)
            MoveToTarget();
    }

    private void MoveToTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            transform.LookAt(hit.point);
            m_Agent.destination = hit.point;
        }
    }

    private void PlayPlayerAudio()
    {

    }

    private void resetTarget()
    {
        m_Agent.isStopped = true;
        m_Agent.ResetPath();
    }

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint != null)
            m_CurrentCheckpoint = checkpoint;
        // If there is a checkpoint, move Player to it.
        if (m_CurrentCheckpoint != null)
        {
            transform.position = m_CurrentCheckpoint.transform.position;
            transform.rotation = m_CurrentCheckpoint.transform.rotation;
        }
        else
        {
            Debug.LogError("There is no Checkpoint set, there should always be a checkpoint set. Did you add a checkpoint at the spawn?");
        }
    }

    private void OnDie()
    {
        m_Agent.isStopped = true;
        m_Agent.ResetPath();
        m_Respawning = true;
        if (corpsePrefab.GetComponent<Rigidbody>())
        {
            GameObject deadbody = Instantiate(corpsePrefab);
            deadbody.GetComponent<Rigidbody>().transform.position = transform.position;
        }
    }

    private void Respawn()
    {
        StartCoroutine(RespawnRoutine());
    }

    protected IEnumerator RespawnRoutine()
    {
        yield return StartCoroutine(ScreenFader.FadeSceneOut());
        while (ScreenFader.IsFading)
        {
            yield return null;
        }
        yield return StartCoroutine(ScreenFader.FadeSceneIn());
    }
}
