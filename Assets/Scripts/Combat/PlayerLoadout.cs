using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//store, access, and *load* player loadout here.
//Load Items
 
public class PlayerLoadout : Loadout
{

    private Player PM;
    private StatsManager pstats;
    public BaseWeapon primW;
    public BaseWeapon secoW;
    public BaseWeapon utilW;
    public BaseWeapon moveW;

   void Awake() {
       PM = GetComponent<Player>();

       
   }
   void Start() {
       pstats = PM.playerstat;
   }



    //Augmentations: To be added.

    public void LoadPrimary(Attack loadtk)
    {
        primW.LoadWeapon(loadtk);
        loadtk.dmgStats.Dmg = pstats.GetDamage(primW.WeaponDamage, primW.WeaponType);
        loadtk.Cooldown = primW.cooldown;
    }
    
    public void LoadSecondary(Attack loadtk)
    {
        secoW.LoadWeapon(loadtk);
    }
    public void LoadUtility(Attack loadtk)
    {
        utilW.LoadWeapon(loadtk);
    }
    public void LoadMovement(Attack loadtk)
    {
        moveW.LoadWeapon(loadtk);
    }

    //public void LoadAttack

    //public void UnloadAttack //called up top


    //Hold slots, load specific attacks.
        //might make general class or something to hold player vs enemy loadouts. 
        
    

}
