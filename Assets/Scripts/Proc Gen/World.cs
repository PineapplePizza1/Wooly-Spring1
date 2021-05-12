using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    //File that contains all information for a world.

    //self generating? or just storage?

    public int lives = 5;

    public int completions;

    public StatsManager _successfulStats;

    //Levels: [Array Index, X coord, Z coord; item array.] 3 arrays for 3 loops? or just, like, 0-9?
        //Items: [Array Index]; instead of 2d, attach to levels.
    //chars: [Array Index] 3 per loop.
    //Structs also work perfectly for these, since they contain uneditable data, anyways :p
        //Only major benefit I see being structs, might be able to load in the actual items and levels.
        //remember to *instantiate* them at runtime, but it should be ok.
    //Chars likely most difficult, but we'll see.
        //actually not, since just pop it, and if _successfulStats? then add.

    //don't forget method to attach scenemanagement.
    //Likely, pass in this data to instantiators, as well as loop information/just loop info/selected info, and then instantaite and attach.

    public struct RoomData
    {
        public GameObject Room;
        public float xPerc;
        public float zPerc;

        public Modifier[] itemlist; //Idea: generation delegate to add a item? or just, add item in
    }

    //world, containing 3 rooms. Likely, need another struct or something to hold identification. 2d array, with 3 levels.
    public RoomData[][] levels; 
    public GameObject[][] loopChars;
        //r=loop.
    //Containing all loops of the world.


    //Loop data: level, and chars. Display via UI.
        //List or array with add'l data afterwards? optional.
    //Add data as necessary.


    //tip:scale enemies with level. Scale self with level.

    public World(int Worlds)
    {
        levels = new RoomData[Worlds][];
        loopChars = new GameObject[Worlds][];
    }

    
}
