using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMagicBullet : MonoBehaviour, MagicProjectile
{
    private Hit hitinfo;

    public float FlySpeed;
    public float ExplosionRadius;
    
    private Vector3 direction;

    private Rigidbody myBody;
    public void SetMagic(Hit dmgstats, Vector3 direct)
    {
        hitinfo = dmgstats;
        //get direction for force.
        direction = direct;
    }

    //start behaviour
    private void Start() {
        myBody = GetComponent<Rigidbody>();

        //myBody.AddForce()
    }

    
}
public interface MagicProjectile
{
    //Create logic to attack,
    //Hold Hit, and a create/set method.
    void SetMagic(Hit dmgstats, Vector3 Direct);
}

