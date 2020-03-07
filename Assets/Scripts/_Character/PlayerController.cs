using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(BodyController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Serializable]
    public class DeathEvent : UnityEvent<PlayerController>
    { }

    protected static PlayerController s_Instance;
    public static PlayerController instance { get { return s_Instance; } }
 
    [SerializeField] protected GameObject bodyPrefab = null;
    [SerializeField] protected AudioSource footstepsAudioSource = null;
    [SerializeField] protected float respawnDelay = 3;
    [SerializeField] protected int maxLives = 7;
    public DeathEvent OnDeath;

    protected UserInput input;
    protected Checkpoint _CurrentCheckpoint;
    protected List<BodyController> playerCorpses = new List<BodyController>();
    protected BodyController currentBody;
    protected BodyController mainBody;
    protected Animator animator;
    protected int currentBodyIndex = 0;
    protected Checkpoint currentCheckpoint;
    protected bool respawning;
    protected CameraFollow mainCamera;
    protected int livesLeft = 6;
    readonly int hashDeath = Animator.StringToHash("Death");
    readonly int hashRespawn = Animator.StringToHash("Respawn");

    public int LivesLeft
    {
        get { return livesLeft; }
    }

    public int MaxLives
    {
        get { return maxLives; }
    }

    void Awake()
    {
        s_Instance = this;
        animator = GetComponent<Animator>();

        playerCorpses.Add(GetComponent<BodyController>());
        mainBody = playerCorpses[0];
        currentBody = mainBody;
    }

    private void Start()
    {
        input = UserInput.Instance;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    void FixedUpdate()
    {
        if (input.MoveRequest)
            CommandMove();
        if (input.SwitchRequest)
            SwitchControlledBody();
    }

    private void CommandMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            transform.LookAt(hit.point);
            currentBody.MoveTo(hit.point);
        }
    }

    public void OnDie()
    {
        Debug.Log("Player Died");
        respawning = true;
        currentBody.ResetBody();
        input.playerControllerInputBlocked = true;
        animator.SetTrigger(hashDeath);
        livesLeft--;
        Respawn();
    }

    private void SpawnFormerBody()
    {
        if (bodyPrefab.GetComponent<BodyController>())
        {
            GameObject newbody = Instantiate(bodyPrefab);
            newbody.transform.position = transform.position;
            playerCorpses.Add(newbody.GetComponent<BodyController>());
        }
    }

    private void SwitchControlledBody()
    {
        if (playerCorpses.Count < 2)
            return;
        
        currentBodyIndex = currentBodyIndex + 1 >= playerCorpses.Count ? 0 : currentBodyIndex + 1;
        currentBody.LeaveBody();
        Debug.Log(currentBody.name + " was left");
        currentBody = playerCorpses[currentBodyIndex];
        Debug.Log(currentBody.name + " was entered");
        currentBody.EnterBody();
        mainCamera.SetTarget(currentBody.transform);
    }

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint != null)
            currentCheckpoint = checkpoint;
    }

    private void Respawn()
    {
        StartCoroutine(RespawnRoutine());
    }

    protected IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnFormerBody();
        OnDeath.Invoke(this);
        if (currentCheckpoint != null)
        {
            transform.position = currentCheckpoint.transform.position;
            transform.rotation = currentCheckpoint.transform.rotation;
        }
        else
        {
            Debug.LogError("There is no Checkpoint set");
        }
        respawning = false;
        input.playerControllerInputBlocked = false;
        animator.SetTrigger(hashRespawn);
        yield return null;
    }
}
