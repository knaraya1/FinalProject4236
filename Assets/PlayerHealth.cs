using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public PlayerController scr;
    public GameObject targetobj1;
    public GameObject targetobj2;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the thing we collided with is an enemy bullet
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(20f); // subtract 20 health (change as needed)

            // Destroy the bullet so it doesn't hit multiple times
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        scr.canMove = false;
        targetobj1.SetActive(true);
        targetobj2.SetActive(false);

        StartCooldown();
        
    }

    public void StartCooldown()
    {
        StartCoroutine(RunAfterFiveSeconds());
    }

    IEnumerator RunAfterFiveSeconds()
    {
        yield return new WaitForSeconds(5f);

        // Code that runs after 5 seconds
        Destroy(gameObject);
        SceneManager.LoadScene("TitleScreen");
        Debug.Log("5 seconds passed — action executed!");
    }
}
