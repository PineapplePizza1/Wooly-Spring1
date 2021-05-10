using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

//Functions like the Player Script, Handle base management for the enemies. Keep simpler than player.
    //NOTE: need to figure a way to configure attacks animations for enemies.
public class BaseEnemy : MonoBehaviour
{
    private StatsManager myStats;

    

    //Add Target, get Private set;
    public Transform Target {get; private set;}
    public LayerMask _enemyMask;
    public NavMeshAgent _agent {get; private set;}

    //Add State Machine
    public AIStateMachine StateMachine;


    //Animation
    public Animator _anim;

    
    private void Awake() {
        myStats = GetComponent<StatsManager>();
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        StateMachine = GetComponent<AIStateMachine>();


        InitializeStateMachine(StateMachine);


        myStats.Death += EnemyDeath;

    }

    private void EnemyDeath() //Enemy Defeat method
    {
        this.gameObject.SetActive(false);
    }

    private void InitializeStateMachine(AIStateMachine _sm)
    {
        var _states = new Dictionary<Type, BaseState>()
        {
            {typeof(PatrolState), new PatrolState(_me: this)},
            {typeof(ChaseState), new ChaseState(_me: this)}
        };

        _sm.SetStates(_states);

    }


    //Fire
    //Set Target (Public method)
    public void SetTarget(Transform target)
    {
        Target = target;
    }

    //If target in range, go to Alert? or just Chase.
    //during chase, if still target, go after and attack. In attack, stand still and do anim, then go back to chasing.
    //If player out of range, stop chasing.
    //das it.

    //Ranged, if target in a *larger* range than player, same thing, but pick a line of sight from player
    //then, stand and attack, and then find new spot and move.

    //Magic, similar to ranged, but likely, just take time to cast. but TBH, dunno if I'll get time for ranged.

#region Attack Delegats
    //List Attack Delegates here.
    //Loadout Script attach here.

#endregion

}
