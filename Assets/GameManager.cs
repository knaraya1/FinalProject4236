using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawn2;   // The object/prefab you want to spawn
    public Transform[] spawnPoints;
    public int numEnemies1;
    public int numStars;


    public float delayTime = 01f;      // time before the action runs
    public float cooldownTime = 0.01f;   // time before it can run again

    private bool onCooldown = false;
           // Where it should appear

    void Start()
    {
        SpawnObject();
        SpawnObject();
        SpawnObject();
        SpawnObject();
        
        
    }

    void Update()
    {
        CallWithDelay();
        
    }

    void SpawnObject()
    {
        // Generate a random number between 0 and the number of spawn points
        int index = Random.Range(0, spawnPoints.Length);
        int index2 = Random.Range(0, 4);
        // Spawn the prefab at the chosen location
        if (index2 <= 1) 
        {
            Instantiate(prefabToSpawn, spawnPoints[index].position, spawnPoints[index].rotation);
        }
        else 
        {
            Instantiate(prefabToSpawn2, spawnPoints[index].position, spawnPoints[index].rotation);
        }
        numEnemies1 += 1;
        Debug.Log("Spawned. numenemies1: " + numEnemies1);
    }
    public void CallWithDelay()
    {
        if (!onCooldown)
        {
            StartCoroutine(RunAfterDelay());
        }
    }

    IEnumerator RunAfterDelay()
    {
        onCooldown = true;

        // Wait before executing the command
        yield return new WaitForSeconds(delayTime);
        Debug.Log("numenemies1: " + numEnemies1);

        if (numEnemies1 <= 10) {
            SpawnObject();
        }

        // Wait for cooldown
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}
