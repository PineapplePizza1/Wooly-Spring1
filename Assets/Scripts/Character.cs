using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    //Potential Base connector for all scripts for a character.
    
    //Stats manager
    //movement.
    //combat
    //death.
    //Model.
    // or, like, just attach it all to stats manager

#region Character Action Delegates
    public event Action onSpawn;
    public event Action onDeath;
    public event Action onAttack;
    public event Action onUpdate;
    public event Action onMove;
    public event Action onJump;
    public event Action onHeal;

#endregion

public StatsManager _stats;
    



}
