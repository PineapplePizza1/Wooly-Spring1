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

    public int roomsPerLevel = 3;
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
    public float xRange = 200;
    public float zRange = 200;
    private float testY = -100;

    #endregion


    #region Item Gen

    public Modifier[] ItemPrefabs;
    
    #endregion

    #region Chara Gen
    public GameObject[] CharaPrefabs;

    public World genWorld;
    private float genProgress;

    private int totalCount;
    private int currentCount;
    

    public bool Generating;
    private bool LevelsDone;
    private bool CharasDone;
    private bool TotalGenDone;


    #endregion

    void Awake()
    {
        Generating = false;
        GenerateWorld();
    }

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


    

   

    public void GenerateWorld()
    {
        if (!Generating)
        {
            Debug.Log("TotGen: I'm generatin over here!");

            Generating = true;

            if (randomizeSeed)
            {
            Seed = Random.Range(100000, 1000000); //Six Digit Seed.
            }

            Random.InitState(Seed);

            genWorld = new World(defaultLoops);

            currentCount = 0;

            LevelsDone = false;
            CharasDone = false;
            TotalGenDone = false;

            totalCount = (defaultLoops * roomsPerLevel) + (charsPerLoop);

            
            StartCoroutine("GenerateLevel");
            StartCoroutine("WorldGenProgress");
            StartCoroutine("GenerateCharacter");

        }

    }

    public World GetWorld()
    {
        return genWorld;
    }


    public void WorldGenComplete()
    {

    }

    public void RunDelete()
    {
        StartCoroutine("DeleteWorld");
    }
    IEnumerator DeleteWorld()
    {
        foreach(World.RoomData[] jstep in genWorld.levels)
        {
            for(int i = 0; i<jstep.Length;i++)
            {
                Debug.Log("TotGen: Gen'd a Char");
                Destroy(jstep[i].Room);
                yield return null;
            }
        }

        genWorld = null;
    }

   IEnumerator WorldGenProgress()
    {
        genProgress = currentCount/totalCount;

        while (!LevelsDone || !CharasDone)
        {
            yield return null;
            
        }


        Debug.Log("TotGen: Gen complete!");
        TotalGenDone = true;
        Generating = false;
        WorldGenComplete();

        yield break;
        
    }
    IEnumerator GenerateCharacter()
    {
        for(int l = 0; l<defaultLoops; l++)
        {
            genWorld.loopChars[l] = new GameObject[charsPerLoop];
            for(int m = 0; m<charsPerLoop; m++)
            {
                Vector3 GenPos = new Vector3(-100, testY, -100);
                GameObject tempChar = Instantiate(CharaPrefabs[Random.Range(0,CharaPrefabs.Length)], GenPos, Quaternion.identity);
                tempChar.transform.SetParent(this.gameObject.transform);
                genWorld.loopChars[l][m] = tempChar;
                genWorld.loopChars[l][m].SetActive(false);

                yield return null;
            }
            yield return null;
        }
        CharasDone = true;
    }

    IEnumerator GenerateLevel()
    {
        for(int j = 0; j<defaultLoops; j++)
        {
            
            genWorld.levels[j] = new World.RoomData[roomsPerLevel];

            for(int i = 0; i<roomsPerLevel; i++)
            {
            //Pick Room.
            GameObject tempRoom = RoomPrefabs[Random.Range(0,RoomPrefabs.Length)];
            World.RoomData _tempy = new World.RoomData();
            

            //can random rotate around y.
            Vector3 GenPos = new Vector3(-100, testY, -100);
            Quaternion rotato = Quaternion.Euler(Quaternion.identity.eulerAngles.x, Random.Range(0,360), Quaternion.identity.eulerAngles.z); 
            _tempy.Room = Instantiate(tempRoom, GenPos, rotato);//single time. Maybe instantiate far away? then jump. Farpoint, lol.



            //generate items.
            Modifier[] _items = new Modifier[itemsPerRoom];

            for(int k = 0; k<_items.Length; k++)
            {
                _items[k] = Instantiate(ItemPrefabs[Random.Range(0, ItemPrefabs.Length)]);
                yield return null;
            }
            genWorld.levels[j][i].itemlist = _items;


            genWorld.levels[j][i] = _tempy;
            genWorld.levels[j][i].Room.transform.SetParent(this.gameObject.transform);
                


            //Get room deets/bounds.
            RoomManager t_RM = genWorld.levels[j][i].Room.GetComponent<RoomManager>();
            Bounds roombnd = t_RM.roomBox.bounds;

            
            Collider[] roomChecks = null;
            Vector3 randPos = Vector3.one;

            do
            {
                float randx = Random.Range(0, xRange);
                float randz = Random.Range(0, zRange);
                randPos = new Vector3(randx, testY, randz);

                //check room bounding box, get reference. if case, redo.
                roomChecks = Physics.OverlapBox(randPos, roombnd.extents, Quaternion.identity, roomMask); //fudge.

                Debug.Log("TotGen: Did a Level Check: " + roomChecks.Length);

                /*
                foreach(Collider please in roomChecks)
                {
                    if (please.gameObject != genWorld.levels[j][i].Room)
                    { 
                        yield return null;
                    }
                }
                */
                yield return null;
                
            }while(roomChecks.Length >1);

            //Debug.Log("TotGen: Confirmed a Level! at: " + randPos);
            genWorld.levels[j][i].Room.transform.position = randPos;
            genWorld.levels[j][i].xPerc = randPos.x/xRange;
            genWorld.levels[j][i].zPerc = randPos.z/zRange;




            currentCount +=1;

            }

            foreach(World.RoomData preffy in genWorld.levels[j])
            {
                preffy.Room.SetActive(false);
                yield return null;
            }
            yield return null;
        }

        LevelsDone = true;

    }

