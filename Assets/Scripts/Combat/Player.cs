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
    public Pooler pooler{get; private set;}

    public void Injection(InjectionDict ID)
    {
        LM = ID.Inject<LevelManagement>();
        pooler = ID.Inject<Pooler>();
        
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
        playerInput.MovementMK.Interact.performed += _ => Interact();

        //Injection
        sceneject.SceneJect += Injection;
        sceneject.FixedSceneLoad += PlayerStart;

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

    //Fixed Scene start to Player
    void PlayerStart() //Start all the scripts on player
    {
        playercomb.StartCombat();
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
            if (focus.tag == "Distaff")
            {
                 DistaffInteractable dsf = focus as DistaffInteractable;
                 dsf.ActivateStaff();
            }
        }

    }

    //OTHER OPTIONS:
        //METHODS FROM INTERACTABLE Inject into this one, via methods.
        
    #endregion
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
