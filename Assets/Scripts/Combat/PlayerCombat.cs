using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//player combat state script, might be redundant; possibly try with just Combat first?
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

    [SerializeField] private ThirdPersonMovement ThirdRef;


    public BaseWeapon Prim;
    public BaseWeapon Seco;
    public BaseWeapon Util;
    public BaseWeapon Move;

    void Awake()
    {
        ThirdRef = this.GetComponent<ThirdPersonMovement>();
        

        playerInput = new PlayerControls();
        playerInput.MovementMK.Primary.performed += ctx => Primary();
        playerInput.MovementMK.Secondary.performed += _ => Secondary();

        playerInput.MovementMK.Utility.performed += _ => Utility();
        playerInput.MovementMK.Ability.performed += _ => Ability();

        Prim.LoadWeapon();
    }


    void Primary()
    {
        if (Prim.Atk ==null)
            Prim.LoadWeapon();
        Prim.Attack(ThirdRef.moveDir);
    }

    void Secondary()
    {
        Seco.Attack(ThirdRef.moveDir);
    
    }

    void Utility()
    {
        Util.Attack(ThirdRef.moveDir);
    }

    void Ability()
    {
        Move.Attack(ThirdRef.moveDir);
    }
    
    
    public void LoadAttack(BaseWeapon weapon)
    {
        weapon.LoadWeapon();
    }
    
    public void UnloadAttack(BaseWeapon weapon)
    {
        weapon.LoadWeapon();
    }


    private void OnEnable() 
    {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }
}
