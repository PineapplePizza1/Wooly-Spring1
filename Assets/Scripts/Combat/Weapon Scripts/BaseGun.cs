using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

//two ways to do this. Particle system, or projectiles. I vote particles/projectiles, depending on effect. having real physics bullets is interesting, but idk.
    //maybe we leave the cool projectiles to magic.

//May need to change this into actual objects and use that to supplement. Can still use ScriptObj for gunstats, but base functionality probably needs to be on the actual object.
//SO becomes container for data, since yknow, inherited monobehaviours.

[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons/Gun")]
public class BaseGun : BaseWeapon
{
    //Temp, may need to load
    private Pooler AmmoPool;
    //public GameObject bullet; 
    

    public string bulletType;

    public float bulletSpeed;

    public Vector3 rotater;
    

    //preset
    private void OnEnable() {
        WeaponType = StatsManager.AtkType.Range; //probably a better way to do this, but it'll work for now
    }

    public void FindAmmo(Pooler inPool)
    {
        //TEMP: use this to attach ammo pool.   
        AmmoPool = inPool;
    }
    

    public void Shoot(Vector3 direct, Transform playerpos, Hit dmgStat) 
    {
        

        

        //Add additional rotation 
        Quaternion rotato = Quaternion.Euler(rotater); //Quaternion.LookRotation(playerpos.rotation.eulerAngles, Vector3.up);
        rotato = Quaternion.AngleAxis(playerpos.rotation.eulerAngles.y, Vector3.up) * rotato; //NOTE: Attach rotater to actual ammo
        
         
        GameObject bullet = AmmoPool.SpawnFromPool(bulletType, playerpos.position, rotato);  //NOTE: could pass in a specific fire position at another point.
        Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
        BaseBullet bulletScr = bullet.GetComponent<BaseBullet>();
        direct.y = 0;
        
        bulletrigid.AddForce(direct * bulletSpeed, ForceMode.VelocityChange); //try to switch to player's model rotation.= as direction
        bulletScr.SetBullet(enemies, dmgStat, playerpos.gameObject); //Possibly find a better player reference?
    
        
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
