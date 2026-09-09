using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Effects")]
    public GameObject particleEffectPrefab; // Assign particle system prefab in Inspector

    [Header("Motion Settings")]
    public float rotationSpeed = 0f; // Rotation speed in degrees per second
    public float bobbingAmount = 0f; // Amplitude of bobbing motion
    public float bobbingSpeed = 0f; // Speed of bobbing motion


    private Vector3 startPosition;
    private float timer;

    void Start()
    {
        // Remember the original position of the GameObject
        startPosition = transform.position;

        
    }

    void Update()
    {
         //Rotate the object around its up axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

         //Create a bobbing motion up and down
        timer += Time.deltaTime * bobbingSpeed;
        float newY = startPosition.y + Mathf.Sin(timer) * bobbingAmount;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Manager");
            SimpleSpawner objScript = obj.GetComponent<SimpleSpawner>();
            objScript.numStars += 1;
            Debug.Log("Stars: " + objScript.numStars);
            // Instantiate the particle effect
            if (particleEffectPrefab != null)
            {
                Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            }

            // Destroy the star
            Destroy(gameObject);

        }
    }
}
