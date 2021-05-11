using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Modifier :ScriptableObject
{
    //Attach script/load modifier.
    //attach to diff events. Load player, on update, and delegates for events, like attacks, etc.
    //Each script might need to access different things though, like stats manager or other. probably take the base char script.
        //really shoulda made that. might rework.
    public string ModName;
    public Sprite icon;

    public abstract void Attach(StatsManager inStats);

}
