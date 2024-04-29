using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad; // Сцена, которая будет загружена при использовании двери
    public string spawnPointName; // Имя точки спавна в целевой сцене
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
            // Здесь можно добавить логику для UI-подсказки
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            // Здесь можно скрыть UI-подсказку
        }
    }

    private void UseDoor()
    {
        // Сохраняем информацию о двери, которую использует игрок
        PlayerPrefs.SetString("LastDoorUsed", spawnPointName);
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        // Подписываемся на событие загрузки сцены
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Отписываемся от события
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Получаем точку спавна на новой сцене
        GameObject spawnPoint = GameObject.Find(PlayerPrefs.GetString("LastDoorUsed"));
        if (spawnPoint != null)
        {
            Transform spawnLocation = spawnPoint.transform;
            SpawnManager.Instance.SpawnPlayer(spawnLocation);
        }
    }
}
