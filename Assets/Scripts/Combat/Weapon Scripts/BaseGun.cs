using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

//two ways to do this. Particle system, or projectiles. I vote particles/projectiles, depending on effect. having real physics bullets is interesting, but idk.
    //maybe we leave the cool projectiles to magic.

[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons/Gun")]
public class BaseGun : BaseWeapon
{
    public GameObject bullet; //Temp, may need to load
    public float bulletSpeed;
    public string bulletType;
    private Transform playerpos;
    public float spacing = 1f;
    public Vector3 rotater;

    //preset
    private void OnEnable() {
        WeaponType = StatsManager.AtkType.Range; //probably a better way to do this, but it'll work for now
    }
    
    public void Shoot(Vector3 direct, Hit dmgStat) 
    {
        
        /*
        Transform firePos = playerpos.transform; // UPDATE LATER

        Debug.Log("Gun Fire"); //try to switch to player rotation. Also, remove the Y bend.
        Quaternion rotato = Quaternion.Euler(rotater); //Quaternion.LookRotation(playerpos.rotation.eulerAngles, Vector3.up);
        rotato = Quaternion.AngleAxis(playerpos.rotation.eulerAngles.y, Vector3.up) * rotato;
        //GameObject bullet = poolDict.SpawnFromPool(bulletType, firePos.position, rotato);
        Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
        direct.y = 0;
        bulletrigid.AddForce(direct * bulletSpeed, ForceMode.VelocityChange);
        */

        Debug.Log("BaseGun: Fired Gun! Dmg:" + dmgStat.Dmg);
        
    }

    public override void LoadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed += Shoot;
    }

    public override void unloadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed -= Shoot;
    }
}
