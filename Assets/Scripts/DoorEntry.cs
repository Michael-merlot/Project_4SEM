using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorEntry : MonoBehaviour
{
    public string sceneToLoad; // ��� ����� ��� ��������
    public string doorName; // ��� ����� ��� ������������� � SpawnManager

    private bool isPlayerInTrigger = false;

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            EnterDoor(sceneToLoad, doorName);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void EnterDoor(string sceneName, string doorName)
    {
        PlayerPrefs.SetString("LastDoorUsed", doorName);
        SceneManager.LoadScene(sceneName);
    }
}
