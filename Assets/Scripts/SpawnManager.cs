using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

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
        player.transform.position = spawnLocation.position;
        player.transform.rotation = spawnLocation.rotation;
    }
}

