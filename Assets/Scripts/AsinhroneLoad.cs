using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AsinhroneLoad : MonoBehaviour
{
    private AsyncOperation asyncOperation; // ��������� ������������ ���� UnityEngine
    public GameObject loadpanel;

    // ����� ��� ������� �������� �����
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
            yield return null; // ���� ���������� �����
        }
    }
}
