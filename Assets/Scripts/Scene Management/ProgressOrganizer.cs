using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressOrganizer : MonoBehaviour
{
    public float GenSeed;

    // Track total progress. loops, etc.

    //*transfer* the player's mods between levels.

    //Create the 3 generated worlds.
    

    private void Awake() {
        GenSeed = Random.Range(100000, 1000000); //Six Digit Seed.

    }

}
