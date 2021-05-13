using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Cinemachine;



//Use this script to actually handle scene management (game over, in-scene vars, and other details.)
    //{SceneInjector just injections.}
public class LevelManagement : MonoBehaviour
{
    [SerializeField]private SceneInjector sceneject;
    private LevelGenerator levStart;
    private GameManager GM;
    public void Injection(InjectionDict ID)
    {
        levStart = ID.Inject<LevelGenerator>(); 
        GM = ID.Inject<GameManager>();
        
    }

    public bool debugMode;

    public bool HubMode;
    public int HubWorldScene;

    public Transform StartPos;
    public List<GameObject> PlayerPrefabs; //Debug, how I'm spawning the player rn.
    public GameObject nextChar;

    public CinemachineFreeLook freeCam;

    public Transform MainCam;

    


    #region Level Events
    
    public event Action onGameOver;
    public void GameOver()
    {
        if (onGameOver != null)
            onGameOver();
    }
    #endregion


    void Awake() {
        onGameOver +=EndGame;
        
        if (HubMode)
        {
        //dbg spawn char. Pass this in through GM probably in actual game or something, or swap.
        int choice = UnityEngine.Random.Range(0, PlayerPrefabs.Count);
        GameObject chosen = Instantiate(PlayerPrefabs[choice], StartPos.position, StartPos.rotation);
        nextChar = chosen;

        /*
        freeCam.Follow = chosen.transform;
        freeCam.LookAt = chosen.transform;

        //DEBUG/NOTE/ISSUE: Player, since instantiated after game needs sceneject. but, also, it runs probably after sceneject's start;
        //So honestly, might need to rework this so that the Inject is not time-dependent, but rather something you can just call;
        //After all, I have the instance, and the number, so why not just inject? rather than injection event? tho it is convenient.
        //look into this later, too tired and too lazy.
        Player play = chosen.GetComponent<Player>();
        play.InstantiatePlayer(sceneject, MainCam);
        */
        }


        sceneject.SceneJect += Injection;
        sceneject.FixedSceneLoad += LoadCharacter;
        
    }


    public void LoadCharacter()
    {
        Debug.Log("Goof???");
        if(!HubMode) nextChar = GM.nextChar;

        nextChar.SetActive(true);

        nextChar.transform.position = StartPos.position;
        nextChar.transform.rotation = StartPos.rotation;

        freeCam.Follow = nextChar.transform;
        freeCam.LookAt = nextChar.transform;

        Player play = nextChar.GetComponent<Player>();
        play.InstantiatePlayer(sceneject, MainCam);
    }
    

    

    private void EndGame()
    {
        //Should load main menu
        bool checky = GM.CharacterDeath();
        //if (!checky) SceneManager.LoadScene(HubWorldScene); //SceneManager.GetActiveScene().buildIndex - 1);
    }

    
}
