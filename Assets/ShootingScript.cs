using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;   // The bullet object to spawn
    public Transform playerObj;        // Where player obj is
    public float bulletSpeed = 20f;   // How fast the bullet travels
    public Transform firePoint;       // Optional: where the bullet spawns

    void Update()
    {
        // Fire when left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Spawn bullet at player's position (or firePoint if assigned)
        Transform spawn = firePoint.transform;
        Transform player = playerObj.transform;

        GameObject bullet = Instantiate(bulletPrefab, spawn.position, player.rotation);

        // Give the bullet forward velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = spawn.forward * bulletSpeed;
        Debug.Log("shot");
    }
}
