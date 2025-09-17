using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // Параметры анимации
    public float scaleFactor = 1.2f;  // Максимальный размер
    public float speed = 2f;           // Скорость пульсации

    private Vector3 originalScale;

    void Start()
    {
        // Сохраняем оригинальный размер объекта
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Вычисляем новый размер с использованием синусоиды
        float scale = originalScale.x + Mathf.Sin(Time.time * speed) * (scaleFactor - 1);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoneyText.Coin += 1;
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }
}
