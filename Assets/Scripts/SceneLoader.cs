using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Transform playerTransform;

    public void LoadScene(string sceneName)
    {
        SavePlayerPosition();
        SceneManager.LoadScene(sceneName);
    }

    void SavePlayerPosition()
    {
        if (SpawnManager.Instance != null)
        {
            SpawnManager.Instance.SavePosition(playerTransform.position);
        }
    }
}
