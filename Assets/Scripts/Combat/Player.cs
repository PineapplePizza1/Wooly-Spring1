using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LU: 3/10/21 D-Lynn Z 

/*Use this script to manage player details, like player state, other player input, and death.

*/

public class Player : MonoBehaviour
{
    [SerializeField] private SceneInjector sceneject;
    #region Injection
    private LevelManagement LM;

    public void Injection(InjectionDict ID)
    {
        LM = ID.Inject<LevelManagement>();
    }
    #endregion

    //playercontrols map
    public PlayerControls playerInput;

    #region Basic Input State
    private InputState inputState;
    enum InputState{
        Move,
        Pause,
        Dead,
        Respawn
    }
    #endregion

    //send health to health UI
        //Subscriber based system
    

    //COMPONENTS: local
    
    public ThirdPersonMovement playerMove {get; private set;}
    public StatsManager playerstat {get; private set;}
    public PlayerCombat playercomb {get; private set;}
    public PlayerLoadout playerload {get; private set;}



    private void Awake() {

        //Input
        playerInput = new PlayerControls();
        playerInput.Debug.DieBind.performed += _ => PlayerDeath();
        playerInput.Debug.DBGdmg.performed += _ => DebugDMG();

        //Injection
        sceneject.SceneJect += Injection;

        //DEBUG: input state set, just for now. Eventually, legitimate start.
            inputState = InputState.Move;


        //Stats Subscription
        playerstat = this.GetComponent<StatsManager>(); //get player stats
        playerstat.Death += PlayerDeath;
        playerstat.HealthUpdate += UpdateHealth;
        playerstat.StatUpdate += UpdateStats;


        //load local.
        playerMove = this.GetComponent<ThirdPersonMovement>();
        playerstat = this.GetComponent<StatsManager>();
        playercomb = this.GetComponent<PlayerCombat>();
        playerload = this.GetComponent<PlayerLoadout>();
    }

    void PlayerPause()
    {
        
    }

    void DebugDMG()
    {
        
        //playerStats.Damage(60f, StatsManager.AtkType.Base); //maybe switch enum to later class; attacks might become a class.
    }


    void UpdateHealth()
    {
        //UI goes here
        Debug.Log("PLY: Health = " + playerstat.health);
    }
    void UpdateStats()
    {
        //UI goes here
        Debug.Log("PLY: Stats Updated");
    }

    void PlayerDeath()
    {
        //Kill player, set death state,
        inputState = InputState.Dead;
        //Send message to LM,
        Debug.Log("PLY: The Player is Dead!");
        //Game over.
        LM.GameOver();
            //CAUTION: Where do I handle Lives? either this script, stats handler, or LevelMan. Probably Stats handler.
    }


    private void OnEnable() {
    playerInput.Enable();

    }

    private void OnDisable() {
        playerInput.Disable();
        playerstat.Death -= PlayerDeath;

    }
    
}
