using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform homePosition;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Settings")]
    public float sightRange = 15f;
    public float sightAngle = 60f;
    public float shootInterval = 1f;
    public float wanderRadius = 10f;
    public float lostSightTime = 3f;
    

    private NavMeshAgent agent;
    private float shootTimer = 0f;
    private float lostTimer = 0f;
    private bool playerInSight = false;
    public Animator animator;
    public Animator animator2;
    
    private bool animationTriggered = false;
    private bool animation2Triggered = false;

    public GameObject targetObject;
    public GameObject targetObject2;

    void Start()
    {
        Animator animator = GetComponentInChildren<Animator>();

        agent = GetComponent<NavMeshAgent>();
        Wander();
    }

    void Update()
    {

        DetectPlayer();

        if (playerInSight)
        {
            lostTimer = 0f;

            Vector3 lookPos = player.transform.position - transform.position;
            lookPos.y = 0;
            transform.rotation = Quaternion.LookRotation(lookPos);

            ShootPlayer();
        }
        else
        {
            lostTimer += Time.deltaTime;

            if (lostTimer >= lostSightTime)
            {
                animationmethod();

                agent.SetDestination(homePosition.position);
            }
            else
            {
                if (agent.remainingDistance < 1f)
                    Wander();
            }
        }
    }

    // -----------------------------
    // DETECT PLAYER
    // -----------------------------
    void DetectPlayer()
    {
        Vector3 dirToPlayer = (player.position - transform.position).normalized;

        float angle = Vector3.Angle(transform.forward, dirToPlayer);
        float distance = Vector3.Distance(transform.position, player.position);

        if (angle < sightAngle && distance < sightRange)
        {
            // Raycast to check line of sight
            if (Physics.Raycast(transform.position + Vector3.up, dirToPlayer, out RaycastHit hit, sightRange))
            {
                if (hit.transform == player)
                {
                    playerInSight = true;
                    return;
                }
            }
        }

        playerInSight = false;
    }

    // -----------------------------
    // SHOOT PLAYER
    // -----------------------------
    void ShootPlayer()
    {
        animationmethod2();

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Give the bullet forward velocity
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Vector3 dir = (player.position - firePoint.position).normalized;
            rb.linearVelocity = dir * 20f;

            shootTimer = 0f;
        }
    }

    // -----------------------------
    // WANDER RANDOMLY
    // -----------------------------
    void Wander()
    {
        animationmethod();

        Vector3 randomDir = Random.insideUnitSphere * wanderRadius;
        randomDir += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDir, out hit, wanderRadius, NavMesh.AllAreas);

        agent.SetDestination(hit.position);
    }
    void animationmethod() {
        if (!animationTriggered)
        {
            targetObject.SetActive(true);
            targetObject2.SetActive(false);
            animator.SetTrigger("WalkingTrigger");
            animationTriggered = true;
            RunAfterDelay();
        }
    }

    void animationmethod2() {
        if (!animation2Triggered)
        {
            targetObject2.SetActive(true);
            targetObject.SetActive(false);
            animator2.SetTrigger("ShootTrigger");
            animation2Triggered = true;
            RunAfterDelay2();
        }
    }

    public void RunAfterDelay()
    {
        StartCoroutine(DoSomethingAfterTime(3f)); // runs after 3 seconds
    }

    IEnumerator DoSomethingAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Code that runs after the delay
        animationTriggered = false;
        Debug.Log("animationtriggered set to true");
    }

    public void RunAfterDelay2()
    {
        StartCoroutine(DoSomethingAfterTime2(3f)); // runs after 3 seconds
    }

    IEnumerator DoSomethingAfterTime2(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Code that runs after the delay
        animation2Triggered = false;
        Debug.Log("animation2triggered set to true");
    }


}
