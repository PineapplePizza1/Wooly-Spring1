using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //Scene manager, include
    
    public SceneInjector sceneInjector;

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private LoadLevel levelLoader;

    [SerializeField] private int NextLevel;

    private void Awake() {
        backControls(); //Sets panels correctly.
    }

    public void StartButton()
    {
        //Start game
        levelLoader.Loadlevel(NextLevel);
        //Cursor.lockState = CursorLockMode.Locked;
    }


//General MM enable: replace later.
    public void enableMM()
    {
        mainPanel.SetActive(true);
    }

    public void StartGen()
    {
        TotalGenerator gt = sceneInjector.Request<TotalGenerator>();
        gt.GenerateWorld();
    }



#region Settings Menu

    public void Controls()
    {
        settingsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void backControls()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
#endregion

    public void QuitButton()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
