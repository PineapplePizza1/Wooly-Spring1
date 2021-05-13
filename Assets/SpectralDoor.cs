using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralDoor : Interactable
{
     [SerializeField] private SceneInjector sceneInjector;
        private GameManager _gm;
     private void Awake() {
        sceneInjector.SceneJect += Injection;
    }

    private void Injection(InjectionDict ID)
    {
        _gm = ID.Inject<GameManager>();
    }

    public void CompleteLevel(StatsManager stats)
    {
        _gm.CompleteLevel(stats);
    }
}
