using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

[CreateAssetMenu(fileName = "New Magic", menuName = "Weapons")]
public class BaseMagic : BaseWeapon
{
    public new void setPlayer(GameObject playa)
    {
        base.setPlayer(playa);
        //playerpos = playa.transform;
    }

    
    public override void Attack(Vector3 direct, Transform firePos) //try to switch to player rotation. Also, remove the Y bend.
    {
    }
}
