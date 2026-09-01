using UnityEngine;
using UnityEngine.AI;

public class RandomWander : MonoBehaviour
{
    public float wanderRadius = 10f;      // How far the agent can roam
    public float wanderInterval = 3f;     // How often it picks a new destination

    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderInterval)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    // Picks a random valid point on the NavMesh
    public static Vector3 RandomNavSphere(Vector3 origin, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, NavMesh.AllAreas);

        return navHit.position;
    }
}
