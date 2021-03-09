using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;                    //file management
using UnityEngine.InputSystem;

public class DebugGlobal : MonoBehaviour
{
    public PlayerControls playerInput;
    void Awake()
    {
        playerInput = new PlayerControls();
        playerInput.Debug.Quit.performed += ctx => DebugQuit();
    }

    

    private void OnEnable() {
        playerInput.Enable();

    }

    private void OnDisable() {
      playerInput.Disable();
    }
    

    
    void DebugQuit()
    {
        PrintDebugString("DBG_G: Debug Quit");
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
    public static void PrintDebugString(string val)
    {
        StreamWriter streamWrite = new StreamWriter(Application.dataPath + "/Debug/DebugOutput/DebugString.txt", true);
        streamWrite.Write("[" + System.DateTime.Now + "]: " + val);
        streamWrite.Close();
    }
    public static void PrintDebugFile(string val, string name)
    {
        StreamWriter streamWrite = new StreamWriter(Application.dataPath + "/Debug/DebugOutput/" + name + ".txt");
        string file = "DBGFILE [" + System.DateTime.Now + "]: \n" + val;
        streamWrite.Write(file);
        streamWrite.Close();
    }
    public static void PrintError(string val)
    {
        StreamWriter streamWrite = new StreamWriter(Application.dataPath + "/Debug/DebugOutput/ErrorString.txt", true);
        streamWrite.Write("[" + System.DateTime.Now + "]: " + val);
        streamWrite.Close();
    }
}
