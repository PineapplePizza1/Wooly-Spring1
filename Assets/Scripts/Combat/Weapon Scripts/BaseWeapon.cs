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

    public Attack Atk;

    //Pass in Information
    //Vector3 direction; // Pass in direction from Player. Firing direction. sending direction to attack?

    //private Attack LoadedAtk; //Use this for loading/referecing attacks, and OnDisable


    public virtual void setPlayer(GameObject playa)
    {
        Player = playa;
    }

    //Set method for main attack, PlayerCombat will then call your attack, your weapon itself will handle cooldown logic. I think?
        //If need, can always inherit from the Baseweapon details.

    public virtual void LoadWeapon()
    {
        Atk = new Attack();

    }

    public abstract void unloadWeapon();

    public virtual void Attack(Vector3 direct)
    {
        Atk.Atk(direct);
    }
    
}
