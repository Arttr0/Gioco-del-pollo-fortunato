using UnityEngine;

public class CatController : MonoBehaviour
{
    public Sprite standingSprite; // Спрайт стоящего кота
    public Sprite attackingSprite; // Спрайт атакующего кота
    private SpriteRenderer spriteRenderer; // Компонент для изменения спрайта

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standingSprite; // Устанавливаем начальный спрайт
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("BlockValue") != 1) // Проверяем, что объект - игрок
        {
            spriteRenderer.sprite = attackingSprite; // Меняем спрайт на атакующий
            PlayerController.HP -= 1;
            Vector3 direction = (other.transform.position - transform.position).normalized; // Находим направление к игроку
            transform.position += direction * 1f; // Перемещаем кота к игроку на 0.5 единицы
            AudioManager.Instance.PlaySFX(3);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = standingSprite; // Возвращаем спрайт стоящего кота, когда игрок уходит
        }
    }
}
