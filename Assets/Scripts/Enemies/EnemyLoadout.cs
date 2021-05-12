﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoadout : Loadout
{
    private Pooler pooler;
    //TEMP: Melee point, probably move to either combat or somethign else?
    private Transform MeleePoint;

    private BaseEnemy _me;

    private StatsManager _stats;
    public BaseWeapon primW;

   void Awake() {
       _me = GetComponent<BaseEnemy>();
       
   }
   public void StartEnemyLoadout()
   {
       _stats = _me.myStats;
        pooler = _me._pool;
        MeleePoint = _me.MeleePoint;
   }
    public void FirstLoad(Attack atk1)
    {
    
        LoadPrimary(atk1);
        
    }
    //Augmentations: To be added.

    public void LoadPrimary(Attack loadtk)
    {
        BaseWeapon temp = Instantiate(primW);
        primW = temp;
        
        primW.LoadWeapon(loadtk);

        if (_stats == null)
            _stats = _me.myStats; //redundant, probably see if there's an easy injectable fix?

        loadtk.dmgStats = _stats.GetHitStats(primW.WeaponDamage, primW.WeaponType);
        loadtk.Cooldown = primW.cooldown;

        //TEMP_DEBUG: Weapon Load Pool
        if(primW is BaseGun)
        {
            //Late check script
            if (pooler ==null)
                pooler = _me._pool;

            BaseGun gun = primW as BaseGun;
            gun.FindAmmo(pooler);
        }
        else if(primW is BaseMagic)
        {
            //Late check script
            if (pooler ==null)
                pooler = _me._pool;

            BaseMagic spell = primW as BaseMagic;
            spell.FindPool(pooler);
        }
        else if(primW is BaseMelee)
        {
            BaseMelee smack = primW as BaseMelee;
            smack.FindPoint(MeleePoint);
        }

        //Apply items here, or like, in the load function.
        
    }
}
