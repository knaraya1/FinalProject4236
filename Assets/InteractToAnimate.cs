using UnityEngine;

public class InteractToAnimate : MonoBehaviour
{
    public Animator animator;          // The object's Animator
    public string animationTrigger = "Play";  
    private bool playerNearby = false;
    public GameObject objectToActivate;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger(animationTrigger);
            objectToActivate.SetActive(true);

        }
    }
}
