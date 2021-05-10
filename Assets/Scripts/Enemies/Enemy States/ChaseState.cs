using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    private BaseEnemy _baseEnemy;

    public ChaseState(BaseEnemy _me) : base(_me.gameObject)
    {
        _baseEnemy = _me;
    }
    public Transform CheckforAggro()
    {
       Collider[] hitEnemies = Physics.OverlapSphere(_baseEnemy.transform.position, 50f, _baseEnemy._enemyMask);
        if (hitEnemies != null)
        {
            return hitEnemies[0].transform;
        }
        else{
            return null;
        }
        
    }

    // Update is called once per frame
    public override Type Tick()
    {
        Transform chaseTarget = CheckforAggro();

        if (chaseTarget != null)
        {
            _baseEnemy._agent.SetDestination(_baseEnemy.Target.position);

            //if within distance, attack
            if (_baseEnemy._agent.remainingDistance <= 10f)
            {
                //Attack animation.
            }

            return typeof(ChaseState);
        }else{
            return typeof(PatrolState);
        }
    }
}
