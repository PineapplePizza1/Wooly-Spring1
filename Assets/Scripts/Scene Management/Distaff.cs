using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distaff : MonoBehaviour
{
    //Likely, generating seed for procedural generation
    //Contain Functions used by UI

    [SerializeField] private SceneInjector hubinjector;
    public LoadLevel levelLoader;

    public GameObject DistaffPanel;

    //Debug; next level
    public int distaffLevel;

    public void ActivateDistaffMenu()
    {
        DistaffPanel.SetActive(true);
    }

    public void LoadDistaffLevel()
    {
        levelLoader.Loadlevel(distaffLevel);
    }

    public void DeactivateDistaffMenu()
    {
        DistaffPanel.SetActive(false);
    }
}
