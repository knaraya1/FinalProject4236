using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;   // The object/prefab you want to spawn
    public Transform[] spawnPoints;
    public int numEnemies1;
    public int numStars;


    public float delayTime = 2f;      // time before the action runs
    public float cooldownTime = 3f;   // time before it can run again

    private bool onCooldown = false;
           // Where it should appear

    void Start()
    {
        SpawnObject();
    }

    void Update()
    {
        CallWithDelay();
        
        if (numEnemies1 <= 3) {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Generate a random number between 0 and the number of spawn points
        int index = Random.Range(0, spawnPoints.Length);

        // Spawn the prefab at the chosen location
        Instantiate(prefabToSpawn, spawnPoints[index].position, spawnPoints[index].rotation);
        numEnemies1 += 1;
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

        // Wait for cooldown
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}
