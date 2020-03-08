using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEffect : MonoBehaviour
{
    [SerializeField] protected GameObject pendulum = null;
    [SerializeField] protected Transform pendulumSpawn = null;
    protected ParticleSystem bloodParticleSystem;

    private void Start()
    {
        PlayerController.instance.OnDeath.AddListener(PlayDeathEffect);
    }

    public void PlayDeathEffect(PlayerController player)
    {
        GameObject newbody = Instantiate(pendulum);
        pendulum.transform.position = pendulumSpawn.position;
    }
}
