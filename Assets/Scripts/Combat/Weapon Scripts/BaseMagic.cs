using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//LastUpdate: 3/8/21, D-Lynn Z

//spawn damaging prefab.

[CreateAssetMenu(fileName = "New Magic", menuName = "Weapons/Magic")]
public class BaseMagic : BaseWeapon
{   
    private float chargeCounter = 0f;
    public List<MagicChargePair> ChargeList;

    private Pooler pooler;

    //Note: add additional animations after the fact.

    [System.Serializable]
    public struct MagicChargePair
    {
        public float ChargeLvl;
        public string prefabType;
    }

    public Vector3 rotater; //NOTE: dunno how this'll work with magic, but oh welllllll; may need to do it with each pair.
    
    //Also needs pools, but we'll make do for now. 
    //Use this to code enemies too. 3/27/21 Midterm pres
        //Then, Items and Status effects, and at least some level randomness or generation (player random), if not full gen.

    //preset
    private void OnEnable() {
        WeaponType = StatsManager.AtkType.Magic; //probably a better way to do this, but it'll work for now
    }
    public void FindPool(Pooler inPool)
    {
        //TEMP: use this to attach ammo pool.   
        pooler = inPool;
        Debug.Log("BMag: Magic Pool " + pooler.GetInstanceID());
    }

    void Cast(Vector3 direct, Transform playerpos, Hit dmg)
    {
        //bool isJumpHeld = (input.Gameplay.PlayerRun.activeControl != null) ? true : false;
        //use this to check if the Cast is held, but like, it's an action, so I guess it needs an update? ughhhhh
    }

    void Casting(Vector3 direct, Transform playerpos, Hit dmg, InputAction act)
    {
        bool isattackheld = (act.activeControl != null) ? true : false;
        if (isattackheld)
        {
            chargeCounter += Time.deltaTime;
            //play anim, tho player combat already does that.
            Debug.Log("BMag: Casting...");
        }
        else
        {
            if (chargeCounter >0f)
            {
                string loadspell = null;
                for(int i = 0; i<ChargeList.Count; i++) //(MagicChargePair choggy in ChargeList) //could simplify so it's just one, but these should be short anyways.
                {
                    if(chargeCounter >= ChargeList[i].ChargeLvl) 
                    {
                       loadspell = ChargeList[i].prefabType;
                    }
                }
                
                if (loadspell != null)
                {
                    //Cast Item!
                    //Add additional rotation 
                    Quaternion rotato = Quaternion.Euler(rotater); //Quaternion.LookRotation(playerpos.rotation.eulerAngles, Vector3.up);
                    rotato = Quaternion.AngleAxis(playerpos.rotation.eulerAngles.y, Vector3.up) * rotato; //NOTE: Attach rotater to actual ammo
                    
                    
                    GameObject bullet = pooler.SpawnFromPool(loadspell, playerpos.position, rotato);  //NOTE: could pass in a specific fire position at another point.
                    //Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
                    //BaseBullet bulletScr = bullet.GetComponent<BaseBullet>();
                    direct.y = 0;
                    
                    //Setup Magic Script, with directions and stuff.


                    Debug.Log("BMag: Casted!");

                }
            }

            chargeCounter = 0f;
        }
    }
    
    public override void LoadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed += Cast;
        loadTK.AtkUpdate +=Casting;
    }

    public override void unloadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed -= Cast;
        loadTK.AtkUpdate -=Casting;
    }
}
