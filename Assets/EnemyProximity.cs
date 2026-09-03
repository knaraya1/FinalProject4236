using UnityEngine;

public class EnemyProximity : MonoBehaviour
{
    public Transform player;          // Player reference
    public float triggerDistance = 2f; // Distance required to trigger animation
    public float detonationtime = 0.25f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance)
        {
            animator.SetTrigger("PlayOnce");

           // Debug.Log("enemywithinproximity");
            Destroy(this.gameObject, detonationtime);
        }
        else
        {
            //animator.SetBool("PlayerClose", false);
            //Debug.Log("enemynotwithinproximity");
        }
    }
}
