using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Load : MonoBehaviour
{
    public Image[] loadingImages; // Массив UI-элементов Image
    public Sprite[] grainSprites; // Массив спрайтов с изображениями зерна
    public float animationSpeed = 0.5f; // Скорость смены изображений

    private int currentSpriteIndex = 0;
    
    private void Start()
    {
        StartCoroutine(AnimateLoading());
    }

    private IEnumerator AnimateLoading() // Здесь используется просто IEnumerator
    {
        while (true)
        {
            // Обновляем все изображения
            for (int i = 0; i < loadingImages.Length; i++)
            {
                loadingImages[i].sprite = grainSprites[(currentSpriteIndex + i) % grainSprites.Length];
            }

            // Переходим к следующему изображению
            currentSpriteIndex = (currentSpriteIndex + 1) % grainSprites.Length;

            // Ждем перед следующей сменой
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}
