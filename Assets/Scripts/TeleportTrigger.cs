using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportTrigger : MonoBehaviour
{
    public string sceneToLoad; // Сцена для загрузки
    public GameObject teleportMessage; // Сообщение о телепортации

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Показываем сообщение
            teleportMessage.SetActive(true);
            // Загружаем сцену
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
