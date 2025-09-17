using UnityEngine;

public class YamaController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // ��������� ��� ��������� �������

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("BlockValue") != 1) // ���������, ��� ������ - �����
        {
            spriteRenderer.sortingOrder = 3; // ������ ������� ��������� (������ - ����)
            PlayerController.HP -= 1;
            AudioManager.Instance.PlaySFX(5);
        }
    }
}
