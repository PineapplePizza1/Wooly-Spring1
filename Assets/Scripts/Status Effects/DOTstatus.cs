using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DOT Status", menuName = "StatusEffect/DOT effect")]
public class DOTstatus : StatusEffects
{
    public float damageTick;
    public float dmgInterval;
    private float dmgCounter;
    
    public override void Tick(StatsManager stats)
    {
        Debug.Log("DOT: FXmanage: " + fxManage.GetInstanceID());
        if(dmgCounter >= dmgInterval)
        {
            fxManage.Rawdamage(damageTick);
            dmgCounter = 0;
        }
        dmgCounter += Time.deltaTime;

        base.Tick(stats);
    }

    public override void AddEffect(StatsManager stats)
    {
        base.AddEffect(stats);
        dmgCounter = 0;
    }
    public override void RemoveEffect(StatsManager stats)
    {
        base.RemoveEffect(stats);
    }
}
