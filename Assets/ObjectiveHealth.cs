using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float objcurrentHealth;
    public GameObject cylinder1;
    public GameObject cylinder2;
    public GameObject cylinder3;
    public GameObject cylinder4;
    public float cyl1;
    
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
        

        if (objcurrentHealth < 90f)
        {
            cylinder1.GetComponent<ColorChanger>().value = (.75f);
        }
        

        if (objcurrentHealth < 75f) 
        {
            cylinder1.GetComponent<ColorChanger>().value = (.5f);
            cylinder2.GetComponent<ColorChanger>().value = (.5f);
            cylinder3.GetComponent<ColorChanger>().value = (.75f);
            cylinder4.GetComponent<ColorChanger>().value = (.75f);
        }


        if (objcurrentHealth < 50f)
        {
            cylinder1.GetComponent<ColorChanger>().value = (.3f);
            cylinder3.GetComponent<ColorChanger>().value = (.3f);
            cylinder2.GetComponent<ColorChanger>().value = (.3f);
            cylinder4.GetComponent<ColorChanger>().value = (.5f);
        }

        if (objcurrentHealth < 25f)
        {
            cylinder1.GetComponent<ColorChanger>().value = (0f);
            cylinder3.GetComponent<ColorChanger>().value = (0f);
            cylinder2.GetComponent<ColorChanger>().value = (0f);
            cylinder4.GetComponent<ColorChanger>().value = (0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " + other.gameObject.name);
        if (other.CompareTag("PlayerBullet")) {
            TakeDamage(1);
            //cyl1 += 0.01f;
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
