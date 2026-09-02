using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;   // The object/prefab you want to spawn
    public Transform[] spawnPoints;
           // Where it should appear

    void Start()
    {
        SpawnObject();
    }

    void Update()
    {
    
    }

    void SpawnObject()
    {
        // Generate a random number between 0 and the number of spawn points
        int index = Random.Range(0, spawnPoints.Length);

        // Spawn the prefab at the chosen location
        Instantiate(prefabToSpawn, spawnPoints[index].position, spawnPoints[index].rotation);
    }
}
