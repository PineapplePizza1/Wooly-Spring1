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


        Notes/Todo:
        - Add status effect events,
            Update and Timer, and possibly Hud/bar update (diff for player vs enemy tho, so guess that's what up.)
    */

    //Damage Types
    public enum AtkType //MOVE TO COMBAT OR SOMETHING
    {
        Magic,
        Range,
        Melee,
        Base
    }

    

    [System.Serializable]
    public struct RPStat
    {
        public string StatType;
        public int Amt;
    }

    //Player Stats
    //RPG
    //public int BaseDamage {get; private set;}

    #region Base Stats
    public RPStat Strength;
    public RPStat Dexterity;
    public RPStat Intelligence;
    public RPStat Constitution;

    //implement dictionary in future.

    #endregion 
    public List<RPStat> _otherStats;

    //Luck
    //Charisma?

    //Overall health
    public float health;
    public float maxHealth;

    //LevelStats
    public int XP;
    public int lvl;

    //NOTE: need something to add status effects; will have to make a class probs, and more events? careful of event abuse.

    //augments and perks; applicable to all stats.
    public List<Modifier> modifiers;

    //public List<Twists> twists;

#region Character Action Delegates
    public event Action<StatsManager> onSpawn;
    public void callSpawn()
    {
        if (onSpawn!=null)
            onSpawn(this);
    }
    public event Action onDeath;

    private void Died()
    {
        if (onDeath!=null)
            onDeath();
    }
    public event Action<StatsManager> onAttack;
    public void callAttack()
    {
        if (onAttack!=null)
            onAttack(this);
    }
    public event Action<StatsManager> onDMG;
    public void callDMG()
    {
        if (onDMG!=null)
            onDMG(this);
    }
    public event Action<StatsManager> onUpdate;
    public void callUpdate()
    {
        if (onUpdate!=null)
            onUpdate(this);
    }
    public event Action<StatsManager> onMove;
    public void callMove()
    {
        if (onMove!=null)
            onMove(this);
    }
    public event Action<StatsManager> onJump;
    public void callJump()
    {
        if (onJump!=null)
            onJump(this);
    }

    public event Action<StatsManager> onHeal;
    public void callHeal()
    {
        if (onHeal!=null)
            onHeal(this);
    }

    public event Action<StatsManager> onAttachMod;
    public void callAttachMod()
    {
        if (onAttachMod!=null)
            onAttachMod(this);
    }

    //on level up

        #region Update Actions
    //Subscribe to  get updates.
    public event Action HealthUpdate;
    public event Action StatUpdate;
    

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



#endregion

    void InitiateStats()
    {
        initHealth();
        callSpawn();//SpawnDelegate
        //Debug
        //BaseDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        callUpdate();
    }

    #region Set Stats Functions
    private void initHealth()
    {
        //Base 80;
        maxHealth = 80f;
        health = maxHealth;

        maxHealth += 5f * Constitution.Amt;

        UpdateHealth();
    }
    public void LevelUp()
    {
        UpdateStats();
    }

    #endregion

    #region Modifier methods
    private void LoadAllMods()
    {

    }
    public void AttachModifier(Modifier inmod)
    {
        //Modifier Implementation Attaches script
        inmod.Attach(this);
        callAttachMod(); //only used for event when attaching any mod.
    }

    public void AddStatPoint(RPStat inStat)
    {
        switch(inStat.StatType)
        {
            case "Strength":
                Strength.Amt += inStat.Amt;
                break;
            case "Intelligence":
                Intelligence.Amt += inStat.Amt;
                break;
            case "Dexterity":
                Dexterity.Amt += inStat.Amt;
                break;
            case "Constitution":
                Constitution.Amt += inStat.Amt;
                break;
            default:
                

                int temptrack = -4;

                for(int i = 0; i < _otherStats.Count; i++)
                {
                    if (_otherStats[i].StatType == inStat.StatType)
                    {
                        temptrack = i;
                        break;
                    }
                }

                if (temptrack >=0)
                {
                    //List workaround.
                    RPStat temp;
                    temp = _otherStats[temptrack];
                    temp.Amt += inStat.Amt;
                    _otherStats[temptrack] = temp;
                }
                else{
                    _otherStats.Add(inStat);
                }
                break;
        }
    }

    #endregion


    #region Heal, Damage, and other public Functions

    //Move attack to somewhere more reasonable/ have combat input differ from actual combat trigger and calc.

    public void Heal(float heal)
    {
        health = health + heal;
        callHeal();
    }
    public float GetDamage(float wepDmg, AtkType wepType) //change to work with playercombat and weapons. Base Damage.
    {

        //Apply perks, twists, and events.

        float atkDMG = 0;
        switch (wepType)
        {
            case AtkType.Magic:
                atkDMG= wepDmg + (Intelligence.Amt * lvl); 
                return atkDMG;
            case AtkType.Range:
                atkDMG= wepDmg + (Dexterity.Amt * lvl);
                return atkDMG;
            case AtkType.Melee:
                atkDMG= wepDmg + (Strength.Amt * lvl);
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
        callDMG();//Delegate

        float dmg = hit.Dmg;
        switch (hit.atkType)
        {
            case AtkType.Magic:
                dmg = dmg - (Intelligence.Amt * lvl);
                break;
            case AtkType.Range:
                dmg = dmg - (Dexterity.Amt * lvl);
                break;
            case AtkType.Melee:
                dmg = dmg - (Strength.Amt * lvl);
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
