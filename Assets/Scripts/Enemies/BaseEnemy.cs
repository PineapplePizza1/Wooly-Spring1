using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

//Functions like the Player Script, Handle base management for the enemies. Keep simpler than player.
    //NOTE: need to figure a way to configure attacks animations for enemies.
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private SceneInjector sceneject;
    #region Injection
    public Pooler _pool{get; private set;}
    public void Injection(InjectionDict ID)
    {
        _pool = ID.Inject<Pooler>(); 
    }
    #endregion
    public StatsManager myStats{get; private set;}

    

    //MELEE, probably remove/child for future implementations.
    public Transform MeleePoint;
    public float MeleeDist;

    //Add Target, get Private set;
    public Transform Target {get; private set;}
    public LayerMask _enemyMask;
    public NavMeshAgent _agent {get; private set;}

    //Add State Machine
    public AIStateMachine StateMachine;


    //Animation
    public Animator _anim{get; private set;}

    public Attack Prim{get; private set;}
    private EnemyLoadout _loadout;

    
    private void Awake() {
        myStats = GetComponent<StatsManager>();
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _loadout = GetComponent<EnemyLoadout>();
        StateMachine = GetComponent<AIStateMachine>();


        InitializeStateMachine(StateMachine);


        myStats.Death += EnemyDeath;

        //create attacks
        Prim = new Attack(this.gameObject);


        //sceneject.SceneJect += Injection;
        //sceneject.FixedSceneLoad += EnemyStart;

    }

    public void EnemyStart() {
        //load weapon.
        _loadout.StartEnemyLoadout();
        _loadout.LoadPrimary(Prim);
        
    }

//TEMP: basically, spawn, with new start based on Room Manager.
    public void AddInject(SceneInjector _in)
    {
        sceneject = _in;
        _pool = sceneject.Request<Pooler>(); 
        EnemyStart();
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

    public void Primary()
    {
        if (Prim ==null)
            _loadout.LoadPrimary(Prim);
        Prim.Atk(this.transform.rotation.eulerAngles, this.transform);  //Note: Posibly use direct input, vs Player rotation
    }

#region Attack Delegats
    //List Attack Delegates here.
    //Loadout Script attach here.
    
    public void PrimOnHit()
    {
        Prim.OnHit();
    }
    public void FootL()
    {

    }
    public void FootR()
    {

    }

#endregion

}
