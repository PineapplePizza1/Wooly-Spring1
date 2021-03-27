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
    public List<MonoNamePair> ScriptList; //Maybe make another struct with names, just so I can actually keep track of what I need to attach in scene, vs specific ones.
        //still gonna need those sceneject children to test though, that'd be great.

    [System.Serializable]
        public struct MonoNamePair
        {
            public string Requirement;
            public MonoBehaviour Script;
        }
        

    public List<LoadItem> Feed()
    {
        List<LoadItem> loader = new List<LoadItem>();
        foreach(MonoNamePair script in ScriptList)
        {
            //Check if null
            if(script.Script != null)
            {
            LoadItem temp = new LoadItem();
            temp.script = script.Script;
            temp.type = script.Script.GetType();
            loader.Add(temp);
            }
        }
        return loader;
    }
}
