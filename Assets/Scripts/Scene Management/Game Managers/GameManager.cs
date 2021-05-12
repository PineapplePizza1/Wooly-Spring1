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

    public World GetWorld()
    {
        return _gen.GetWorld();
    }
    public World.RoomData[] GetLevel()
    {
        World temp = _gen.GetWorld();
        int indy = temp.completions;
        if(temp.completions >= temp.levels.Length){
            return temp.levels[indy];
        }
            else return null; //Add victory level.
    }

}
