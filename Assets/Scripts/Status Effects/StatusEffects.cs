using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class StatusEffects : ScriptableObject
{

    public string EffectName;
    public Sprite icon;
    public float Duration;

    protected StatsManager fxManage;

    
    //Include:
        //Icon
        //Add condition to stats manager
        //Type listed in StatsManager?/loadall stats? or have em all be independent?
        //Conditions/damage conditions to add?
            //Event in Stats manager, trigger stats, list the trigger here.
            //Method to apply for x amt of time.


    //onbegineffect
    //Duringeffect
    //effect (Run the Coroutine, or Timer Action.)
    //OnUpdate? Maybe too much.
    //removeeffect

//replace with stats manager.




    public virtual void Tick(StatsManager stats) //Always reimplement this, after child implementation.
    {
        Duration -= Time.deltaTime;
        if (Duration <= 0)
            {
                RemoveEffect(fxManage);
            }
    }


    public virtual void AddEffect(StatsManager stats)
    {
        fxManage = stats;
        //For non-tick status effects, Attach whatever methods you need, but remember to remove. //temp stats, how?
        //call damage, and affect speed in delegate methods. but make sure you call damage every attack now. affect x delegates.
    }
    public virtual void RemoveEffect(StatsManager stats)
    {
        fxManage.RemoveEffect(this);
        fxManage = null;
    }

    public void AddDuration(float inTime)
    {
        Duration += inTime;
    }

    
}
