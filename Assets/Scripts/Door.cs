using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad; // �����, ������� ����� ��������� ��� ������������� �����
    public string spawnPointName; // ��� ����� ������ � ������� �����
    private bool isPlayerInTrigger = false;

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            UseDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            // ����� ����� �������� ������ ��� UI-���������
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            // ����� ����� ������ UI-���������
        }
    }

    private void UseDoor()
    {
        // ��������� ���������� � �����, ������� ���������� �����
        PlayerPrefs.SetString("LastDoorUsed", spawnPointName);
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        // ������������� �� ������� �������� �����
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ������������ �� �������
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // �������� ����� ������ �� ����� �����
        GameObject spawnPoint = GameObject.Find(PlayerPrefs.GetString("LastDoorUsed"));
        if (spawnPoint != null)
        {
            Transform spawnLocation = spawnPoint.transform;
            SpawnManager.Instance.SpawnPlayer(spawnLocation);
        }
    }
}
