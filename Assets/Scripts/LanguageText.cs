using UnityEngine;
using TMPro;

public class LanguageText : MonoBehaviour
{
    public int language; // ������ �����
    public string[] text; // ������ ������� �� ������ ������
    private TMP_Text textLine; // ��������� TMP_Text

    // Start is called before the first frame update
    void Start()
    {
        language = PlayerPrefs.GetInt("Language", language);
        textLine = GetComponent<TMP_Text>(); // �������� ��������� TMP_Text
    }

    // ����� ��� ���������� ������
    public void Update()
    {
        language = PlayerPrefs.GetInt("Language", language);
        textLine.text = text[language]; // ��������� ����� �� ������ ���������� �����
    }
}
