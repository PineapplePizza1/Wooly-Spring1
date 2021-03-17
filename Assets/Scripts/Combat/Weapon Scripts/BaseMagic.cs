using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

[CreateAssetMenu(fileName = "New Magic", menuName = "Weapons")]
public class BaseMagic : BaseWeapon
{

    void Cast(Vector3 direct)
    {

    }
    
    public override void LoadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed += Cast;
    }

    public override void unloadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed -= Cast;
    }
}
