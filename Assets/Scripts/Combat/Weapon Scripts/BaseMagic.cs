﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

//spawn damaging prefab.

[CreateAssetMenu(fileName = "New Magic", menuName = "Weapons/Magic")]
public class BaseMagic : BaseWeapon
{

    //preset
    private void OnEnable() {
        WeaponType = StatsManager.AtkType.Magic; //probably a better way to do this, but it'll work for now
    }

    void Cast(Vector3 direct, Transform playerpos, Hit dmg)
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
