using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Track total progress. loops, etc.

    //*transfer* the player's mods between levels.

    public GMInject GMtrack;

    //init stuff.
    private TotalGenerator _gen;

    private World currentWorld;

    

    private void Awake() {
        if(GMtrack== null)
        {
            GMtrack = GetComponent<GMInject>();
        }
        _gen = GMtrack.RegisterInjection<TotalGenerator>();

        _gen.initGenerators();
    }

    public void InitWorld()
    {
        //set level plane?
        _gen.GenerateWorld();
    }

}
