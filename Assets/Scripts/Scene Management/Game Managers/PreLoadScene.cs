using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoadScene : MonoBehaviour
{
    [SerializeField] private int MainMenuLevel;

    void Update() {
        //Ensure the GM loads before going to Main Menu
            SceneManager.LoadScene(MainMenuLevel);
    }
}
