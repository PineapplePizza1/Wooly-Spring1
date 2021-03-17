using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons")]
public class BaseGun : BaseWeapon
{
    public GameObject bullet; //Temp, may need to load
    public float bulletSpeed;
    public string bulletType;
    private Transform playerpos;
    public float spacing = 1f;
    public Vector3 rotater;

    
    public void Shoot(Vector3 direct) 
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
        Debug.Log("BaseGun: Fired Gun!");
        
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
