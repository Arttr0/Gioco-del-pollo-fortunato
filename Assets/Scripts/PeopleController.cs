using UnityEngine;

public class PeopleController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Компонент для изменения спрайта
    public Transform objectAttachedToCamera; // Объект, привязанный к камере
    public float offsetX = 1.0f; // Сдвиг по оси X
    public float speed = 3; // Скорость перемещения
    public float startX = -10f; // Начальная позиция по X
    public float endX = 17f; // Конечная позиция по X
    private bool movingToEnd = true; // Флаг, указывающий направление движения

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
        // Устанавливаем начальную позицию
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        // Получаем текущую позицию
        Vector3 currentPosition = transform.position;

        // Определяем новое значение по оси X
        float newX = Mathf.MoveTowards(currentPosition.x, movingToEnd ? endX : startX, speed * Time.deltaTime);

        // Устанавливаем новую позицию
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);

        // Проверяем, достигли ли мы конечной точки
        if (Mathf.Approximately(newX, endX))
        {
            movingToEnd = false; // Меняем направление
        }
        else if (Mathf.Approximately(newX, startX))
        {
            movingToEnd = true; // Меняем направление
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("BlockValue") != 1) // Проверяем, что объект - игрок
        {
            spriteRenderer.sortingOrder = 3; // Меняем порядок рисования (больше - выше)
            PlayerController.HP -= 3;
            AudioManager.Instance.PlaySFX(5);
            Time.timeScale = 0f;
            // Устанавливаем новую позицию в центр камеры с учетом offsetX
            Vector3 cameraCenter = Camera.main.transform.position; // Получаем позицию камеры
            objectAttachedToCamera.position = new Vector3(cameraCenter.x + offsetX, cameraCenter.y, objectAttachedToCamera.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sortingOrder = 1; // Возвращаем порядок рисования к исходному
        }
    }
}
