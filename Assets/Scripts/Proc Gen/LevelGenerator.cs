using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //Change to Level Applicator?

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

    public SceneInjector sceneject;
    
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


    public void ActivateLevel(World.RoomData[] inRooms)
    {
        foreach(World.RoomData roomy in inRooms)
        {
            roomy.prefab.SetActive(true);
            RoomManager trom = roomy.prefab.GetComponent<RoomManager>();
            trom.StartRoom(sceneject);
        }
        LevelPlane.SetActive(true);
        //Drop shadow.
    }

    public void DeactivateLevel(World.RoomData[] inRooms)
    {
        //Deactivate Level
        foreach(World.RoomData roomy in inRooms)
        {
            roomy.prefab.SetActive(false);
        }
        LevelPlane.SetActive(false);

        //Don't need to deactivate each roo
    }
}