public void unloadAll()
{
    StartCoroutine("DespawnAll");
}
    IEnumerator DespawnAll()
    {
        foreach(World.RoomData[] jstep in genWorld.levels)
        {
            for(int i = 0; i<jstep.Length;i++)
            {
                jstep[i].Room.SetActive(false);
                yield return null;
            }
        }
        foreach(GameObject[] kstep in genWorld.loopChars)
        {
            for(int i = 0; i<kstep.Length;i++)
            {
                kstep[i].SetActive(false);
                yield return null;
            }
        }
    }



    #region Old Methods
/*
    IEnumerator GenerateLevel()
    {
        Debug.Log("TotGen: Running Level Coroutine");

        //check jcount
        //check iCount
        if (jCount!=jP)
        {

            jP = jCount;
            genWorld.levels[jCount] = new World.RoomData[roomsPerLevel];

            if (jCount >= defaultLoops)
            {
                Debug.Log("TotGen: Completed Level Gen!");
                LevelsDone = true;
                yield break;
            }
        }

        if(iCount != iP)
        {
            iP = iCount;
            LevelConfirm = false;

        World.RoomData _tempy = new World.RoomData();

        //Pick Room.
        GameObject tempRoom = RoomPrefabs[Random.Range(0,RoomPrefabs.Length)];

        Vector3 GenPos = new Vector3(-100, testY, -100);

        //can random rotate around y.
        Quaternion rotato = Quaternion.Euler(Quaternion.identity.eulerAngles.x, Random.Range(0,360), Quaternion.identity.eulerAngles.z); 
        _tempy.prefab = Instantiate(tempRoom, GenPos, rotato);//single time. Maybe instantiate far away? then jump. Farpoint, lol.

        

        //generate items.
        //tempLevel[i].itemList = GenerateItems();
        GenerateItems();
        
        genWorld.levels[jCount][iCount] = _tempy;

        yield return null;

        }

        
        if (!LevelConfirm)
        {

        //Get room deets/bounds.
        RoomManager t_RM = genWorld.levels[jCount][iCount].prefab.GetComponent<RoomManager>();
        Bounds roombnd = t_RM.roomBox.bounds;

        float randx = Random.Range(0, xRange);
        float randz = Random.Range(0, zRange);
        Vector3 randPos = new Vector3(randx, testY, randz);

        //check room bounding box, get reference. if case, redo.
        Collider[] roomChecks = Physics.OverlapBox(randPos, roombnd.extents, Quaternion.identity, roomMask); //fudge.
        
        if(roomChecks!=null)
        {
            foreach(Collider please in roomChecks)
            {
                if (please.gameObject != genWorld.levels[jCount][iCount].prefab)
                {
                    Debug.Log("TotGen: Did a Level Check");
                yield return null;
                }
            }
            
        }

        Debug.Log("TotGen: Confirmed a Level!");

        genWorld.levels[jCount][iCount].prefab.transform.position = randPos;
        //set up roomdata. //Redundant for now, but might use to simplify later.
        genWorld.levels[jCount][iCount].xPerc = randPos.x/xRange;
        genWorld.levels[jCount][iCount].zPerc = randPos.z/zRange;

        
        LevelConfirm = true;
        iCount +=1;
            if (iCount >= roomsPerLevel)
            {
                //_tempy.prefab.SetActive(false);
                iCount = 0;
                jCount += 1;
            }
                
        }

        //coroutine section that's only for rechecks. don't Update iCount.

        yield return null;
    }
    
    public World.RoomData[] GenerateLevel()
    {
        //declare level Array
        World.RoomData[] tempLevel = new World.RoomData[roomsInWorld];

        for(int i = 0; i<roomsInWorld; i++)
        {
            Debug.Log("TotGen: Room #: " + i );
            
            //Pick Room.
            GameObject tempRoom = RoomPrefabs[Random.Range(0,RoomPrefabs.Length)];


            //pretest Instantaite
            float randx = Random.Range(0, xRange);
            float randz = Random.Range(0, zRange);
            Vector3 randPos = new Vector3(randx, testY, randz);

            //can random rotate around y.
            Quaternion rotato = Quaternion.Euler(Quaternion.identity.eulerAngles.x, Random.Range(0,360), Quaternion.identity.eulerAngles.z); 
            tempLevel[i].prefab = Instantiate(tempRoom, randPos, rotato);//single time. Maybe instantiate far away? then jump. Farpoint, lol.
            
            //Get room deets/bounds.
            RoomManager t_RM = tempRoom.GetComponent<RoomManager>();
            Bounds roombnd = t_RM.roomBox.bounds;

            //check room bounding box, get reference. if case, redo.
            Collider[] roomChecks = Physics.OverlapBox(roombnd.center,roombnd.extents, Quaternion.identity, roomMask);
            
            while (roomChecks!=null)
            {
                
                randx = Random.Range(0, xRange);
                randz = Random.Range(0, zRange);
                randPos = new Vector3(randx, testY, randz);


                tempLevel[i].prefab.transform.position = randPos;

                //Check again.
                roomChecks = Physics.OverlapBox(roombnd.center,roombnd.extents, Quaternion.identity, roomMask);

            }

            //set up roomdata. //Redundant for now, but might use to simplify later.
            tempLevel[i].xPerc = randPos.x/xRange;
            tempLevel[i].zPerc = randPos.z/zRange;

            //generate items.
            //tempLevel[i].itemList = GenerateItems();
            GenerateItems();

            

        }

        //Possible: add boss.

        //Deactivate all after done.
        foreach(World.RoomData roomy in tempLevel)
        {
            //roomy.prefab.SetActive(false);
        }
        

        return tempLevel;
    }
    */
    //NOTE: prebuild the 3 different loops. use same level plane, but deactivate all rooms afterwards.
            //Single room, but damn, if it isn't literally the easiest, holy crap. 
            //UI loading update when done.

         //Place worlds, then drop.

    #endregion
    public void GenerateItems()
    {
        
    }



    public void GenNewloops()
    {
        //Method to generate additional loops for the world, will see.
    }
}
