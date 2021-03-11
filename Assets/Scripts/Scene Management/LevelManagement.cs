using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;



//Use this script to actually handle scene management (game over, in-scene vars, and other details.)
    //{SceneInjector just injections.}
public class LevelManagement : MonoBehaviour
{
    [SerializeField]private SceneInjector sceneject;
    public int MainMenuScene;

    #region Level Events
    
    public event Action onGameOver;
    public void GameOver()
    {
        if (onGameOver != null)
            onGameOver();
    }
    #endregion


    void Awake() {
        onGameOver +=EndGame;
    }

    private void EndGame()
    {
        //Should load main menu
        SceneManager.LoadScene(MainMenuScene); //SceneManager.GetActiveScene().buildIndex - 1);
    }

    
}
