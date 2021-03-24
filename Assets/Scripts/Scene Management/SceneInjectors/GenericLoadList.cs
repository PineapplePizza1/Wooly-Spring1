using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public struct LoadItem
{
    public MonoBehaviour script;
    public Type type;
    
}
public class GenericLoadList : MonoBehaviour
{   
    public List<String> Requirements;
    public List<MonoBehaviour> ScriptList; //Maybe make another struct with names, just so I can actually keep track of what I need to attach in scene, vs specific ones.
        //still gonna need those sceneject children to test though, that'd be great.

    /*
        public struct MonoNamePair
        {
            public string Requirement;
            public MonoBehaviour Script;
        }
        */

    public List<LoadItem> Feed()
    {
        List<LoadItem> loader = new List<LoadItem>();
        foreach(MonoBehaviour script in ScriptList)
        {
            //Check if null
            if(script != null)
            {
            LoadItem temp = new LoadItem();
            temp.script = script;
            temp.type = script.GetType();
            loader.Add(temp);
            }
        }
        return loader;
    }
}
