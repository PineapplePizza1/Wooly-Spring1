using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
public StatsManager.AtkType DmgType;

public float atkDmg;
public event Action AtkStart;
public event Action<Vector3> AtkPerformed;
public event Action AtkEnd;
public event Action AtkCanceled;



    public void Atk(Vector3 Direction)
    {
        if (AtkStart!=null)
            AtkStart();
        //If animation starts
        if (AtkPerformed!=null)
            AtkPerformed(Direction);
        //If animation over
        if (AtkEnd!=null)
            AtkEnd();
            

        //ON animation cancel event
        if (AtkCanceled!=null)
            AtkCanceled();

    }
}
