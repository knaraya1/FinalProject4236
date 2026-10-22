using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawn2;   // The object/prefab you want to spawn
    public Transform[] spawnPoints;
    public int numEnemies1;
    public int numStars;
    public bool Loc1LOS;
    public bool Loc2LOS;
    public bool Loc3LOS;
    public bool Loc4LOS;

    [System.Serializable]
    public class SpawnLocation
    {
        public bool active;
        public Transform spawnPoint;
    }

    public SpawnLocation[] locations;


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
        Debug.Log("numenemies1: " + numEnemies1);
        // Generate a random number between 0 and the number of spawn points
        int index = Random.Range(0, spawnPoints.Length);
        float index2 = Random.Range(0f, 4f);
        // Spawn the prefab at the chosen location
        if (index2 <= 2.5f) 
        {
            Debug.Log(index2);
            //Instantiate(prefabToSpawn, spawnPoints[index].position, spawnPoints[index].rotation);

            for (int i = 0; i < locations.Length; i++)
            {
                if (locations[i].active)
                {
                    Debug.Log("Using spawn point: " + locations[i].spawnPoint.name);
                    numEnemies1 += 1;
                    //Debug.Log("Spawned. numenemies1: " + numEnemies1);
                    Instantiate(prefabToSpawn, locations[i].spawnPoint.position, spawnPoints[index].rotation);
                }
            }
        }
        else 
        {
            //Instantiate(prefabToSpawn2, spawnPoints[index].position, spawnPoints[index].rotation);
            for (int i = 0; i < locations.Length; i++)
            {
                if (locations[i].active)
                {
                    Debug.Log("Using spawn point: " + locations[i].spawnPoint.name);
                    numEnemies1 += 1;
                    //Debug.Log("Spawned. numenemies1: " + numEnemies1);
                    Instantiate(prefabToSpawn2, locations[i].spawnPoint.position, spawnPoints[index].rotation);
                }
            }
        }
        
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
        

        if (numEnemies1 <= 10) {
            SpawnObject();
        }

        // Wait for cooldown
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}
