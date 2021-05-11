using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New StatPoint", menuName = "Modifier/StatPoint")]
public class StatPoint : Modifier
{
    private StatsManager _modTarget;
    //stat struct?
    public StatsManager.RPStat TargetStat;

    //enum stat
    //stat increase? or I guess, should probably just be one.
    //Rework stats first.

    //Interact should just pass in event to player, I suppose.

    //Don't forget to clone for whatever reason, I guess :p. Probably need to make these a separate class, or something. Script Objs sadge.
    public void StatBoost()
    {
        _modTarget.AddStatPoint(TargetStat);
    }


    public override void Attach(StatsManager inStats)
    {
        _modTarget = inStats;
        //called on attach.
        StatBoost();
    }
}
