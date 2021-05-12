using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[System.Serializable]
public class Attack
{
    //Class to hold information about a player's attack: Attack, Anim, etc.

    //Add actual attack information into this; Damage type, Damage, etc. 
        //Maybe a Hit subclass, for the Hitreg info, and process via DMG type.
    //maybe subclasses for attack type, like melee, ranged, and magic, so there are charges, etc.
            //real tip, needed subclass for swing, bullet, and spell; at least for the actual items so they can be changed. "Projectile", if you will.
        //Magic attack needs 3 levels, so we'll have to adjust.

    //First step, redo so weapons have attacks, and you load them; and test IOC so that it actually hits. Debug Actions.

    //base attack, include polymorphs to add other types of attacks. maybe make virtual?***

    //since it's supposed to be separate from the base, include the actual HitReg info in this attack!
        //So Weapon sends one detail, then it can get altered by items!
        //#return an attack and run it, as weapon event trigger, vs just actually running it. ATTACK PROCESSING
        
public Hit dmgStats;

public InputAction ActionSlot;
public float Cooldown; //in Seconds


public event Action AtkStart;
public event Action<Vector3, Transform, Hit> AtkPerformed;
public event Action AtkEnd;
public event Action<Vector3, Transform, Hit, InputAction> AtkUpdate;
public event Action AtkCanceled;
public event Action<Hit> HitEvent; //used to actually send in hitcode, triggered by playercombat.

public Attack(GameObject owner) //Dunno if this is bestpractices yet, might just want to return a hit, but if It's gonna be there anyway, why not?
{
    dmgStats = new Hit(); 
    //NOTE: Potentially, load player transform and Input Action in here, so we don't need so many inputs.
    //But that's for next time, this works for now, we'll just have to have some intense refactors later down the line.
}

    public void Atk(Vector3 Direction, Transform playerpos)
    {

        if (AtkStart!=null)
            AtkStart();
        //If animation starts
        if (AtkPerformed!=null)
            AtkPerformed(Direction, playerpos, dmgStats);
        //If animation over
        if (AtkEnd!=null)
            AtkEnd();
            

        //ON animation cancel event
        if (AtkCanceled!=null)
            AtkCanceled();

    }

    public void OnUpdate(Vector3 Direction, Transform playerpos)
    {
        if (AtkUpdate!=null)
            AtkUpdate(Direction, playerpos, dmgStats, ActionSlot);
    }

    public void OnHit()
    {
        if (HitEvent!=null)
            HitEvent(dmgStats);
    }
}

public class Hit //call damage data?
{
    public float Dmg;
    public StatsManager.AtkType atkType;
    //public List<StatusEffects> FX

    public GameObject Owner;
    //Transfer hit and effects to statshandler to process.

    public List<StatusEffects> fx;
}