using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosionRecall : MonoBehaviour
{
    public GameObject BulletOwner;
    public void OnParticleSystemStopped()
    {
        Debug.Log("BaseBull: Exploded :pppp");
        BulletOwner.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
