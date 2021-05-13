using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Track total progress. loops, etc.

    //*transfer* the player's mods between levels.

    public GMInject GMtrack;
    public int GameOverScene;
    public int VictoryScene;
    public int HubWorldScene;

    //init stuff.
    private TotalGenerator _gen;

    private World currentWorld;

    public GameObject nextChar;

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

<<<<<<< HEAD
<<<<<<< HEAD
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

    public GameObject GetNextChar()
    {
        World temp = _gen.GetWorld();
        return temp.loopChars[temp.completions][0];
    }


    public bool CharacterDeath()
    {
        _gen.genWorld.lives -=1;
        
        SceneManager.LoadScene(GameOverScene);
        
        return false;
    }

    public void CompleteLevel(StatsManager inStats)
    {
        _gen.genWorld._successfulStats = inStats;

        _gen.genWorld.completions +=1;

        inStats.gameObject.SetActive(false);

        
        _gen.unloadAll();

        
        SceneManager.LoadScene(VictoryScene);
        
    }

=======
>>>>>>> parent of c254aa2... Finally, full instantiate!
=======
>>>>>>> parent of c254aa2... Finally, full instantiate!
}
