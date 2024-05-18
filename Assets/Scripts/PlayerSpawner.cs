using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform defaultSpawnLocation;

    void Start()
    {
        if (SpawnManager.Instance != null)
        {
            SpawnManager.Instance.SpawnPlayer(defaultSpawnLocation);
        }
    }
}
