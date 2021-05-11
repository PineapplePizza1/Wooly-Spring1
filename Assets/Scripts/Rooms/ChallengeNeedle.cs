using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeNeedle : MonoBehaviour
{
    //switch needle fx so it doesn't lag, make it just activate, rather than set active
    public bool NeedleComplete;

    public GameObject NeedleFX;

    private void Awake() {
        NeedleComplete = false;
        NeedleFX.SetActive(false);
    }

    public void CompleteNeedle()
    {
        NeedleComplete = true;
        NeedleFX.SetActive(true);
    }

    public void NeedleIncomplete()
    {
        NeedleComplete = false;
        NeedleFX.SetActive(false);
    }

    public void UseNeedle()
    {
        //Needle interaction, from player.
        if (NeedleComplete)
        {
            //Activate UI, only if needle complete.
            //let Room Manager track if 
        }
        
    }


}
