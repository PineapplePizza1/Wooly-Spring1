using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

//Base class, that you can use to create additional weapons down the line; Simply use the loadweapon to attach the actual script information to attach methods to
//the loadTK Attack's delegates (and unload to detach.)
    //Loadout will handle attaching augments based on the type of weapons.
public abstract class BaseWeapon : ScriptableObject
{
    public string wepName;
    public float cooldown;
    public float WeaponDamage;
    public StatsManager.AtkType WeaponType;

    public abstract void LoadWeapon(Attack loadTK);

    public abstract void unloadWeapon(Attack loadTK);
    
}
