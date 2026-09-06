using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float objcurrentHealth;
    public GameObject cylinder1;
    public GameObject cylinder2;
    public GameObject cylinder3;
    public GameObject cylinder4;
    
    void Start()
    {
        objcurrentHealth = maxHealth;
    }
    void Update()
    {
         if (objcurrentHealth > 100) 
         {
            objcurrentHealth = 100;
         }
        
        cylinder1.GetComponent<ColorChanger>().value = (objcurrentHealth/100);



        cylinder2.GetComponent<ColorChanger>().value = ((objcurrentHealth/100)+0.25f);



        cylinder3.GetComponent<ColorChanger>().value = ((objcurrentHealth/100)+0.5f);


        cylinder4.GetComponent<ColorChanger>().value = ((objcurrentHealth/100)+0.75f);

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " + other.gameObject.name);
        if (other.CompareTag("PlayerBullet")) {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("obj taking damage");
        
        objcurrentHealth -= amount;
        Debug.Log(gameObject.name + " Health: " + objcurrentHealth);

        if (objcurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " died!");
        Destroy(gameObject);
    }
}
