using UnityEngine;

public class PeopleController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // ��������� ��� ��������� �������
    public Transform objectAttachedToCamera; // ������, ����������� � ������
    public float offsetX = 1.0f; // ����� �� ��� X
    public float speed = 3; // �������� �����������
    public float startX = -10f; // ��������� ������� �� X
    public float endX = 17f; // �������� ������� �� X
    private bool movingToEnd = true; // ����, ����������� ����������� ��������

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
        // ������������� ��������� �������
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        // �������� ������� �������
        Vector3 currentPosition = transform.position;

        // ���������� ����� �������� �� ��� X
        float newX = Mathf.MoveTowards(currentPosition.x, movingToEnd ? endX : startX, speed * Time.deltaTime);

        // ������������� ����� �������
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);

        // ���������, �������� �� �� �������� �����
        if (Mathf.Approximately(newX, endX))
        {
            movingToEnd = false; // ������ �����������
        }
        else if (Mathf.Approximately(newX, startX))
        {
            movingToEnd = true; // ������ �����������
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("BlockValue") != 1) // ���������, ��� ������ - �����
        {
            spriteRenderer.sortingOrder = 3; // ������ ������� ��������� (������ - ����)
            PlayerController.HP -= 3;
            AudioManager.Instance.PlaySFX(5);
            Time.timeScale = 0f;
            // ������������� ����� ������� � ����� ������ � ������ offsetX
            Vector3 cameraCenter = Camera.main.transform.position; // �������� ������� ������
            objectAttachedToCamera.position = new Vector3(cameraCenter.x + offsetX, cameraCenter.y, objectAttachedToCamera.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sortingOrder = 1; // ���������� ������� ��������� � ���������
        }
    }
}
