using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distaff : MonoBehaviour
{
    //Likely, generating seed for procedural generation
    //Contain Functions used by UI

    [SerializeField] private SceneInjector hubinjector;
    public LoadLevel levelLoader;

    public GameObject DistaffPanel;

    //Debug; next level
    public int distaffLevel;

    public TextMeshProUGUI panel1;
    public TextMeshProUGUI panel2;
    public TextMeshProUGUI panel3;

    public void ActivateDistaffMenu()
    {
        DistaffPanel.SetActive(true);

        GameManager mood = hubinjector.Request<GameManager>();
        int temp = mood.GetWorld().completions;

        panel1.text = mood.GetWorld().loopChars[temp][0].name;
        panel2.text = mood.GetWorld().loopChars[temp][1].name;
        panel3.text = mood.GetWorld().loopChars[temp][2].name;
    }

    public void PickChar(int choice)
    {
        GameManager mood = hubinjector.Request<GameManager>();
        int temp = mood.GetWorld().completions;
        mood.nextChar = mood.GetWorld().loopChars[temp][choice];       
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
