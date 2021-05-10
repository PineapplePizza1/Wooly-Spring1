using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    private BaseEnemy _baseEnemy;

    private bool _attacking;

    public ChaseState(BaseEnemy _me) : base(_me.gameObject)
    {
        _baseEnemy = _me;
        _attacking = false;
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

    public Transform CheckAttack()
    {
        //_baseEnemy._agent.remainingDistance <= _baseEnemy._agent.stoppingDistance;
        Collider[] hitEnemies = Physics.OverlapSphere(_baseEnemy.MeleePoint.position, _baseEnemy.MeleeDist, _baseEnemy._enemyMask);
        if (hitEnemies?.Length > 0)
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
        //Debug.Log("AIChase: Done Atk: " + _baseEnemy._anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"));

        if(!_attacking)
        {
            Transform chaseTarget = CheckforAggro();

            if (chaseTarget != null)
            {
                _baseEnemy._agent.SetDestination(_baseEnemy.Target.position);

                //Debug.Log("AIChase: magnitude: " + _baseEnemy._agent.velocity.magnitude/_baseEnemy._agent.speed);
                    _baseEnemy._anim.SetFloat("Speed", _baseEnemy._agent.velocity.magnitude/_baseEnemy._agent.speed);
                    _baseEnemy._anim.SetFloat("Animation Speed", _baseEnemy._agent.velocity.magnitude/_baseEnemy._agent.speed);
                    _baseEnemy._anim.SetBool("Moving", true);

                //if within distance, attack
                if (CheckAttack()!=null)
                {
                    
                    //Attack animation.
                    _baseEnemy._anim.SetTrigger("AtkTrigger");
                    _baseEnemy._anim.SetBool("Moving", false);
                    _baseEnemy._anim.SetFloat("Animation Speed", 1f); //Attack Speed
                    _attacking =true;
                    _baseEnemy._agent.isStopped = true;

            
                }

                return typeof(ChaseState);
            }else{
                return typeof(PatrolState);
            }
        }
        else//Attacking
        {
            Debug.Log("AIChase: Attacking");
            if((_baseEnemy._anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))) //if it isn't attacking anymore,
            {
                
            }
            else{
                //start moving again.
                _baseEnemy._anim.SetBool("Moving", true);
                _attacking = false;
                _baseEnemy._agent.isStopped = false;
                return typeof(PatrolState);
            }
            


            return typeof(ChaseState);
        }
    }
}
