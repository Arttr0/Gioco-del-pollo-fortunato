using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Load : MonoBehaviour
{
    public Image[] loadingImages; // ������ UI-��������� Image
    public Sprite[] grainSprites; // ������ �������� � ������������� �����
    public float animationSpeed = 0.5f; // �������� ����� �����������

    private int currentSpriteIndex = 0;
    
    private void Start()
    {
        StartCoroutine(AnimateLoading());
    }

    private IEnumerator AnimateLoading() // ����� ������������ ������ IEnumerator
    {
        while (true)
        {
            // ��������� ��� �����������
            for (int i = 0; i < loadingImages.Length; i++)
            {
                loadingImages[i].sprite = grainSprites[(currentSpriteIndex + i) % grainSprites.Length];
            }

            // ��������� � ���������� �����������
            currentSpriteIndex = (currentSpriteIndex + 1) % grainSprites.Length;

            // ���� ����� ��������� ������
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}
