using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;                    //file management
using UnityEngine.UI;
using TMPro;

//LastUpdate: 3/8/21, D-Lynn Z
public class DebugManager : MonoBehaviour
{

    [SerializeField] private SceneInjector sceneJect = null;
    [SerializeField] private TextMeshProUGUI DebugText = null;

    //InputActions
    public PlayerControls playerInput;
    private Vector2 looksies;
    private Vector2 zoomies;

#region Debug UI

    private float displayCounter;

    public string debugLog;

#endregion

    #region Framerate Counter
    int m_frameCounter = 0;
    float m_timeCounter = 0.0f;
    float m_lastFramerate = 0.0f;
    public float m_refreshTime = 0.5f;
    #endregion


    void Awake()
    {
        
        //playerInput = new PlayerControls();
       // playerInput.MovementMK.MouseLook.performed += ctx => looksies = ctx.ReadValue<Vector2>();
       // playerInput.MovementMK.MouseZoom.performed += ctx => zoomies = ctx.ReadValue<Vector2>();
    }


    // Update is called once per frame
    void Update()
    {
        if (m_timeCounter < m_refreshTime)
        {
            m_timeCounter += Time.deltaTime;
            m_frameCounter++;
        }
        else
        {
            //This code will break if you set your m_refreshTime to 0, which makes no sense.
            m_lastFramerate = (float)m_frameCounter / m_timeCounter;
            m_frameCounter = 0;
            m_timeCounter = 0.0f;
        }
        //framerate
        //Debug.Log("DBG: FPS: " + m_lastFramerate);

        //Debug.Log("MouseLook: " + looksies );
    }

    private void OnEnable() {
        //playerInput.Enable();

    }

    private void OnDisable() {
      //  playerInput.Disable();
    }


    public void DebugGUI(string stringDisp, float dispSecs, string dispObject)
    {
        DebugText.gameObject.SetActive(true);
        DebugText.text = "DBGUI: " + stringDisp + "; called: " + dispObject;

        debugLog += DebugText.text;

        displayCounter = dispSecs;

        StartCoroutine(ClearDBG());
    }

    private IEnumerator ClearDBG()
    {
        while(displayCounter > 0)
        {
            displayCounter -= .1f;
            yield return new WaitForSeconds(.1f);
        }

        DebugText.text = "";
        DebugText.gameObject.SetActive(false);
    }


    public static void PrintDebugString(string val)
    {
        StreamWriter streamWrite = new StreamWriter(Application.dataPath + "/Debug/DebugOutput/DebugString.txt");
        streamWrite.Write(val);
        streamWrite.Close();
    }

}
