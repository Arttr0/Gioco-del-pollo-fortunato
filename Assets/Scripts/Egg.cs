using UnityEngine;

public class Egg : MonoBehaviour
{
    public int sceneIndex; // Индекс текущей сцены
    public float liftSpeed = 2f; // Скорость подъёма
    public float liftDuration = 0.3f; // Время подъёма (уменьшено для большей скорости)
    public float liftHeight = 1.5f; // Высота подъема

    void Start()
    {
        // Проверяем, было ли яйцо собрано
        if (PlayerPrefs.GetInt("EggCollected" + sceneIndex, 0) == 1)
        {
            gameObject.SetActive(false); // Скрываем яйцо, если собрано
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем на тег игрока
        {
            CollectEgg();
        }
    }

    void CollectEgg()
    {
        // Запускаем подъем яйца перед его отключением
        StartCoroutine(LiftAndDeactivate());
    }

    System.Collections.IEnumerator LiftAndDeactivate()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < liftDuration)
        {
            transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up * liftHeight, elapsedTime / liftDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Ждем следующего кадра
        }

        // Убираем яйцо из сцены
        PlayerPrefs.SetInt("EggCollected" + sceneIndex, 1);
        int totalEggsCollected = PlayerPrefs.GetInt("TotalEggsCollected", 0);
        totalEggsCollected++;
        PlayerPrefs.SetInt("TotalEggsCollected", totalEggsCollected);
        PlayerPrefs.Save(); // Сохраняем изменения

        gameObject.SetActive(false); // Отключаем яйцо
    }
}
