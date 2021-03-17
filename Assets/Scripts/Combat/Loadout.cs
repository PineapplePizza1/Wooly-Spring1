using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base monobehavior for loadouts
//*Loads* Attacks,
    //probably gonna need to generate to create.
public class Loadout : MonoBehaviour
{

    //generate an Attack to add to a spot, calc using augments and etc. 
    //Load attacks, out of equipped weps, augments, and perks.
    public virtual Attack CreateAttack(Attack loadingTK)
    {
        return null;
    }
    public static void EquipWeapon(Attack loadtk, BaseWeapon wepy)
    {
        wepy.LoadWeapon(loadtk);
    }

    public static void UnequipWeapon(Attack loadtk, BaseWeapon wepy)
    {
        wepy.unloadWeapon(loadtk);
    }
}
