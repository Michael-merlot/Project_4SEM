using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    private Vector3 lastPosition;
    private bool hasSavedPosition = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (hasSavedPosition)
        {
            player.transform.position = lastPosition;
            hasSavedPosition = false;
        }
        else
        {
            player.transform.position = spawnLocation.position;
            player.transform.rotation = spawnLocation.rotation;
        }
    }

    public void SavePosition(Vector3 position)
    {
        lastPosition = position;
        hasSavedPosition = true;
    }
}
