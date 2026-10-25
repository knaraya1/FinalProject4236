using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public float cooldownTime = 01f;   // time before it can run again

    private bool onCooldown = false;
    public GameObject[] enemies;
    public GameObject managerobj;
    public EndGame scr;
    //public int numEnemies1;
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
        scr = managerobj.GetComponent<EndGame>();
        CallWithDelay();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //GameObject[] enemies2 = GameObject.FindGameObjectWithTag("")
        numEnemies1 = enemies.Length;

        //
        
    }

    void SpawnObject()
    {
        if (scr.isGameEnding == false) 
        {
            Debug.Log("numenemies1: " + numEnemies1);
            
            // Generate a random number between 0 and the number of spawn points
            int index = Random.Range(0, spawnPoints.Length);
            float index2 = Random.Range(0f, 4f);
            // Spawn the prefab at the chosen location
            if (index2 <= 2f) 
            {
            // Debug.Log(index2);
                //Instantiate(prefabToSpawn, spawnPoints[index].position, spawnPoints[index].rotation);

                List<int> freeLocations = new List<int>();

                for (int i = 0; i < locations.Length; i++)
                {
                    if (locations[i].active)
                    {
                        freeLocations.Add(i);
                    }
                }

                if (freeLocations.Count > 0)
                {
                    int randomIndex = Random.Range(0, freeLocations.Count);
                    int locationIndex = freeLocations[randomIndex];

                    Debug.Log("Using spawn point: " + locations[locationIndex].spawnPoint.name);

                    Instantiate(
                        prefabToSpawn,
                        locations[locationIndex].spawnPoint.position,
                        locations[locationIndex].spawnPoint.rotation
                    );
                }
            }
            else 
            {
                List<int> freeLocations = new List<int>();

                for (int i = 0; i < locations.Length; i++)
                {
                    if (locations[i].active)
                    {
                        freeLocations.Add(i);
                    }
                }

                if (freeLocations.Count > 0)
                {
                    int randomIndex = Random.Range(0, freeLocations.Count);
                    int locationIndex = freeLocations[randomIndex];

                    Debug.Log("Using spawn point: " + locations[locationIndex].spawnPoint.name);

                    Instantiate(
                        prefabToSpawn2,
                        locations[locationIndex].spawnPoint.position,
                        locations[locationIndex].spawnPoint.rotation
                    );
                }
            }
        }

        //numEnemies1 += 1;
        
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
