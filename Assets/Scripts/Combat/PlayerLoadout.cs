using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//store, access, and *load* player loadout here.
//Load Items

//Note: Enemy combat will call scripts from their loadout; Loadout --> enemy loadout --> enemy combat (bespoke)
 
public class PlayerLoadout : Loadout
{
    //TEMP: Melee point, probably move to either combat or somethign else?
    public Transform MeleePoint;

    private Player PM;

    private Pooler pooler;
    private StatsManager pstats;
    public BaseWeapon primW;
    public BaseWeapon secoW;
    public BaseWeapon utilW;
    public BaseWeapon moveW;

   void Awake() {
       PM = GetComponent<Player>();

       
   }
   public void StartPlayerLoadout()
   {
       pstats = PM.playerstat;
        Debug.Log("Loadout: Prim Owner " + pstats.name);
        pooler = PM.pooler;
        Debug.Log("PL: Pooler " + pooler.GetInstanceID());
   }
    public void FirstLoad(Attack atk1, Attack atk2, Attack atk3, Attack atk4)
    {
    
        LoadPrimary(atk1);
        LoadSecondary(atk2);
        LoadUtility(atk3);
        LoadMovement(atk4);
    }
    //Augmentations: To be added.

    public void LoadPrimary(Attack loadtk)
    {
        BaseWeapon temp = Instantiate(primW);
        primW = temp;

        if (pstats == null)
            pstats = PM.playerstat; //redundant, probably see if there's an easy injectable fix?

        loadtk.dmgStats = pstats.GetHitStats(primW.WeaponDamage, primW.WeaponType); //change to return Hit.
        loadtk.Cooldown = primW.cooldown; //implement.

        //TEMP_DEBUG: Weapon Load Pool
        if(primW is BaseGun)
        {
            //Late check script
            if (pooler ==null)
                pooler = PM.pooler;

            BaseGun gun = primW as BaseGun;
            gun.FindAmmo(pooler);
        }
        else if(primW is BaseMagic)
        {
            //Late check script
            if (pooler ==null)
                pooler = PM.pooler;

            BaseMagic spell = primW as BaseMagic;
            spell.FindPool(pooler);
        }
        else if(primW is BaseMelee)
        {
            BaseMelee smack = primW as BaseMelee;
            smack.FindPoint(MeleePoint);
        }

        primW.LoadWeapon(loadtk);
        //Apply items here, or like, in the load function.
        
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
