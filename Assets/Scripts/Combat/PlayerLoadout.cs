using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//store, access, and *load* player loadout here.
//Load Items
 
public class PlayerLoadout : Loadout
{

    public BaseWeapon primW;
    public BaseWeapon secoW;
    public BaseWeapon utilW;
    public BaseWeapon moveW;

   
    //Augmentations: To be added.

    public void LoadPrimary(Attack loadtk)
    {
        primW.LoadWeapon(loadtk);
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
