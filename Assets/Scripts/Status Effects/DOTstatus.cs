using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DOT Status", menuName = "StatusEffect/DOT effect")]
public class DOTstatus : StatusEffects
{
    public float damageTick;
    public override void Tick(StatsManager stats)
    {
        fxManage.Rawdamage(damageTick);
        base.Tick(stats);
    }

    public override void AddEffect(StatsManager stats)
    {
        base.AddEffect(stats);
    }
    public override void RemoveEffect(StatsManager stats)
    {
        base.RemoveEffect(stats);
    }
}
