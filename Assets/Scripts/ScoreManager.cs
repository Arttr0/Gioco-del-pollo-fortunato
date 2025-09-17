using UnityEngine;
using TMPro; // Не забудь подключить пространство имен для TextMeshPro
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text[] nameFields; // Массив текстовых полей для имен
    public TMP_Text[] scoreFields; // Массив текстовых полей для чисел
    public GameObject panel; // Панель, которую нужно отслеживать

    private string[][] robotNames = {
        new string[] { "Botron", "Master", "RoboX", "Circuitron", "Gizmo", "Tasher228", "You" }, // Английский
        new string[] { "Botron", "Maître", "RoboX", "Circuitron", "Gizmo", "Tasher228", "Vous" }, // Французский
        new string[] { "Botron", "Maestro", "RoboX", "Circuitron", "Gizmo", "Tasher228", "Tu" }, // Итальянский
        new string[] { "Botron", "Maestro", "RoboX", "Circuitron", "Gizmo", "Tasher228", "Tú" }  // Испанский
    };

    private int[] robotScores = { 10, 25, 37, 42, 70, 90 }; // Значения для роботов
    private int maxCoin;
    private int currentLanguage;

    void Start()
    {
        maxCoin = PlayerPrefs.GetInt("CoinForShop", 0);
        currentLanguage = PlayerPrefs.GetInt("Language", 0); // Получаем значение языка (0 - английский)

        UpdateScoreText();
    }

    void Update()
    {
        if (panel.activeSelf) // Если панель открыта
        {
            currentLanguage = PlayerPrefs.GetInt("Language", 0);
            UpdateScoreText(); // Обновляем текст
        }
    }

    private void UpdateScoreText()
    {
        // Создаем список для имен и очков
        List<NameScore> nameScores = new List<NameScore>();

        // Заполняем список значениями роботов
        for (int i = 0; i < robotNames[currentLanguage].Length - 1; i++) // Для роботов
        {
            nameScores.Add(new NameScore(robotNames[currentLanguage][i], robotScores[i]));
        }

        // Добавляем игрока с его очками
        nameScores.Add(new NameScore(robotNames[currentLanguage][6], maxCoin));

        // Сортируем список по убыванию очков
        nameScores.Sort((x, y) => y.score.CompareTo(x.score));

        // Обновляем текстовые поля
        for (int i = 0; i < nameScores.Count; i++)
        {
            nameFields[i].text = nameScores[i].name;
            scoreFields[i].text = nameScores[i].score.ToString();
        }
    }

    [System.Serializable]
    public class NameScore
    {
        public string name;
        public int score;

        public NameScore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}
