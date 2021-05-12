using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/9/21, D-Lynn Z

public class GMInject : MonoBehaviour
{

    //Rename to GM Singleton.
    //Prgress tracker is now GM.

    //Singleton Instance
    private static GMInject _instance;

    private int DisplayID; //View in Debug Mode

    //Static Guaranteed accessor
    public static GMInject Instance
    {
        get
        {
            //Guarantees a return for Instance, but also creates errors later on; keep an eye out.
            if (_instance == null)
            {
                _instance = FindObjectOfType<GMInject>();
                if (_instance == null )
                {   
                    _instance = new GameObject().AddComponent<GMInject>();
                    Debug.Log("GM_CRIT: Instance Created via Accessor: " + _instance.GetInstanceID());
                }
            }
            return _instance;
        }
    }


    private void Awake()
    {
        #region SingletonCheck

        if(_instance == null)
        {
            Debug.Log("GM: Registered Singleton " + this.GetInstanceID());
            _instance = this;

            SingleRegistration();
        }
        else if( this.GetInstanceID() != _instance.GetInstanceID())
        {
            Debug.Log("GM: Destroyed an Instance of GM; " + this.GetInstanceID() + " for instance = " + _instance.GetInstanceID());
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);

        #endregion

        //DBG Variable
        DisplayID = this.GetInstanceID();

    }

    private void SingleRegistration() //Register your injections
    {
        //Add Scripts to prefab
        RegisterInjection<DebugGlobal>();
        RegisterInjection<AudioManager>();
        RegisterInjection<GameManager>();
        RegisterInjection<TotalGenerator>();
    }

    public T RegisterInjection<T>() where T : Component
    {
        T compy = gameObject.GetComponent<T>();
        if (compy == null)
        {
            Debug.Log("GM: Registered null component, added component of type = " + typeof(T).Name);
            compy = gameObject.AddComponent<T>();
        }
        return compy;
    }



}


/*Straightforward and simple "Service Locator" for Persistent scripts.
     * Make sure all your persistent objects are attached to this script.
     * 
     * Since Monobehaviours lack Constructors, Unity essentially gives you DI for free,
     * using the fields in the inspector. They're all "injected" at a mystery stage when unity builds and loads those fields.
     * 
     * Thus, since the MB isn't having to create or find it's own Dependant Obj, you "Get rid of the dependancy".
     * IOC is a complicated term, but really, it just means, "hey, how about you do it instead." 
     * So instead of passing extremely tight script references, ("I need this very specific variable from this script on this object, right now"), it takes the form of much more general method calls.
     * Think like instead of "Playermovement.speed.Canvas.Spedometer.Active = true;", "playMove.ActivateSpedometer(); or even, ActivateSpedometer();"
     * It's reliant on DI cuz then you can have the framework pass work to objects without huge concern for coupling.
     * But since DI is free in unity, IOC is as easy as passing objects, writing public methods, and doing it.
     * Gamedev is already so reliant on IOC, so it's no biggie. Think heirarchies, and editable scripted objects. 
     * 
     * So long story short, I was doing DI and IOC since Day 1 of this project. The only thing I ever needed it for was for stuff that doesn't translate between scenes, like this. and this is more than enough.
     * Least sceneJect sounds cool.
     */