using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    public GameObject Manager;
    public GameObject prefabToSpawn;   // The object you want to spawn
    public Transform spawnPoint;
    public Transform enemyTransform;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a player bullet
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(20); // subtract 20 health (change as needed)

            // Destroy the bullet so it doesn't hit multiple times
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        

        SimpleSpawner i = Manager.GetComponent<SimpleSpawner>();
        i.numEnemies1 -= 1;
        Vector3 pos = spawnPoint.position;
        pos.y = 5.5f;

        Instantiate(prefabToSpawn, pos, enemyTransform.rotation);
        Destroy(gameObject);
        //i.numStars += 1;
    }
}
