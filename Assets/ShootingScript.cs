using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;   // The bullet object to spawn
    public Transform playerObj;        // Where player obj is
    public float bulletSpeed = 20f;   // How fast the bullet travels
    public Transform firePoint;  
    public float cooldownTime = 0f;
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
        // Spawn bullet at player's position (or firePoint if assigned)
        Transform spawn = firePoint.transform;
        Transform player = playerObj.transform;

        GameObject bullet = Instantiate(bulletPrefab, spawn.position, firePoint.rotation);

        // Give the bullet forward velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = spawn.forward * bulletSpeed;
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
}
