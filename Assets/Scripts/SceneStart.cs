using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public Transform spawnLocation;

    void Start()
    {
        if (SpawnManager.Instance != null)
        {
            SpawnManager.Instance.SpawnPlayer(spawnLocation);
        }
    }
}

