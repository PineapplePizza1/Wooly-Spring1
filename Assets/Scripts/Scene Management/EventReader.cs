using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//POTENTIAL: Don't know if we want to use this yet, will have to rework.
public class EventReader : MonoBehaviour
{
/*
    [SerializeField] private SceneInjector sceneject = null;
    private RPGDictionaryGlobal rpgdict = null;
    private Dictionary<string, Action<int>> Events; //events that take an int.


    private string SubscriberList;
    private HistoryQ<String> EventHistory;

    private void Awake()
    {
        Events = new Dictionary<string, Action<int>>();
        EventHistory = new HistoryQ<string>(10);

        //Injection
        sceneject.SceneJect += inject;

        //sceneject.onSceneLoaded += debugload;

        SubscriberList = "";
    }

    #region Scene Events

    public void inject(InjectionDict ID)
    {
        rpgdict = ID.Inject<RPGDictionaryGlobal>();
    }

    public void debugload()
    {

    }
    #endregion

    //EVENT READER METHOD.
    public void ReadEventTag(eventTag tag)
    {

        if (Events.ContainsKey(tag.eType))
        {
            Events[tag.eType].Invoke(tag.passVal);
            EventHistory.Enqueue(tag.eType);
        }
        else
        {
            int tempread = rpgdict.Get(tag.eType);
            if (!(tempread == -4))
            {
                rpgdict.Set(tag.eType, tag.passVal);
                EventHistory.Enqueue(tag.eType);
            }
            else Debug.Log("ERROR_EventReader: Exception to Read Event Tag: " + tag.eType);
        }

    }

    //TASK READING ACTION
        //MOVE TO QUESTHOLSTER
    public void ReadTask(Task inTask)
    {
        if (inTask.Name != "null")
        {
            //Events["addmood"].Invoke(inTask.Mood);
            //Events["addhealth"].Invoke(inTask.Physical);
            Events["addspoons"].Invoke(inTask.SpoonsCost);
            Events["addtime"].Invoke(inTask.TimeHours); //need to add time 
        }
    }


    #region Public Access Methods

    //Method to create and add events.
    public Action<int> InitEvent(string key, Action<int> call)
    {
        if (!Events.ContainsKey(key))
        {
            //Lambda For empty event
            Events[key] = (int i) => { };
            Events[key] += call;


            //Track subscribers.
            SubscriberList += "Key: '" + key
                    + "'; Target: " + call.Target.ToString() + " ;\n";

            return Events[key];
        }
        else Debug.Log("EReader: Error, Tried to create existing Tag: " + key);
        return null;
    }

    public void AddListener(string key, Action<int> call)
    {
        if (Events.ContainsKey(key))
        {
            Events[key] += (call);

            //Track subscribers.
            SubscriberList += "Key: '" + key
                    + "'; Target: " + call.Target.ToString() + " ;\n";
        }
        else Debug.Log("EReader: Error, Couldn't find existing Tag: " + key);
    }

    public void RemoveListener(string key, Action<int> call)
    {
        if (Events.ContainsKey(key))
        {
            Events[key] -= (call);
        }
        else Debug.Log("EReader: Error, Couldn't find existing Tag: " + key);
    }

    public Action<int> FindEvent(string key)
    {
        bool temp = Events.TryGetValue(key, out Action<int> getval);
        if (temp)
        {
            return getval;
        }
        else Debug.Log("EReader: Error, Couldn't find existing Tag: " + key);
        return null;
    }

    //method for fast Add Or Init
    public Action<int> AddInitEvent(string key, Action<int> call)
    {
        bool temp = Events.TryGetValue(key, out Action<int> getval);
        if (temp)
        {
            Debug.Log("EREAD: Added.");
            AddListener(key, call);
            return getval;
        }
        else
        {
            return InitEvent(key, call);
        }
    }

    //method for fast find OR Add
    public Action<int> FindAddEvent(string key, Action<int> call)
    {
        bool temp = Events.TryGetValue(key, out Action<int> getval);
        if (temp)
        {
            return getval;
        }
        else
        {
            return InitEvent(key, call);
        }
    }
    #endregion


    #region Debug

    public string SendAllEventNames()
    {
        string output = "";
        foreach (KeyValuePair<string, Action<int>> kvp in Events)
        {
            output += "Key: " + kvp.Key + " \n";
        }
        return output;
    }

    public string SendSubscriberList()
    {
        return SubscriberList;
    }

    public void PrintSubscriberListDebug()
    {
        DebugToolManager.PrintDebugString(SubscriberList);
    }

    public void PrintEventTagsDebug()
    {
        DebugToolManager.PrintDebugString(SendAllEventNames());
    }

    public void PrintEventHistory()
    {
        DebugToolManager.PrintDebugString(EventHistory.ToString());
    }

    public string SendEventHistory()
    {
        return EventHistory.ToString();
    }

    #endregion
*/

}



public class HistoryQ<T>
{
    public Queue<T> hList;
    public int MaxSize { get; private set; }
    public int cSize { get; private set; }

    public HistoryQ(int inMax)
    {
        MaxSize = inMax;
        hList = new Queue<T>();
        cSize = hList.Count;
    }

    public void Enqueue(T inny)
    {
        cSize = hList.Count;
        if (cSize >= MaxSize)
        {
            hList.Dequeue();
            hList.Enqueue(inny);
        }
        else
        {
            hList.Enqueue(inny);
        }
        cSize = hList.Count;
    }

    public T Dequeue()
    {
        T temp = hList.Dequeue();
        cSize = hList.Count;
        return temp;
    }

    public new string ToString()
    {
        string output = "";
        int county = 0;
        foreach(T mem in hList)
        {
            output += county + ". " + mem.ToString() + "\n";
            county += 1;
        }
        return output;
    }

}

