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
         if (objcurrentHealth > 100f) 
         {
            objcurrentHealth = 100f;
         }
        
        float cyl1 = cylinder1.GetComponent<ColorChanger>().value = (objcurrentHealth/100f);


        if (objcurrentHealth > 75f) 
        {
            cylinder2.GetComponent<ColorChanger>().value = ((cyl1 - 0.25f));
        }


        if (objcurrentHealth > 50f)
        {
            cylinder3.GetComponent<ColorChanger>().value = ((cyl1 - 0.5f));
        }

        if (objcurrentHealth > 25f)
        {
            cylinder4.GetComponent<ColorChanger>().value = ((cyl1 - 0.75f));
        }
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

        if (objcurrentHealth <= 0f)
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
