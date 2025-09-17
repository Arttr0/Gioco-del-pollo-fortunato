using UnityEngine;

public class Egg : MonoBehaviour
{
    public int sceneIndex; // ������ ������� �����
    public float liftSpeed = 2f; // �������� �������
    public float liftDuration = 0.3f; // ����� ������� (��������� ��� ������� ��������)
    public float liftHeight = 1.5f; // ������ �������

    void Start()
    {
        // ���������, ���� �� ���� �������
        if (PlayerPrefs.GetInt("EggCollected" + sceneIndex, 0) == 1)
        {
            gameObject.SetActive(false); // �������� ����, ���� �������
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ��������� �� ��� ������
        {
            CollectEgg();
        }
    }

    void CollectEgg()
    {
        // ��������� ������ ���� ����� ��� �����������
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
            yield return null; // ���� ���������� �����
        }

        // ������� ���� �� �����
        PlayerPrefs.SetInt("EggCollected" + sceneIndex, 1);
        int totalEggsCollected = PlayerPrefs.GetInt("TotalEggsCollected", 0);
        totalEggsCollected++;
        PlayerPrefs.SetInt("TotalEggsCollected", totalEggsCollected);
        PlayerPrefs.Save(); // ��������� ���������

        gameObject.SetActive(false); // ��������� ����
    }
}
