using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatsManager : MonoBehaviour
{
    /*
        Handle stats for Players and enemies
        Includes:
            * RPG Stats
            * damage and health

    */

    //Damage Types
    public enum AtkType //MOVE TO COMBAT OR SOMETHING
    {
        Magic,
        Range,
        Melee,
        Base
    }

    //Player Stats
    //RPG
    public int Strength { get; private set;}
    public int Dexterity { get; private set;}
    public int Intelligence { get; private set;}
    public int Constitution { get; private set;}

    //Overall health
    public float health { get; private set;}
    public float maxhealth { get; private set;}

    //LevelStats
    public int XP { get; private set;}
    public int lvl { get; private set;}

    //NOTE: need something to add status effects; will have to make a class probs, and more events? careful of event abuse.

    void Start()
    {
        setHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Set Stats Functions
    private void setHealth()
    {
        //Base 80;
        maxhealth = 80f;
        health = maxhealth;

        maxhealth += 5f * Constitution;

        UpdateHealth();
    }
    public void LevelUp()
    {
        UpdateStats();
    }
    #endregion



    public float Attack(float wepDmg, AtkType wepType)
    {
        float atkDMG = 0;
        switch (wepType)
        {
            case AtkType.Magic:
                atkDMG= Intelligence * wepDmg;
                return atkDMG;
            case AtkType.Range:
                atkDMG= Dexterity * wepDmg;
                return atkDMG;
            case AtkType.Melee:
                atkDMG= Strength * wepDmg;
                return atkDMG;
            default:
                Debug.Log("STAT: Attack of no type");
                return atkDMG;
        }
    }

    public void Damage(float dmg, AtkType atkType)
    {
        
        switch (atkType)
        {
            case AtkType.Magic:
                dmg = dmg / Intelligence;
                break;
            case AtkType.Range:
                dmg = dmg / Dexterity;
                break;
            case AtkType.Melee:
                dmg = dmg / Strength;
                break;
            default:
                Debug.Log("STAT: Took damage of no type");
                break;
        }

        health -= dmg;
        UpdateHealth();
        if (health <= 0)
            Died();
    }

    #region Update Actions
    //Subscribe to  get updates.
    public event Action HealthUpdate;
    public event Action StatUpdate;
    public event Action Death;

    private void Died()
    {
        if (Death!=null)
            Death();
    }

    private void UpdateHealth()
    {
        if (HealthUpdate != null)
            HealthUpdate();
    }
    private void UpdateStats()
    {
        if (StatUpdate != null)
            StatUpdate();
    }

    #endregion

/*
    public void GenerateStats()
    {
        
    }

    public void AssignStats()
    {

    }

*/

}
