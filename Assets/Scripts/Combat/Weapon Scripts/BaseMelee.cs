using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z

//Likely, the method for this will be to trigger a hitbox around an animation event, so animations come soon.
//ADD ANIMATOR NEXT (3/17)

[CreateAssetMenu(fileName = "New Melee", menuName = "Weapons/Melee")]
public class BaseMelee : BaseWeapon
{
    //preset
    private void OnEnable() {
        WeaponType = StatsManager.AtkType.Melee; //probably a better way to do this, but it'll work for now
    }

    void Swing(Vector3 direct, Hit dmg)
    {
            //Play sound or something
            Debug.Log("BaseMelee: Swang!");
    }
    void Cut(Hit dmg)
    {

        Collider[] hitEnemies = Physics.OverlapSphere(dmg.Owner.transform.position, 10f, enemies); //position either from dmg, or from Swing attack up front.

        if (hitEnemies != null)
        {
            foreach(Collider enemy in hitEnemies)
            {
                Debug.Log("BaseMelee: I Cut " + enemy.gameObject.name + "!");
                StatsManager hitStats = enemy.GetComponent<StatsManager>();
                hitStats.TakeAttack(dmg);
            }
        }

    }


    public override void LoadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed += Swing;
        loadTK.HitEvent += Cut;
    }

    public override void unloadWeapon(Attack loadTK)
    {
        loadTK.AtkPerformed -= Swing;
        loadTK.HitEvent -= Cut;
    }

}
