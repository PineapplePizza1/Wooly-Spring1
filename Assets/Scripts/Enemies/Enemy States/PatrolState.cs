using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatrolState : BaseState
{
    private Vector3? _destination;
    private float stopDistance = 1f;
    private float turnSpeed = 1f;
    private readonly LayerMask _layerMask = LayerMask.NameToLayer("Walls");
    private float _rayDistance = 3.5f;
    private Quaternion _desiredRotation;
    private Vector3 _direction;
    private BaseEnemy _baseEnemy;


    public PatrolState(BaseEnemy _me) : base(_me.gameObject)
    {
        _baseEnemy = _me;
    }

    public Transform CheckforAggro()
    {
        return _baseEnemy.gameObject.transform;
    }

    public void FindRandomDestination()
    {
        
    }
    public override Type Tick()
    {
            //Debug
            //return typeof(PatrolState);

        var chaseTarget = CheckforAggro();

        if (chaseTarget != null)
        {
            _baseEnemy.SetTarget(chaseTarget);

            return typeof(ChaseState);

        }

        /*if (_destination.HasValue == false ||
        Vector3.Distance(a: transform.position, b: _destination.Value) <= stopDistance)
        {
            FindRandomDestination();

            return typeof(PatrolState);
        }

        //transform.rotation = Quaternion.Slerp(a: transform.rotation);
        */
        
        return typeof(PatrolState);
    }


}
