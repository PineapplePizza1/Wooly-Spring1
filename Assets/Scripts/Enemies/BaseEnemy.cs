using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Functions like the Player Script, Handle base management for the enemies. Keep simpler than player.
    //NOTE: need to figure a way to configure attacks animations for enemies.
public class BaseEnemy : MonoBehaviour
{
    private StatsManager myStats;
    public NavMeshAgent _agent;

    //Debug Player
    public LayerMask _enemyMask;

    private void Awake() {
        myStats = GetComponent<StatsManager>();

        myStats.Death += EnemyDeath;

    }

    private void EnemyDeath() //Enemy Defeat method
    {
        this.gameObject.SetActive(false);
    }


    //Add Team? yes
    //Add Visuals/Laser

    //Add Target, get Private set;
    public Transform Target {get; private set;}

    //Add State Machine
    public AIStateMachine StateMachine => GetComponent<AIStateMachine>();


//Fire
//Set Target (Public method)
public void SetTarget(Transform target)
{
    Target = target;
}

    //Debug Follow

    private void Update() {

        Collider[] hitEnemies = Physics.OverlapSphere(this.transform.position, 50f, _enemyMask);
        if (hitEnemies != null)
        {
            Target = hitEnemies[0].transform;
        }

        if (Target != null)
        {
            _agent.SetDestination(Target.position);
        }
    }


}
