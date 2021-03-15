using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

[CreateAssetMenu(fileName = "New Melee", menuName = "Weapons")]
public class BaseMelee : BaseWeapon
{
    public new void setPlayer(GameObject playa)
    {
        base.setPlayer(playa);
        //playerpos = playa.transform;
    }

    void Swing(Vector3 direct)
    {

    }


    public override void LoadWeapon()
    {
        base.LoadWeapon();
        Atk.AtkPerformed += Swing;
    }

    public override void unloadWeapon()
    {
        Atk.AtkPerformed -= Swing;
    }

}
