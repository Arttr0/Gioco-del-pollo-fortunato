using UnityEngine;
using Cinemachine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] playerSkins; // ������ �������� ������ ������
    public CinemachineVirtualCamera virtualCamera; // ������ �� ����������� ������

    private void Awake()
    {
        int skinIndex = PlayerPrefs.GetInt("PlayerSkin", 0);
        if (skinIndex >= 0 && skinIndex < playerSkins.Length)
        {
            GameObject playerObject = Instantiate(playerSkins[skinIndex], transform.position, Quaternion.identity);

            // ����������� ����������� ������ � ������
            virtualCamera.Follow = playerObject.transform;
        }
        else
        {
            Debug.LogError("Invalid skin index: " + skinIndex);
        }
    }

    public void SetPlayerSkin(int index)
    {
        PlayerPrefs.SetInt("PlayerSkin", index);
        PlayerPrefs.Save();
    }
}