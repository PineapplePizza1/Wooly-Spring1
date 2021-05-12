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


    //Overall health
    public float health;
    public float maxHealth;

        //LevelStats
    public int XP;

    //public int XPtoNext;
    public int lvl;


    #region Base Stats
    public int BaseStr;
    private RPStat Strength;
     public int BaseDex;
    private RPStat Dexterity;
    public int BaseInt;
    private RPStat Intelligence;
    public int BaseCon;
    private RPStat Constitution;

    //implement dictionary in future.

    #endregion 
    public List<RPStat> _otherStats;


    public AtkType hitType;
    public Hit hitStats;

    //Luck
    //Charisma?
    //NOTE: need something to add status effects; will have to make a class probs, and more events? careful of event abuse.

    //augments and perks; applicable to all stats.
    public List<Modifier> CurrentMods;

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

    public event Action<StatsManager> AttachDmgStats;
    public void callDmgStats()
    {
        if (AttachDmgStats!=null)
        {
            AttachDmgStats(this);
        }
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
    

    private void onUpdateHealth()
    {
        if (HealthUpdate != null)
            HealthUpdate();
    }
    private void onUpdateStats()
    {
        if (StatUpdate != null)
            StatUpdate();
    }

    #endregion



#endregion

    public List<StatusEffects> CurrentEffects;
#region Status Effects


    public event Action<StatsManager> EffectTick; 
    public event Action<StatsManager> onBeginEffect;
    public event Action<StatsManager> onEndEffect;
    

#endregion
    public void InitiateStats()
    {
        initHealth();
        initStats();
        LoadAllMods();
        callSpawn();//SpawnDelegate
        //Debug
        //BaseDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        callUpdate();
        TickFX();
        
    }



    #region Set Stats Functions
    private void initHealth()
    {
        //Base 80;
        UpdateHealth();
        health = maxHealth;

        onUpdateHealth();
    }
    private void initStats()
    {
        Strength.StatType = "STR";
        Strength.Amt = BaseStr;

        Dexterity.StatType = "DEX";
        Dexterity.Amt = BaseDex;

        Intelligence.StatType = "INT";
        Intelligence.Amt = BaseInt;

        Constitution.StatType = "CON";
        Constitution.Amt = BaseCon;
    }
    public void LevelUp()
    {
        onUpdateStats();
    }

    private void UpdateHealth()
    {
        maxHealth = 80f;
        maxHealth += 5f * Constitution.Amt;
    }

    private void UpdateStats()
    {
        
    }
    #endregion

    #region Modifier methods
    private void LoadAllMods()
    {
        //refresh all mods; probably need some other option for effective vs total stats.
        foreach(Modifier startmod in CurrentMods)
        {
            startmod.Remove(this);
            startmod.Attach(this);
        }
    }
    public void AttachModifier(Modifier inmod)
    {
        //Modifier Implementation Attaches script
        Modifier tempy = Instantiate(inmod);
        tempy.Attach(this);
        CurrentMods.Add(tempy);
        callAttachMod(); //only used for event when attaching any mod.
    }

    public void AddStatPoint(RPStat inStat)
    {
        switch(inStat.StatType)
        {
            //Eventually, add to all Stats.
            case "STR":
                Strength.Amt += inStat.Amt;
                break;
            case "INT":
                Intelligence.Amt += inStat.Amt;
                break;
            case "DEX":
                Dexterity.Amt += inStat.Amt;
                break;
            case "CON":
                Constitution.Amt += inStat.Amt;
                break;
            default:
                

                int temptrack = -4;

                for(int i = 0; i < _otherStats.Count; i++)
                {
                    if (_otherStats[i].StatType == inStat.StatType)
                    {
                        temptrack = i;
                        i = _otherStats.Count;
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

    public float GetSpeed(float inSpeed)
    {
        float outSpeed = 0;
        outSpeed = inSpeed * Dexterity.Amt/3f;
        return outSpeed;
    }
    public Hit GetHitStats(float wepDmg, AtkType wepType) //change to work with playercombat and weapons. Base Damage.
    {
        //TODO: Update, to return a full Hitstats.
        //update movespeed and attack speed soon.

        hitStats = new Hit();
        hitStats.Owner = this.gameObject;
        hitStats.atkType = hitType;
        callDmgStats();

        //Apply perks, twists, and events.

        switch (wepType)
        {
            case AtkType.Magic:
                hitStats.Dmg= wepDmg + (Intelligence.Amt * lvl); 
                return hitStats;
            case AtkType.Range:
                hitStats.Dmg= wepDmg + (Dexterity.Amt * lvl);
                return hitStats;
            case AtkType.Melee:
                hitStats.Dmg= wepDmg + (Strength.Amt * lvl);
                return hitStats;
            default:
                Debug.Log("STAT: Attack of no type");
                hitStats.Dmg = wepDmg;
                return hitStats;
        }
    }

    public void TakeAttack(Hit hit)
    {
        Damaged(hit);
    }

    public void Rawdamage(float dmg)
    {
        health -= dmg;
        onUpdateHealth();
        if (health <= 0)
            Died();
    }
    private void Damaged(Hit hit) //takes hit
    {
        callDMG();//Delegate

        float dmg = hit.Dmg;
        Debug.Log("STAT: Took dmg of :" + dmg);
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
        onUpdateHealth();
        if (health <= 0)
            Died();
    }

    
    #endregion

    #region Status Effect Methods
    public void TickFX()
    {
        for(int i = 0; i<CurrentEffects.Count; i++)
        {
            CurrentEffects[i].Tick(this);
        }
    }

    public void ApplyStatus(StatusEffects infx)
    {
        StatusEffects tempy = Instantiate(infx);
        tempy.AddEffect(this);
        bool tempeh = false;
        for(int i = 0; i<CurrentEffects.Count; i++)
        {
            if(CurrentEffects[i].EffectName == infx.EffectName)
            {
                CurrentEffects[i] = tempy;
                tempeh = true;
                i = CurrentEffects.Count;
            }
        }

        if (!tempeh)
        {
            CurrentEffects.Add(tempy);
        }
    }
    public void ApplyStatus(List<StatusEffects> infx)
    {
        foreach(StatusEffects _in in infx)
        {
            ApplyStatus(_in);
        }
    }

    public void RemoveEffect(StatusEffects staty)
    {
        CurrentEffects.Remove(staty);
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
