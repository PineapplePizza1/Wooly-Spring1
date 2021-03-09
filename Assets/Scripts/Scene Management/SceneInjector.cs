using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

//LastUpdate: 3/8/21, D-Lynn Z
public class SceneInjector : MonoBehaviour
{

    //Injectables
    private AudioManager DiskJockey = null;
    private DebugGlobal dbg_g = null;
    //[SerializeField] private Pooler pooler = null;
    [SerializeField] private DebugManager dbg = null;

    private InjectionDict SceneScripts;

    void Awake()
    {
        //initialize
        SceneScripts = new InjectionDict();

        //GameManager Reg
            if (dbg_g == null) {  dbg_g = GameManager.Instance.RegisterInjection<DebugGlobal>(); }
            if (DiskJockey == null) {  DiskJockey = GameManager.Instance.RegisterInjection<AudioManager>(); }
        //Add Scripts to Dict
            SceneScripts.Add<DebugGlobal>(dbg_g);
            SceneScripts.Add<AudioManager>(DiskJockey);
            SceneScripts.Add<DebugManager>(dbg);
            //SceneScripts.Add<Pooler>(pooler);

        //Preloads
        onGameOver += GameOverQuit;
    }




    //PreloadGameover
    private void GameOverQuit()
    {
        //run unload for all things
        //CURRENTLY EMPTY
        onUnloadScene();

        //Should load main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    #region Scene Events

    /*LIST OF SUBSCRIBABLE EVENTS:
     * SceneJect
     * onSceneLoaded
     * onGameOver
     * 
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

/*
    //EventReader
    public event Action<EventReader> EventLoad;
    private void onEventLoad()
    {
        if (EventLoad != null)
            EventLoad(eReader);
    }
*/

    public event Action FixedSceneLoad;
    private void onFixedSceneLoad()
    {
        if (FixedSceneLoad!= null)
            FixedSceneLoad();
    }

    public event Action onSceneLoaded;
    private void SceneLoaded()
    {
        if (onSceneLoaded != null)
            onSceneLoaded();
    }

    public event Action onGameOver;
    public void GameOver()
    {
        if (onGameOver != null)
            onGameOver();
    }

    //BUG: Some objects set inactive after scene ends, possibly reactivate on scene gone?
    public event Action unloadScene;
    public void onUnloadScene()
    {
        if (unloadScene != null)
            unloadScene();
    }

    #endregion


    #region Debug

    public static void PrintDebugString(string val)
    {
        
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
