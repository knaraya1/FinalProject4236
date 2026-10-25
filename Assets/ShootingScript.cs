using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;   // The bullet object to spawn
    public Transform playerObj;        // Where player obj is
    public float bulletSpeed = 20f;   // How fast the bullet travels
    public Transform firePoint;  
    public Transform firePointxtra;  
    public Transform firePointxtra1;  
    public Transform firePointxtra2;
    public Transform firePointxtra3;
    public Transform firePointxtra4;
    public Transform firePointxtra5;
    //public Transform firePointxtra6;          
    public float cooldownTime = 0f;
    public bool multishot;
    public GameObject menuman;
    public GameObject menuman2;
    public GameObject managerobj;
    public GameObject mbutton;
    public GameObject crosshair;
    private bool onCooldown = false;     // Optional: where the bullet spawns

    void Update()
    {
        // Fire when left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            UseAbility();
        }
    }

    void Shoot()
    {
        // Spawn bullet at player's position (or firePoint if assigned) todo: put the following 6 lines under the multishot condition
        Transform spawn = firePoint.transform;
        Transform spawn0 = firePointxtra.transform;
        Transform spawn1 = firePointxtra1.transform;
        Transform spawn2 = firePointxtra2.transform;
        Transform spawn3 = firePointxtra3.transform;
        Transform spawn4 = firePointxtra4.transform;
        Transform spawn5 = firePointxtra5.transform;
        Transform player6 = playerObj.transform;

        GameObject bullet = Instantiate(bulletPrefab, spawn.position, firePoint.rotation);
       // Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //rb.linearVelocity = spawn.forward * bulletSpeed;
        if (multishot == true)
        {
            GameObject bullet0 = Instantiate(bulletPrefab, spawn0.position, firePointxtra.rotation);
            GameObject bullet1 = Instantiate(bulletPrefab, spawn1.position, firePointxtra1.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, spawn2.position, firePointxtra2.rotation);
            GameObject bullet3 = Instantiate(bulletPrefab, spawn3.position, firePointxtra3.rotation);
            GameObject bullet4 = Instantiate(bulletPrefab, spawn4.position, firePointxtra4.rotation);
            GameObject bullet5 = Instantiate(bulletPrefab, spawn5.position, firePointxtra5.rotation);

            //Rigidbody rb0 = bullet0.GetComponent<Rigidbody>();
            //rb0.linearVelocity = spawn0.forward * bulletSpeed;

            //Rigidbody rb1 = bullet1.GetComponent<Rigidbody>();
            //rb1.linearVelocity = spawn1.forward * bulletSpeed;

            //Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
            //rb2.linearVelocity = spawn2.forward * bulletSpeed;

           // Rigidbody rb3 = bullet3.GetComponent<Rigidbody>();
           // rb3.linearVelocity = spawn3.forward * bulletSpeed;

            //Rigidbody rb4 = bullet4.GetComponent<Rigidbody>();
            //rb4.linearVelocity = spawn4.forward * bulletSpeed;

            //Rigidbody rb5 = bullet5.GetComponent<Rigidbody>();
           // rb5.linearVelocity = spawn5.forward * bulletSpeed;
           // Instantiate(bullet, spawn.position, firePointxtra.rotation);
        }
        // Give the bullet forward velocity
        
        //Debug.Log("shot");
    }
     public void UseAbility()
    {
        if (!onCooldown)
        {
            Shoot();
            StartCoroutine(Cooldown());
            //Debug.Log("Ability used!");
        }
        else
        {
            //Debug.Log("Ability is on cooldown");
        }
    }

    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
        //Debug.Log("Cooldown finished!");
    }
    public void ActivateMultishot()
    {
        SimpleSpawner msmth = managerobj.GetComponent<SimpleSpawner>();

        if (msmth.numStars >= 5)
        {
            multishot = true;
            //currentHealth += 100f;
            msmth.numStars -= 5;
            menuman.SetActive(false);
            SimpleMenu msmth2 = menuman2.GetComponent<SimpleMenu>();
            msmth2.isActive = true;
            crosshair.SetActive(true);
            mbutton.SetActive(false);


        }
    }
}
