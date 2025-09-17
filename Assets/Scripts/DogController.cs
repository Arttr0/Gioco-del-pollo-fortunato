using UnityEngine;

public class DogController : MonoBehaviour
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
            PlayerController.HP += 1;
            Vector3 direction = (other.transform.position - transform.position).normalized; // ������� ����������� � ������
            AudioManager.Instance.PlaySFX(6);
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
