using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubLoading : MonoBehaviour
{
    public SceneInjector sceneInjector;
    private TotalGenerator _tg;
    // Start is called before the first frame update
    void Start()
    {
        _tg = sceneInjector.Request<TotalGenerator>();
        _tg.GenerateWorld();
    }

 
}
