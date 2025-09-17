using UnityEngine;

public class YamaController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Компонент для изменения спрайта

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("BlockValue") != 1) // Проверяем, что объект - игрок
        {
            spriteRenderer.sortingOrder = 3; // Меняем порядок рисования (больше - выше)
            PlayerController.HP -= 1;
            AudioManager.Instance.PlaySFX(5);
        }
    }
}
