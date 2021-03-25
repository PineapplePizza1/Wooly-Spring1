using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour, IPooledObj
{
    private LayerMask enemies;
    private Hit dmg;
    private GameObject owner;
    public void OnObjectSpawn()
    {

    }
    public void SetBullet(LayerMask inmies, Hit inDmg, GameObject owna)
    {
        enemies = inmies;
        dmg = inDmg;
        owner = owna;
    }
    private void OnTriggerEnter(Collider other) {

    
        if (other != null)
        {
            
            if (other.gameObject != owner)
            {
                if( ((1<<other.gameObject.layer) & enemies) != 0) 
                {
                
                    Debug.Log("BaseBullet: I hit " + other.gameObject.name + "!");
                    StatsManager hitStats = other.GetComponent<StatsManager>();
                    if(hitStats != null) hitStats.TakeAttack(dmg);
                    else Debug.Log("BaseBullet: Tried to hurt nobody :(");
                }
                this.gameObject.SetActive(false);
            }
        }

        
        
    }

}
