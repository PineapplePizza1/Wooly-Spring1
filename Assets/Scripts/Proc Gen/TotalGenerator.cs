using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalGenerator : MonoBehaviour
{
    //Attach to Game Management, with Progress Org, or Game Manager.

    //Track all three generators, and seed.
    //Send seed to level and item generator.
    //jk.

    #region String Seed Implementation (WIP)
    //public string stringSeed = "seed string";
    public bool useStringSeed;

    public int Seed;
    #endregion

    public bool randomizeSeed = true;

    public int roomsInWorld = 3;
    public int itemsPerRoom = 3;
    public int charsPerLoop = 3;
    public int defaultLoops = 3;
    

    //Call this method before any of the other generators operate.
        //Note: Now need the other generators to operate *before* the game starts. And list Icons of the possible items, the levels, and etc. scrnshot? minimap?
        //bool to see if seeded? or really, just always ref by gens, and the seed should stay the same, right?
        //oh, but also init state, huh. but it should be ok, I imagine. turn off randomizing, and set seed?


        //other gens now also need to be called b4hand, and then store data, then render it when starting game. maybe load all and set inactive? ooh.
    public void initGenerators()
    {
        //Set the generation before set.
        if (randomizeSeed)
        {
        Seed = Random.Range(100000, 1000000); //Six Digit Seed.
        }
    
        Random.InitState(Seed);
    }

    #region Level Gen

    public GameObject[] RoomPrefabs;

    public LayerMask roomMask;
    public GameObject LevelPlane; //Needs, so that any overlaps can recacluate.
    private float minx;
    private float maxx;
    private float minz;
    private float maxz;
    private float centY;

    #endregion


    #region Item Gen

    public GameObject[] ItemPrefabs;
    
    #endregion

    #region Chara Gen
    public GameObject[] CharaPrefabs;


    #endregion

    //consistent generation also relies on a consistent order of requests, so will probably consolidate all generation to the same script :(
        //Level, Item, Player. Need it as a whole ass file, basically. maybe a World class?
            //Level slots, and level positions.
            //Item slots//choices for each one. 
        
        //Either batch generate:safe but kinda costly?
        //or generate in stages; harder to keep consistent if there is any randomness. Ok, batch and store it is.

    /*
    public World GetWorld(int _seed)
    {
        
    }
    */

    //vis tip: generate world, then drop the reveal, with distaff.
        //So, instead of just space, make it full space box.

    public void SetLevelPlane(GameObject _inPlane) {

        Bounds PlaneBounds = _inPlane.GetComponent<Collider>().bounds;
        Vector3 max = PlaneBounds.max;
        Vector3 min = PlaneBounds.min;
        minx = min.x;
        maxx = max.x;
        minz = min.z;
        maxz = max.z;
        centY = PlaneBounds.max.y + .1f; //Using max to stop the zfighting for now, hopefully


    }


   

    public void GenerateWorld()
    {
        Random.InitState(Seed);

        World genWorld = new World(defaultLoops);

        //declare world type.
        for(int j = 0; j<defaultLoops; j++)
        {
            genWorld.levels[j] = GenerateLevel();
            //genWorld.loopChars[j] = generateCharacters();
                GenerateCharacters();
            //Place each into a structure.
        }
        //return world info.
    }
    public World.RoomData[] GenerateLevel()
    {
        //declare level Array
        World.RoomData[] tempLevel = new World.RoomData[roomsInWorld];

        for(int i = 0; i<roomsInWorld; i++)
        {
            //Pick Room.
            GameObject tempRoom = RoomPrefabs[Random.Range(0,RoomPrefabs.Length)];


            //pretest Instantaite
            float randx = Random.Range(minx, maxx);
            float randz = Random.Range(minz, maxz);
            Vector3 randPos = new Vector3(randx, centY, randz);

            //can random rotate around y.

            tempLevel[i].prefab = Instantiate(tempRoom, randPos, LevelPlane.transform.rotation);//single time. Maybe instantiate far away? then jump. Farpoint, lol.
            
            //Get room deets/bounds.
            RoomManager t_RM = tempRoom.GetComponent<RoomManager>();
            Bounds roombnd = t_RM.roomBox.bounds;

            //check room bounding box, get reference. if case, redo.
            Collider[] roomChecks = Physics.OverlapBox(roombnd.center,roombnd.extents, Quaternion.identity, roomMask);
            
            while (roomChecks!=null)
            {
                
                randx = Random.Range(minx, maxx);
                randz = Random.Range(minz, maxz);
                randPos = new Vector3(randx, centY, randz);


                tempLevel[i].prefab.transform.position = randPos;

                //Check again.
                roomChecks = Physics.OverlapBox(roombnd.center,roombnd.extents, Quaternion.identity, roomMask);

            }

            //set up roomdata. //Redundant for now, but might use to simplify later.
            tempLevel[i].xCord = randPos.x;
            tempLevel[i].xCord = randPos.z;

            //generate items.
            //tempLevel[i].itemList = GenerateItems();
            GenerateItems();

        }

        //Possible: add boss.

        //Deactivate all after done.
        foreach(World.RoomData roomy in tempLevel)
        {
            roomy.prefab.SetActive(false);
        }

        return tempLevel;
    }
    //NOTE: prebuild the 3 different loops. use same level plane, but deactivate all rooms afterwards.
            //Single room, but damn, if it isn't literally the easiest, holy crap. 
            //UI loading update when done.

         //Place worlds, then drop.

    
    public void GenerateItems()
    {
        
    }

    public void GenerateCharacters()
    {
        for(int i = 0; i<charsPerLoop; i++)
        {

        }
    }

    public void GenNewloops()
    {
        //Method to generate additional loops for the world, will see.
    }
}
