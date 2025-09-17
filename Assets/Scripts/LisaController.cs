using UnityEngine;

public class LisaController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // ��������� ��� ��������� �������

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("BlockValue") != 1) // ���������, ��� ������ - �����
        {
            spriteRenderer.sortingOrder = 3; // ������ ������� ��������� (������ - ����)
            PlayerController.HP -= 1;
            Vector3 direction = (other.transform.position - transform.position).normalized; // ������� ����������� � ������
            transform.position += direction * 0.5f; // ���������� ���� � ������ �� 1 �������
            AudioManager.Instance.PlaySFX(5);
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
