using UnityEngine;

public class PigController: MonoBehaviour
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
        if (other.CompareTag("Player")) // Проверяем, что объект - игрок
        {
            spriteRenderer.sprite = attackingSprite; // Меняем спрайт на атакующий
            Vector3 direction = (other.transform.position - transform.position).normalized; // Находим направление к игроку
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
