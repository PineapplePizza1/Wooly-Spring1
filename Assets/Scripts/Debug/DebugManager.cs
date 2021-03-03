using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DebugManager : MonoBehaviour
{

    

    //InputActions
    public PlayerControls playerInput;
    private Vector2 looksies;
    private Vector2 zoomies;


    void Awake()
    {
        
        //playerInput = new PlayerControls();
       // playerInput.MovementMK.MouseLook.performed += ctx => looksies = ctx.ReadValue<Vector2>();
       // playerInput.MovementMK.MouseZoom.performed += ctx => zoomies = ctx.ReadValue<Vector2>();
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MouseLook: " + looksies );
    }

    private void OnEnable() {
        //playerInput.Enable();

    }

    private void OnDisable() {
      //  playerInput.Disable();
    }
}
