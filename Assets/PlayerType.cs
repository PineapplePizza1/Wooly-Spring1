using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerType : MonoBehaviour
{
    //Incomplete; will have to change to asset bundles and/or animation changes to complete. for now, single char/switch will have to work; keep items though.
    public CharacterTypes[] playerTypes;
    private Animator playAnim;
    
    [System.Serializable]
    public struct CharacterTypes
    {
        public GameObject Model;
        
        public Avatar avatar;

        public string ControllerPath; //gotta find the path to controller, big sad.

    [HideInInspector]
        public RuntimeAnimatorController rtc;
    }

    private void Awake() {
        for(int i = 0; i < playerTypes.Length; i++)
        {
            playerTypes[i].Model.SetActive(false);
            playerTypes[i].rtc = Resources.Load(playerTypes[i].ControllerPath) as RuntimeAnimatorController;
            //Debug.Log("PTyper: RTC was : " + playerTypes[i].rtc.ToString());
        }

        playAnim = GetComponent<Animator>();
    }

    public void SwapChar(int index)
    {
        DisableAll();
        playerTypes[index].Model.SetActive(true);
        playAnim.avatar = playerTypes[index].avatar;
        playAnim.runtimeAnimatorController = playerTypes[index].rtc;
        
    }

    public void DisableAll()
    {
        foreach(CharacterTypes chtype in playerTypes)
        {
            chtype.Model.SetActive(false);
            //chtype.Anim.enabled = false;
        }
    }
}
