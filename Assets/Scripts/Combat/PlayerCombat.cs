using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//player combat state script, might be redundant; possibly try with just Combat first?
public class PlayerCombat : MonoBehaviour
{
    private PlayerControls playerInput;

    [SerializeField] private ThirdPersonMovement ThirdRef;


    private Attack Prim;
    private Attack Seco;
    private Attack Util;
    private Attack Move;

    void Awake()
    {
        ThirdRef = this.GetComponent<ThirdPersonMovement>();
        

        playerInput = new PlayerControls();
        playerInput.MovementMK.Primary.performed += _ => Primary();
        playerInput.MovementMK.Secondary.performed += _ => Secondary();

        playerInput.MovementMK.Utility.performed += _ => Utility();
        playerInput.MovementMK.Ability.performed += _ => Ability();
    }


    void Primary()
    {
        Prim.Atk(ThirdRef.moveDir);
    }

    void Secondary()
    {
        Seco.Atk(ThirdRef.moveDir);
    
    }

    void Utility()
    {
        Util.Atk(ThirdRef.moveDir);
    }

    void Ability()
    {
        Move.Atk(ThirdRef.moveDir);
    }
    
    
    public void LoadAttack(Attack LoadAtk, BaseWeapon weapon)
    {
        weapon.LoadWeapon(LoadAtk);
    }
    
    public void UnloadAttack(Attack LoadAtk, BaseWeapon weapon)
    {
        weapon.LoadWeapon(LoadAtk);
    }


    private void OnEnable() 
    {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }
}
