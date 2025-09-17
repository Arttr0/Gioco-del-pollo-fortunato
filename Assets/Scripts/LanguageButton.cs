using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    public Button languageButton;
    public TMP_Text buttonText; // Изменяем тип на TMP_Text

    private string[] languages = { "English", "French", "Italian", "Spanish" };
    private int currentLanguage;

    // Пример массивов для других текстов на сцене
    private string[][] allTexts = {
    new string[] {
        "Save",
        "Music",
        "Sounds",
        "Control",
        "Play",
        "Achievements",
        "Leaderboards",
        "Exit",
        "Buy",
        "Fast Feather",
        "Complete the level without getting caught by any enemy and without falling into traps.",
        "GOLDEN EGG COLLECTOR",
        "Find all 10 golden eggs in the levels and prove that you are the best treasure hunter!",
        "Received"
    },  // English
    new string[] {
        "Sauvegarder",
        "Musique",
        "Sons",
        "Contrôle",
        "Jouer",
        "Réalisations",
        "Classements",
        "Sortir",
        "Acheter",
        "Plume Rapide",
        "Complétez le niveau sans vous faire attraper par un ennemi et sans tomber dans des pièges.",
        "COLLECTEUR D'OEUFS D'OR",
        "Trouvez tous les 10 œufs d'or dans les niveaux et prouvez que vous êtes le meilleur chasseur de trésors !",
        "Reçu"
    }, // French
    new string[] {
        "Salvare",
        "Musica",
        "Suoni",
        "Controllo",
        "Gioca",
        "Traguardi",
        "Classifiche",
        "Uscita",
        "Comprare",
        "Piuma Veloce",
        "Completa il livello senza essere catturato da nemici e senza cadere in trappole.",
        "COLLEZIONISTA DI UOVA D'ORO",
        "Trova tutte le 10 uova d'oro nei livelli e dimostra di essere il miglior cacciatore di tesori!",
        "Ricevuto"
    }, // Italian
    new string[] {
        "Guardar",
        "Música",
        "Sonidos",
        "Control",
        "Jugar",
        "Logros",
        "Clasificaciones",
        "Salir",
        "Comprar",
        "Pluma Rápida",
        "Completa el nivel sin ser atrapado por ningún enemigo y sin caer en trampas.",
        "COLECTOR DE HUEVOS DE ORO",
        "Encuentra todos los 10 huevos de oro en los niveles y demuestra que eres el mejor cazador de tesoros.",
        "Recibido"
    }  // Spanish
};




    void Start()
    {
        // Загружаем сохраненный язык, если он существует
        currentLanguage = PlayerPrefs.GetInt("Language", 0);
        UpdateButtonText();
        UpdateAllText();

        languageButton.onClick.AddListener(ChangeLanguage);
    }

    void ChangeLanguage()
    {
        currentLanguage++;
        if (currentLanguage >= languages.Length)
        {
            currentLanguage = 0;
        }

        // Сохраняем текущий язык
        PlayerPrefs.SetInt("Language", currentLanguage);
        PlayerPrefs.Save();

        UpdateButtonText();
        UpdateAllText(); // Обновляем текст на сцене
    }

    void UpdateButtonText()
    {
        buttonText.text = languages[currentLanguage]; // Обновляем текст кнопки
    }

    void UpdateAllText()
    {
        // Получаем все компоненты TMP_Text на сцене
        TMP_Text[] allTMPTexts = FindObjectsOfType<TMP_Text>();

        foreach (TMP_Text tmpText in allTMPTexts)
        {
            // Пример: обновляем текст в зависимости от имени компонента
            switch (tmpText.name)
            {
                case "SaveText":
                    tmpText.text = allTexts[currentLanguage][0]; // "Welcome" или его перевод
                    break;
                case "MusicText":
                    tmpText.text = allTexts[currentLanguage][1]; // "Hello" или его перевод
                    break;
                case "SoundsText":
                    tmpText.text = allTexts[currentLanguage][2]; // "Goodbye" или его перевод
                    break;
                case "ControlText":
                    tmpText.text = allTexts[currentLanguage][3]; // "Goodbye" или его перевод
                    break;
                case "PlayText":
                    tmpText.text = allTexts[currentLanguage][4]; // "Goodbye" или его перевод
                    break;
                case "AchievementsText":
                    tmpText.text = allTexts[currentLanguage][5]; // "Goodbye" или его перевод
                    break;
                case "LeaderboardsText":
                    tmpText.text = allTexts[currentLanguage][6]; // "Goodbye" или его перевод
                    break;
                case "ExitText":
                    tmpText.text = allTexts[currentLanguage][7]; // "Goodbye" или его перевод
                    break;
                case "BuyText":
                    tmpText.text = allTexts[currentLanguage][8]; // "Goodbye" или его перевод
                    break;
                case "FastFeathersText":
                    tmpText.text = allTexts[currentLanguage][9]; // "Goodbye" или его перевод
                    break;
                case "Achivka1Text":
                    tmpText.text = allTexts[currentLanguage][10]; // "Goodbye" или его перевод
                    break;
                case "GOLDENEGGCOLLECTORText":
                    tmpText.text = allTexts[currentLanguage][11]; // "Goodbye" или его перевод
                    break;
                case "Achivka2Text":
                    tmpText.text = allTexts[currentLanguage][12]; // "Goodbye" или его перевод
                    break;
                //case "ReceivedText":
                 //   tmpText.text = allTexts[currentLanguage][13]; // "Goodbye" или его перевод
                 //   break;
                    // Добавьте другие случаи для других текстов
            }
        }
    }
}
