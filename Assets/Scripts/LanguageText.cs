using UnityEngine;
using TMPro;

public class LanguageText : MonoBehaviour
{
    public int language; // Индекс языка
    public string[] text; // Массив текстов на разных языках
    private TMP_Text textLine; // Компонент TMP_Text

    // Start is called before the first frame update
    void Start()
    {
        language = PlayerPrefs.GetInt("Language", language);
        textLine = GetComponent<TMP_Text>(); // Получаем компонент TMP_Text
    }

    // Метод для обновления текста
    public void Update()
    {
        language = PlayerPrefs.GetInt("Language", language);
        textLine.text = text[language]; // Обновляем текст на основе выбранного языка
    }
}
