using UnityEngine;

public class CatController : MonoBehaviour
{
    public Sprite standingSprite; // ������ �������� ����
    public Sprite attackingSprite; // ������ ���������� ����
    private SpriteRenderer spriteRenderer; // ��������� ��� ��������� �������

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standingSprite; // ������������� ��������� ������
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("BlockValue") != 1) // ���������, ��� ������ - �����
        {
            spriteRenderer.sprite = attackingSprite; // ������ ������ �� ���������
            PlayerController.HP -= 1;
            Vector3 direction = (other.transform.position - transform.position).normalized; // ������� ����������� � ������
            transform.position += direction * 1f; // ���������� ���� � ������ �� 0.5 �������
            AudioManager.Instance.PlaySFX(3);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = standingSprite; // ���������� ������ �������� ����, ����� ����� ������
        }
    }
}
