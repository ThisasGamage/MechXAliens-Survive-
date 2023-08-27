using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private float timeOfLastAttack = 0;
    private bool hasStopped = false;

    private NavMeshAgent agent = null;
    private Animator anim = null;
    private EnemyStats stats = null;
    private Transform target;

    private void Start()
    {
        GetRefrences();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTargert = Vector3.Distance(target.position, transform.position);
        if (distanceToTargert <= agent.stoppingDistance)
        {
            anim.SetFloat("speed", 0);

            //Attack

            if (hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }
        
            if(Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                AttackTarget(targetStats);
            }
        }
        else
        {
            if (hasStopped)
            {
                hasStopped = false;
            }
        }
    }

    private void AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("attack");
        stats.DealDamage(statsToDamage);
    }

    private void RotateToTarget()
    {
        //look at target
        transform.LookAt(target);

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void GetRefrences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<EnemyStats>();
        target = PlayerController.instance;
    }
}
