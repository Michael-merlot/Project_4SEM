using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportTrigger : MonoBehaviour
{
    public string sceneToLoad; // ����� ��� ��������
    public GameObject teleportMessage; // ��������� � ������������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ���������� ���������
            teleportMessage.SetActive(true);
            // ��������� �����
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
