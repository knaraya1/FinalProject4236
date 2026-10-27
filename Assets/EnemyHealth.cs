using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject Manager;
    public GameObject prefabToSpawn;   // The object you want to spawn
    public Transform spawnPoint;
    public Transform enemyTransform;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth < 1f)
        {
            Destroy(gameObject);
            Die();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a player bullet
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(1f); // subtract 20 health (change as needed)

            // Destroy the bullet so it doesn't hit multiple times
            
        }
    }

    void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy Health: " + currentHealth);

        
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        

        SimpleSpawner i = Manager.GetComponent<SimpleSpawner>();
        Vector3 pos = spawnPoint.position;
        
            Instantiate(
                prefabToSpawn,
                pos,
                Quaternion.Euler(
                    90f,
                    enemyTransform.eulerAngles.y,
                    enemyTransform.eulerAngles.z
                )
            );
        
    }
}
