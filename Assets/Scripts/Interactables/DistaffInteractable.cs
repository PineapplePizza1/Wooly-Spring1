using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistaffInteractable : Interactable
{
    [SerializeField] private SceneInjector sceneInjector;
    private Distaff dsf;
    private void Awake() {
        sceneInjector.SceneJect += Injection;
    }

    private void Injection(InjectionDict ID)
    {
        dsf = ID.Inject<Distaff>();
    }

    public void ActivateStaff()
    {
        dsf.ActivateDistaffMenu();
    }
}

