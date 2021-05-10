using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class PatrolState : BaseState
{

    private BaseEnemy _baseEnemy;

    public PatrolState(BaseEnemy _me) : base(_me.gameObject)
    {
        _baseEnemy = _me;
    }

    public Transform CheckforAggro()
    {
       Collider[] hitEnemies = Physics.OverlapSphere(_baseEnemy.transform.position, 10f, _baseEnemy._enemyMask);
        if (hitEnemies?.Length > 0)
        {
            return hitEnemies[0].transform;
        }
        else{
            return null;
        }
        
    }

    public override Type Tick()
    {
            //Debug
            //return typeof(PatrolState);
        _baseEnemy._anim.SetBool("Moving", false);

        Transform chaseTarget = CheckforAggro();

        if (chaseTarget != null)
        {
            _baseEnemy.SetTarget(chaseTarget.transform);
            
            return typeof(ChaseState);
        }
        else{return typeof(PatrolState);}

        
    }


}
