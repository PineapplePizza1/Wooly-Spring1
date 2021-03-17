using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

[CreateAssetMenu(fileName = "New Melee", menuName = "Weapons")]
public class BaseMelee : BaseWeapon
{
    //preset
    private void OnEnable() {
        WeaponType = StatsManager.AtkType.Melee; //probably a better way to do this, but it'll work for now
    }

    void Swing(Vector3 direct, Hit dmg)
    {

    }


    public override void LoadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed += Swing;
    }

    public override void unloadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed -= Swing;
    }

}
