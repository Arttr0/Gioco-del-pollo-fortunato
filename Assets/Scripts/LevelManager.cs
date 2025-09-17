using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // ������ ������ ��� �������
    public GameObject[] locks; // ������ ������ ��� �������

    void Start()
    {
        int levelsCompleted = PlayerPrefs.GetInt("LevelsCompleted", 0);
    
    // ����������, ��� ������ ������� ������ ������
    if (levelsCompleted < 1)
    {
        levelsCompleted = 1;
        PlayerPrefs.SetInt("LevelsCompleted", 1);
        PlayerPrefs.Save();
    }

    // �������� ��������� ������ � ������
    for (int i = 0; i < levelButtons.Length; i++)
    {
        if (i < levelsCompleted) // ���� ������� �������
        {
            locks[i].SetActive(false); // �������� �����
            levelButtons[i].interactable = true; // ������ ������ ��������
        }
        else
        {
            locks[i].SetActive(true); // ���������� �����
            levelButtons[i].interactable = false; // ������ ������ ����������
        }
    }
    }

    public void LevelCompleted(int levelIndex)
    {
        // ����������� ������� ���������� �������
        int levelsCompleted = PlayerPrefs.GetInt("LevelsCompleted", 0);
        if (levelIndex > levelsCompleted)
        {
            PlayerPrefs.SetInt("LevelsCompleted", levelIndex);
            PlayerPrefs.Save();
            Start(); // ��������� ��������� �������
        }
    }
}
