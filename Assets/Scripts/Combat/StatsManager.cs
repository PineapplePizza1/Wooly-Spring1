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
    //public int BaseDamage {get; private set;}
    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public int Constitution;

    //Overall health
    public float health { get; private set;}
    public float maxHealth { get; private set;}

    //LevelStats
    public int XP { get; private set;}
    public int lvl;

    //NOTE: need something to add status effects; will have to make a class probs, and more events? careful of event abuse.

    void Start()
    {
        setHealth();
        //Debug
        //BaseDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Set Stats Functions
    private void setHealth()
    {
        //Base 80;
        maxHealth = 80f;
        health = maxHealth;

        maxHealth += 5f * Constitution;

        UpdateHealth();
    }
    public void LevelUp()
    {
        UpdateStats();
    }
    #endregion



    public float GetDamage(float wepDmg, AtkType wepType) //change to work with playercombat and weapons. Base Damage.
    {
        float atkDMG = 0;
        switch (wepType)
        {
            case AtkType.Magic:
                atkDMG= wepDmg + (Intelligence * lvl); 
                return atkDMG;
            case AtkType.Range:
                atkDMG= wepDmg + (Dexterity * lvl);
                return atkDMG;
            case AtkType.Melee:
                atkDMG= wepDmg + (Strength * lvl);
                return atkDMG;
            default:
                Debug.Log("STAT: Attack of no type");
                return atkDMG;
        }
    }

    public void TakeAttack(Hit hit)
    {
        Damaged(hit);
    }
    private void Damaged(Hit hit) //takes hit
    {
        float dmg = hit.Dmg;
        switch (hit.atkType)
        {
            case AtkType.Magic:
                dmg = dmg - (Intelligence * lvl);
                break;
            case AtkType.Range:
                dmg = dmg - (Dexterity * lvl);
                break;
            case AtkType.Melee:
                dmg = dmg - (Strength * lvl);
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
