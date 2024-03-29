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
    //Injectables
    private DebugGlobal dbg_g = null;
    [SerializeField] private GameManager _gm = null;

    //Debug Panel
    [SerializeField] private GameObject DebugPanel = null;
    [SerializeField] private TextMeshProUGUI DebugText = null;

    //InputActions
    public PlayerControls playerInput;


#region Debug UI

    private float displayCounter;

    public string debugLog;

#endregion


    void Awake()
    {
        
        playerInput = new PlayerControls();
        playerInput.Debug.ToggleUI.performed += ctx => ToggleUI();
        playerInput.Debug.Reset.performed += ContextMenu => ResetGame();
        playerInput.Debug.DieBind.performed += _ => DBGGenLevel();

        sceneJect.SceneJect += Injection;

        DebugGUI("Testing GUI", 10f, "Dbg");

    }

    #region Injection
    public void Injection(InjectionDict ID)
    {
        //Injection
        dbg_g = ID.Inject<DebugGlobal>();
        _gm = ID.Inject<GameManager>();
    }
    #endregion

    // Update is called once per frame
    void Update()
    {

    }

    void DBGGenLevel()
    {
        _gm.InitWorld();
    }

    void ToggleUI()
    {
        DebugPanel.SetActive(!DebugPanel.activeInHierarchy);
    }

    void ResetGame()
    {
        DebugGUI("Reset Game", 1f, "DbgMan");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable() {
        playerInput.Enable();

    }

    private void OnDisable() {
        playerInput.Disable();
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

}
