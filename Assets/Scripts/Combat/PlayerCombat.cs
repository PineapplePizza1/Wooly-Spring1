using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//player combat state script, might be redundant; possibly try with just Combat first?
//input, trigger attacks.
public class PlayerCombat : MonoBehaviour
{

    //Load weapons, then attacks? And what about augmentations? 
        //Augmentations, additional changes to the attack class, for all weapons?
                //Base Weapons --> Perks --> Attacks --> Augments, like bullet change, etc. Details about *the attack* cuz, augments should work for all attacks? or maybe perks load diff. a lot of conditionals. check items in Ror2.
                //Ror2 Version: Skills --> Stats, prob --> Attacks --> Items
        //create classes:
        /*
            - Base Weapon,
            - Attchments (Perks, Items, that attach to weapon. Hold in a list, and process changes from base, like add to attack and etc.)
            - Attacks(the actual events/code that runs the attack. Can hold the stats in here from weapon, or in method param, like bullet, damage, etc.)
                -Possibly, Hit or HitStats, to hold that information.

            btw, Items are gonna have to be a big bit, want to get the structure down first.

        */

    private PlayerControls playerInput;

    private Player PM;
    //private locals
    private ThirdPersonMovement pmove;
    private PlayerLoadout pload;

    private Animator pAnim;


    public Attack Prim;
    public Attack Seco;
    public Attack Util;
    public Attack Move;

    void Awake()
    {
        
        playerInput = new PlayerControls();
        playerInput.MovementMK.Primary.performed += ctx => Primary();
        playerInput.MovementMK.Secondary.performed += _ => Secondary();

        playerInput.MovementMK.Utility.performed += _ => Utility();
        playerInput.MovementMK.Ability.performed += _ => Ability();

        PM = GetComponent<Player>();
        pAnim = GetComponentInChildren<Animator>();


        //create attacks
        Prim = new Attack(this.gameObject);
        Seco = new Attack(this.gameObject);
        Util = new Attack(this.gameObject);
        Move = new Attack(this.gameObject);
        
    }

    void Start()
    {
        pmove = PM.playerMove;
        pload = PM.playerload;

        //load all weps
        pload.LoadPrimary(Prim);
        pload.LoadSecondary(Seco);
        pload.LoadUtility(Util);
        pload.LoadMovement(Move);
        
    }


    void Primary()
    {
        
            //LOADWEP returns null atm, might wanna make new attacks or something.
                //really, the attacks should be here, just delegates triggered by the playercombat. but ??? shruggies.
        if (Prim ==null)
            pload.LoadPrimary(Prim);
        Prim.Atk(PM.playerMove.moveDir);
        pAnim.SetInteger("AtkType", 0);
        pAnim.SetTrigger("AtkTrigger");
        
    }

    public void PrimOnHit()
    {
        Prim.OnHit();
    }

    void Secondary()
    {
        //Seco.Attack(ThirdRef.moveDir);
    
    }

    void Utility()
    {
        //Util.Attack(ThirdRef.moveDir);
    }

    void Ability()
    {
        //Move.Attack(ThirdRef.moveDir);
    }
    
    
    public void LoadAttack(BaseWeapon weapon)
    {
        //weapon.LoadWeapon();
    }
    
    public void UnloadAttack(BaseWeapon weapon)
    {
        //weapon.LoadWeapon();
    }


    private void OnEnable() 
    {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }
}
