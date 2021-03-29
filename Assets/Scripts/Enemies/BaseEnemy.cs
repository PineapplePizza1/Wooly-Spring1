﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Functions like the Player Script, Handle base management for the enemies. Keep simpler than player.
    //NOTE: need to figure a way to configure attacks animations for enemies.
public class BaseEnemy : MonoBehaviour
{
    private StatsManager myStats;

    private void Awake() {
        myStats = GetComponent<StatsManager>();

        myStats.Death += EnemyDeath;

    }

    private void EnemyDeath() //Enemy Defeat method
    {
        this.gameObject.SetActive(false);
    }
}
