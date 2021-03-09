using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadLevel : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI progressText;
    public void Loadlevel( int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));        
    }

    IEnumerator LoadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        loadingPanel.SetActive(true);

        while(!operation.isDone)
        {
            //Clamp just the Loading, not Activation.
            float progress = Mathf.Clamp01(operation.progress / .9f);
            
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
