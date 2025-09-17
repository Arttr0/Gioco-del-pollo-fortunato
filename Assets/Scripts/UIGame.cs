using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIGame : MonoBehaviour
{
    public GameObject PanelPause;
    public GameObject PanelFinish;
    public GameObject PanelLose;
    public TextMeshProUGUI NomerLvl;
    private PlayerController playerController;
    public int numOfhp;
    public Image[] hearts;
    public Sprite fullhp;
    public Sprite emptyhp;
    public Button PokypkaFastSpeed;
    public Button PokypkaSkorlypa;
    public GameObject PanelSettings;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        HideAllPanels();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        NomerLvl.text = currentSceneIndex.ToString();
        playerController = FindAnyObjectByType<PlayerController>();
        if (PlayerPrefs.GetInt("PokypkaFastSpeed") > 0)
        {
            PokypkaFastSpeed.interactable = true;
        }
        else {
            PokypkaFastSpeed.interactable = false;
        }
        if (PlayerPrefs.GetInt("PokypkaSkorlypa") > 0)
        {
            PokypkaSkorlypa.interactable = true;
        }
        else
        {
            PokypkaSkorlypa.interactable = false;
        }
    }

    private void FixedUpdate()
    {
        if (PlayerController.HP > numOfhp) {
            PlayerController.HP = numOfhp;
        }
        for (int i = 0; i<hearts.Length; i++) {
            if (i < Mathf.RoundToInt(PlayerController.HP))
            {
                hearts[i].sprite = fullhp;
            }
            else {
                hearts[i].sprite = emptyhp;
            }
            if (i < numOfhp)
            {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
    }

    public void Jump()
    {
        playerController.Jump();
    }

    public void Left()
    {
        playerController.Left();
    }

    public void Right()
    {
        playerController.Right();
    }

    public void Buttonup()
    {
        playerController.Buttonup();
    }

    public void Down()
    {
        playerController.Down();
    }


    public void SpeedBoostButtonPressed()
    {
        playerController.SpeedBoostButtonPressed();
    }

    public void scorlypaOn() {
        playerController.scorlypaOn();
    }

    public void ShowPanel(GameObject panel)
    {
        HideAllPanels(); // Скрыть все панели перед показом новой
        panel.SetActive(true); // Активировать переданную панель
        Time.timeScale = 0f;
        AudioManager.Instance.PlaySFX(0);
    }

    public void HideAllPanels()
    {
        PanelFinish.SetActive(false);
        PanelLose.SetActive(false);
        PanelPause.SetActive(false);
        PanelSettings.SetActive(false);
        AudioManager.Instance.PlaySFX(0);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        AudioManager.Instance.PlaySFX(0);
        SceneManager.LoadScene("MainMenu");
    }

    public void restart() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        AudioManager.Instance.PlaySFX(0);
    }

    public void NextLvl()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("Это последняя сцена. Нет следующей сцены для загрузки.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
