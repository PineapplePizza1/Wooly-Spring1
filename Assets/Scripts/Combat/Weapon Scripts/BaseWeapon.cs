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

    //Pass in Information
    //Vector3 direction; // Pass in direction from Player. Firing direction. sending direction to attack?

    //private Attack LoadedAtk; //Use this for loading/referecing attacks, and OnDisable

    public virtual void setPlayer(GameObject playa)
    {
        Player = playa;
    }



    public abstract void LoadWeapon(Attack atk);

    public abstract void unloadWeapon(Attack atk);
    
}
