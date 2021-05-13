using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//LU: 3/10/21 D-Lynn Z 

/*Use this script to manage player details, like player state, other player input, and death.

*/

public class Player : MonoBehaviour
{
    [SerializeField] private SceneInjector sceneject;
    #region Injection
    private LevelManagement LM;
    private DebugManager debugManager;
    public Pooler pooler{get; private set;}


    public void Injection(InjectionDict ID)
    {
        LM = ID.Inject<LevelManagement>();
        pooler = ID.Inject<Pooler>();
        debugManager = ID.Inject<DebugManager>();
        
    }
    #endregion

#region DEBUG
    public bool debugMode;
    public Modifier DebugMod;

    public StatusEffects DebugFX;
    #endregion

    //DEBUG: Could probably inject this, but hey, this also works, and is basically injection, soooo
    public Transform MainCam {get; private set;}

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
    /* //DEBUG/WORKAROUND: I have no clue how I want to do this yet, but I guess here we gooo
        //likely, the future practical answer is to make Sceneject not an event, but a real method that returns something like gamecomponent<>.
    */

    if (debugMode)
    {
        playerMove = this.GetComponent<ThirdPersonMovement>();
        InstantiatePlayer(sceneject, playerMove.cam);
    }

}

    public void InstantiatePlayer(SceneInjector passject, Transform incam)
    {
        sceneject = passject;
        MainCam = incam;



        //Input
        
        playerInput = new PlayerControls();
        //playerInput.Debug.DieBind.performed += _ => PlayerDeath();
        //playerInput.Debug.DBGdmg.performed += _ => DebugModify();
        playerInput.MovementMK.Interact.performed += _ => Interact();

    //DEBUG: originally in  onenable, but the spawn method is a little odd to be sure.
        playerInput.Enable();

        //Injection
        //sceneject.SceneJect += Injection;
        //sceneject.FixedSceneLoad += PlayerStart;
        
        LM = sceneject.Request<LevelManagement>();
        pooler = sceneject.Request<Pooler>();
        debugManager = sceneject.Request<DebugManager>();

        //DEBUG: input state set, just for now. Eventually, legitimate start.
            inputState = InputState.Move;


        //Stats Subscription
        playerstat = this.GetComponent<StatsManager>(); //get player stats
        playerstat.onDeath += PlayerDeath;
        playerstat.HealthUpdate += UpdateHealth;
        playerstat.StatUpdate += UpdateStats;


        //load local.
        playerMove = this.GetComponent<ThirdPersonMovement>();
        playerstat = this.GetComponent<StatsManager>();
        playercomb = this.GetComponent<PlayerCombat>();
        playerload = this.GetComponent<PlayerLoadout>();

        PlayerStart();
    }

    //Fixed Scene start to Player
    void PlayerStart() //Start all the scripts on player
    {
        playercomb.StartCombat();
        playerMove.InitMovement(MainCam);
        playerstat.InitiateStats();
        //Start Loadout in Combat
    }

    //DEBUG: Putting player interaction here for now, cuz I can't come up with anythign right now I'll split it later if needed
    #region Interactables
    private Interactable target;
    private Interactable focus;

    public void NearInteract(Interactable youu)
    {
        target = youu;
    }
    public void LeaveInteract(Interactable youu)
    {
        if (target == youu)
            target = null;
    }
    
    private void Interact()
    {
        //take in interactable
        if (target!=null)
        {
            focus = target;
            Debug.Log("PLY: I focused on " + focus.gameObject.name); //find a better way to do this. 

            switch(focus.tag)
            {
                case "Distaff":
                DistaffInteractable dsf = focus as DistaffInteractable;
                 dsf.ActivateStaff();
                    break;
                case "Spectral":
                    SpectralDoor sp = focus as SpectralDoor;
                    sp.CompleteLevel(playerstat);
                    break;
                case "Needle":
                    ChallengeNeedle cn = focus as ChallengeNeedle;
                    cn.UseNeedle(playerstat);
                    break;
            }

        }

    }

    //OTHER OPTIONS:
        //METHODS FROM INTERACTABLE Inject into this one, via methods.
        
    #endregion
    void PlayerPause()
    {
        
    }

    void DebugModify()
    {
        playerstat.AttachModifier(DebugMod);
        //playerstat.ApplyStatus(DebugFX);
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
        debugManager.DebugGUI("Killed Player", 1f, "Player");
        //Kill player, set death state,
        inputState = InputState.Dead;
        //Send message to LM,
        Debug.Log("PLY: The Player is Dead!");
        //Game over.
        LM.GameOver();
            //CAUTION: Where do I handle Lives? either this script, stats handler, or LevelMan. Probably Stats handler.
            
    }


/* DEBUG/WORKAROUND: Don't know how to do this via enable yet, so I'll let the instantiation process run this method, I guess lol.
    private void OnEnable() {
        playerInput.Enable();

    }

*/
/*
    private void OnDisable() {
        playerInput.Disable();
        playerstat.onDeath -= PlayerDeath;

    }
    */
    
}
