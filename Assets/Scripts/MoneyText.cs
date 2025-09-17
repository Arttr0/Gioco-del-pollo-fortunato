using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyText : MonoBehaviour
{
    public static int Coin;
    public int CoinForShop;
    public int maxCoin;
    public static int coinfinish;
    private TextMeshProUGUI text;


    void Start()
    {   
        text = GetComponent<TextMeshProUGUI>();
        maxCoin = PlayerPrefs.GetInt("maxCoin", 0);

        GameObject myGameObject = gameObject;
        if (myGameObject.name == "Текст зерна1")
        {
            CoinForShop = PlayerPrefs.GetInt("CoinForShop", 0);
            CoinForShop += Coin;
            PlayerPrefs.SetInt("CoinForShop", CoinForShop);
            Coin = 0; // Сбрасываем Coin при старте сцены
            Debug.Log("Сброс коин");
        }
    }

    void Update()
    {
        text.text = Coin.ToString();
        if (Coin > maxCoin) // Изменение на > вместо <=
        {
            maxCoin = Coin;
            PlayerPrefs.SetInt("maxCoin", maxCoin);
            PlayerPrefs.Save(); // Сохраняем данные
        }
    }
}
