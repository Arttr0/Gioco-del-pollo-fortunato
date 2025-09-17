using UnityEngine;

public class PigController: MonoBehaviour
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
        if (other.CompareTag("Player")) // ���������, ��� ������ - �����
        {
            spriteRenderer.sprite = attackingSprite; // ������ ������ �� ���������
            Vector3 direction = (other.transform.position - transform.position).normalized; // ������� ����������� � ������
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
