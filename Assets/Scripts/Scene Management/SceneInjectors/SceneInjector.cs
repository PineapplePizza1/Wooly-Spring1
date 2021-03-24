using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

//LastUpdate: 3/8/21, D-Lynn Z

//Private sceneinjection behavior, and children; with unrelated but private var accessed public loading list monobehavior
public class SceneInjector : MonoBehaviour
{
    private GenericLoadList loadList;
    //Injectables
    private AudioManager DiskJockey = null;
    private DebugGlobal dbg_g = null;
    
    
    protected InjectionDict SceneScripts;


/*

    [SerializeField] private DebugManager dbg = null;

    [SerializeField] private LevelManagement LevMan = null;
    [SerializeField] private Distaff distaff = null;

    //[SerializeField] private LevelLoader LL = null;
    
    //[SerializeField] private Pooler pooler = null;

*/
    protected virtual void Awake()
    {
        FindLoader();
        //initialize
        SceneScripts = new InjectionDict();

        //GameManager Reg
            if (dbg_g == null) {  dbg_g = GameManager.Instance.RegisterInjection<DebugGlobal>(); }
            if (DiskJockey == null) {  DiskJockey = GameManager.Instance.RegisterInjection<AudioManager>(); }
        //Add Scripts to Dict
            SceneScripts.Add<DebugGlobal>(dbg_g);
            SceneScripts.Add<AudioManager>(DiskJockey);

            LoadInjector();
            
            InjectTest();
            Preload();
    }
    
    //NOTE: could make a version that uses unaffiliated List scripts, but would need an additional virtual function for getcomponent<>.
    //for now, testing probably works, just read debugs to make sure everything's attached.
    protected virtual void FindLoader()
    {
        loadList = GetComponent<GenericLoadList>();
        if (loadList ==null)
            Debug.Log("SM / InjDict: GenericLoadList not found");
    }
    protected virtual void LoadInjector()
    {
        
        List<LoadItem> loader = loadList.Feed();
        foreach(LoadItem item in loader)
        {
            SceneScripts.Add(item.type, item.script);
            //Debug.Log("SM: Added " + item.type);
        }
    }

    protected virtual void InjectTest()
    {
        //Use this in children to test your actual injections in-scene
        //checky checky doo
        //too bad full vars just don't work in chillen, am I right? 
        //might be able to make the kid's version in the thing.

        /*
            //Load List
            SceneScripts.Add<DebugManager>(dbg);
            SceneScripts.Add<Distaff>(distaff);
            SceneScripts.Add<LevelManagement>(LevMan);
            
            //SceneScripts.Add<Pooler>(pooler);
            InheritAdd();
        */
    }

    protected virtual void Preload()
    {
        //probably just replace with an inversion, let 
                //Subscriptions
        //LevMan.onGameOver += GameOverQuit;
    }


    protected virtual void Start()
    {
        //Start Routine
        InjectScripts();

        onFixedSceneLoad();

        onSceneLoaded();
    }




    //PreloadGameover
    protected virtual void GameOverQuit()
    {
        //run unload for all things
        //CURRENTLY EMPTY
        onUnloadScene();

    }


    #region Scene Loading/Injecting Events

    /*LIST OF SUBSCRIBABLE EVENTS:
     * SceneJect
     * FixedSceneLoad
     * onSceneLoaded
     * onUnloadScene
     * 
     */
        //sceneJect.SceneJect += Injection; //Place in Awake
    
    
    public event Action<InjectionDict> SceneJect;
    private void InjectScripts()
    {
        if (SceneJect != null)
            SceneJect(SceneScripts);
    }
    #region EXAMPLE INJECTION
        /*
        #region Injection
        public void Injection(InjectionDict ID)
        {
            //Injection
            rpgDict = ID.Inject<RPGDictionaryGlobal>();

            BarManager = ID.Inject<UIManager>();
            levelCam = ID.Inject<LevelCamera>();
        }
        #endregion
        */
    #endregion

    public event Action FixedSceneLoad;
    private void onFixedSceneLoad()
    {
        if (FixedSceneLoad!= null)
            FixedSceneLoad();
    }

    public event Action SceneLoaded;
    private void onSceneLoaded()
    {
        if (SceneLoaded != null)
            SceneLoaded();
    }

    //BUG: Some objects set inactive after scene ends, possibly reactivate on scene gone?
    public event Action unloadScene;
    public void onUnloadScene()
    {
        if (unloadScene != null)
            unloadScene();
    }

    #endregion

}



[Serializable]
public class InjectionDict
{
    //Class to pass for injection.
    public Dictionary<Type, MonoBehaviour> ScriptDict;

    //Class Constructor
    public InjectionDict()
    {
        ScriptDict = new Dictionary<Type, MonoBehaviour>();
    }

    public void Add<T>(MonoBehaviour m) where T : Component
    {
        if (m.GetType() == typeof(T)) { ScriptDict.Add(typeof(T), m); }
        else Debug.Log("SM / InjDict: Error, Adding script" + m.name + " not equal to Type " + typeof(T));
    }

    //2Param Version
    public void Add(Type t, MonoBehaviour m)
    {
        if (m.GetType() == t) { ScriptDict.Add(t, m); }
        else Debug.Log("SM / InjDict: Error, Adding script" + m.name + " not equal to Type " + t);
    }

    //public registration, for your needs.
    public T Inject<T>() where T : Component
    {
        T send = null;
        bool compy = ScriptDict.TryGetValue(typeof(T), out MonoBehaviour temp);
        if (!compy)
        {
            Debug.Log("SM/InjDict: Couldn't find component of type = " + typeof(T).Name);
        }
        else if (temp.GetType() == typeof(T)) { send = temp as T; }
        return send;
    }
}

public interface ISceneInject
{
    void Injection( InjectionDict ID);
}
