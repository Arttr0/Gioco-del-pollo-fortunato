using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class MainMenu : MonoBehaviour
{
    public GameObject Levels;
    public GameObject Settings;
    public GameObject Shop;
    public GameObject Achievements;
    public GameObject Leaderboard;
    public int[] skinPrices; // Массив с ценами для каждого скина
    public int CoinForShop;
    public TextMeshProUGUI CoinForShoptext;
    public Button Achivka1;
    public Button Achivka2;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Achivka1")==1) {
            Achivka1.interactable = true;
        }
        if (PlayerPrefs.GetInt("TotalEggsCollected") >= 10)
        {
            Achivka2.interactable = true;
        }
        // Можно скрыть все панели в начале, если это необходимо
        HideAllPanels();
        CoinForShop = PlayerPrefs.GetInt("CoinForShop", 0);
        CoinForShoptext.text = CoinForShop.ToString();
    }


    public void OnSkinButtonClicked(int skinIndex)
    {

        if (skinIndex >= 0 && skinIndex < skinPrices.Length)
        {
            int skinPrice = skinPrices[skinIndex];

            if (CoinForShop >= skinPrice)
            {
                ButtonSound();
                CoinForShop -= skinPrice;
                PlayerPrefs.SetInt("CoinForShop", CoinForShop);
                PlayerPrefs.SetInt("PlayerSkin", skinIndex);
                PlayerPrefs.Save();
                CoinForShoptext.text = CoinForShop.ToString();

                Debug.Log("Button " + skinIndex + " clicked. Skin purchased!");
            }
            else
            {
                Debug.Log("Not enough coins to purchase skin " + skinIndex);
            }
        }
        else
        {
            Debug.LogError("Invalid skin index: " + skinIndex);
        }
    }

    public void PokypkaFastSpeed() {
        if (CoinForShop >= 5f)
        {
            CoinForShop -= 5;
            PlayerPrefs.SetInt("CoinForShop", CoinForShop);
            PlayerPrefs.SetInt("PokypkaFastSpeed", 1);
            PlayerPrefs.Save();
            CoinForShoptext.text = CoinForShop.ToString();
            ButtonSound();
            Debug.Log("куплено ускорение");
        }
    }

    public void PokypkaSkorlypa()
    {
        if (CoinForShop >= 5f)
        {
            CoinForShop -= 5;
            PlayerPrefs.SetInt("CoinForShop", CoinForShop);
            PlayerPrefs.SetInt("PokypkaSkorlypa", 1);
            PlayerPrefs.Save();
            CoinForShoptext.text = CoinForShop.ToString();
            Debug.Log("куплено скорлупа");
            ButtonSound();
        }
    }

    public void ShowPanel(GameObject panel)
    {
        HideAllPanels(); // Скрыть все панели перед показом новой
        panel.SetActive(true); // Активировать переданную панель
        ButtonSound();
    }

    public void HideAllPanels()
    {
        Levels.SetActive(false);
        Settings.SetActive(false);
        Shop.SetActive(false);
        Achievements.SetActive(false);
        Leaderboard.SetActive(false);
    }

    public void ShowAllPanels()
    {
        Levels.SetActive(true);
        Settings.SetActive(true);
        Shop.SetActive(true);
        Achievements.SetActive(true);
        Leaderboard.SetActive(true);
    }

    public void Exit() {
        Application.Quit();
    }

    public void ButtonSound()
    {
        AudioManager.Instance.PlaySFX(0); // Воспроизводит первый звук
    }

    // Update is called once per frame
    void Update()
    {

    }
}
