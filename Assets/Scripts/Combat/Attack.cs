using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : ScriptableObject
{
public StatsManager.AtkType DmgType;
public event Action AtkStart;
public event Action<Vector3> AtkPerformed;
public event Action AtkEnd;
public event Action AtkCanceled;



    public void Atk(Vector3 Direction)
    {
        if (AtkStart!=null)
            AtkStart();
        //If animation starts
        if (AtkPerformed!=null)
            AtkPerformed(Direction);
        //If animation over
        if (AtkEnd!=null)
            AtkEnd();
            

        //ON animation cancel event
        if (AtkCanceled!=null)
            AtkCanceled();

    }
}
