using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    /*
        Handle stats for Players and enemies
        Includes:
            * RPG Stats
            * damage and health

    */

    //Damage Types
    public enum AtkType
    {
        Magic,
        Range,
        Melee
    }

    //Player Stats
    //RPG
    int Strength;
    int Dexterity;
    int Intelligence;
    int Constitution;

    //Overall health
    float health;
    float maxhealth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                break;
            case AtkType.Melee:
                break;
            default:
                Debug.Log("STAT: Took damage of no type");
                break;
        }

        health -= dmg;
    }


    public void GenerateStats()
    {
        
    }

    public void AssignStats()
    {

    }



}
