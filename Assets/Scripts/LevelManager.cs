using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // Массив кнопок для уровней
    public GameObject[] locks; // Массив замков для уровней

    void Start()
    {
        int levelsCompleted = PlayerPrefs.GetInt("LevelsCompleted", 0);
    
    // Обеспечить, что первый уровень всегда открыт
    if (levelsCompleted < 1)
    {
        levelsCompleted = 1;
        PlayerPrefs.SetInt("LevelsCompleted", 1);
        PlayerPrefs.Save();
    }

    // Обновить состояние кнопок и замков
    for (int i = 0; i < levelButtons.Length; i++)
    {
        if (i < levelsCompleted) // Если уровень пройден
        {
            locks[i].SetActive(false); // Скрываем замок
            levelButtons[i].interactable = true; // Делаем кнопку активной
        }
        else
        {
            locks[i].SetActive(true); // Показываем замок
            levelButtons[i].interactable = false; // Делаем кнопку неактивной
        }
    }
    }

    public void LevelCompleted(int levelIndex)
    {
        // Увеличиваем счетчик пройденных уровней
        int levelsCompleted = PlayerPrefs.GetInt("LevelsCompleted", 0);
        if (levelIndex > levelsCompleted)
        {
            PlayerPrefs.SetInt("LevelsCompleted", levelIndex);
            PlayerPrefs.Save();
            Start(); // Обновляем состояние уровней
        }
    }
}
