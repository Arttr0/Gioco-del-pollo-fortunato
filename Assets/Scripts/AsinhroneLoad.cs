using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AsinhroneLoad : MonoBehaviour
{
    private AsyncOperation asyncOperation; // ”казываем пространство имен UnityEngine
    public GameObject loadpanel;

    // ћетод дл€ запуска загрузки сцены
    public void LoadNewScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            loadpanel.SetActive(true);
            yield return null; // ∆дем следующего кадра
        }
    }
}
