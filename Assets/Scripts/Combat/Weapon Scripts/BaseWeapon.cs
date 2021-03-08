using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z
public abstract class BaseWeapon : ScriptableObject
{
    public string wepName;
    public float cooldown;
    //Add ammo count later.
    protected GameObject Player;

    public virtual void setPlayer(GameObject playa)
    {
        Player = playa;
    }

    public abstract void Attack(Vector3 Direction, Transform firePos);
    
}
