using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //Bosstime
    //DEBUG: This version is just to randomize a small set of level chunks; A more legit version will need more logic,
        //seeding, and a better way to pull level prefabs, probably.
        //and handle loading logic. How to do this? probably an in-level loading screen, I'm guessing, but that'd be hard.

            //So that means, distaff previews a level via seed, or seeds are preloaded, like Risk of Rain;
            //but how to pass that in? probably load in resources appropriately, and set and spawn at run-time,
                //needs some tricky scene hiding for sure. Likely, gonna need distaff to be actual scene, then do it.
                //SHIT THAT'S CLEVER, WHY DIDN'T i THINK OF THAT
                //OH WAIT I DID
                //I just didn't think it'd be actually usefull, lol. turns out, it is, but it'll take a sec.
    
    //So logic is now:
    //- Start game, load in the prefabs we need under this object.
    //- Take a second to set active what we need, and delete the rest? possibly.
    //- while level is "loading", place objects in-place, and once ready, spawn, and start.

    public GameObject LevelPlane;
    
    //Bounds variables: probs a better way to do this, but whatevs lol.
    private float minx;
    private float maxx;
    private float minz;
    private float maxz;
    private float centY;


    public List<GameObject> RoomPrefabs;

    private void Awake() {
        Bounds PlaneBounds = LevelPlane.GetComponent<Collider>().bounds;
        Vector3 max = PlaneBounds.max;
        Vector3 min = PlaneBounds.min;
        minx = min.x;
        maxx = max.x;
        minz = min.z;
        maxz = max.z;
        centY = PlaneBounds.max.y + .1f; //Using max to stop the zfighting for now, hopefully

        

    }

    private void Start() {
        //DEBUG: Ideally, the LevelManager should handle the generation, but yknow what? meh for now.

        GenerateLevel(0);
        ActivateLevel();
    }

    public void GenerateLevel(int Seed) //Called on loading the game, to generate random seeds. //Seed = 0 to debug.
    {
        //{pick a random order of the 3 challenges.}

        //pick 3 random locations to spawn em.
        foreach(GameObject room in RoomPrefabs)
        {
            float randx = Random.Range(minx, maxx);
            float randz = Random.Range(minz, maxz);
            Vector3 randPos = new Vector3(randx, centY, randz);

            //CHECK FOR OVERLAP, AND THEN REDO IF IT DOES
                //BUT FOR THIS MOMENT, I LITERALLY DO NOT CARE YET, AND HEY, MAYBE IT'S KINDA COOL

            GameObject roomy = Instantiate(room, randPos, LevelPlane.transform.rotation);
            roomy.transform.SetParent(LevelPlane.transform);
        }
        //does not work for a repeat or something yet, but we'll fix it.

        //go go go
    }

    public void ActivateLevel()
    {
        //get the rest of the level objects, and set it all active.
        //this Script should be active on the general "Level" Object.

        LevelPlane.SetActive(true);
        
        //probably some sorta event, though might have levelMan take over for that.
    }

    public void DeactivateLevel()
    {
        //Deactivate Level

        LevelPlane.SetActive(false);

        //Don't need to deactivate each roo
    }
}
