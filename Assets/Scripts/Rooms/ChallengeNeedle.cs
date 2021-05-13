using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeNeedle : Interactable
{
    //switch needle fx so it doesn't lag, make it just activate, rather than set active
    public bool NeedleComplete;


    public Modifier[] ItemPrefabs;
    private Modifier outMod;

    public GameObject NeedleFX;

    private void Awake() {
        NeedleComplete = false;
        NeedleFX.SetActive(false);
        initNeedle();
    }

    public void initNeedle()
    {
        Instantiate(ItemPrefabs[Random.Range(0, ItemPrefabs.Length)]);
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

    public void UseNeedle(StatsManager _inStats)
    {
        //Needle interaction, from player.
        if (NeedleComplete)
        {
            //Activate UI, only if needle complete.
            //let Room Manager track if 
            _inStats.AttachModifier(outMod);

            NeedleIncomplete();
        }
        
    }


}
