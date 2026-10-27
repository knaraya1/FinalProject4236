using UnityEngine;

public class Door2 : MonoBehaviour
{
    public Animator animator;          // The object's Animator
    public string animationTrigger = "Wall18AnimTrigger";  
    private bool playerNearby = false;
    public GameObject managerobj;
    public GameObject cubeobject;
    //public GameObject objectToActivate;

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
        EndGame i = managerobj.GetComponent<EndGame>();
        if (playerNearby && Input.GetKeyDown(KeyCode.E) && i.unlockgate)
        {
            animator.SetTrigger(animationTrigger);
            cubeobject.SetActive(false);
           // objectToActivate.SetActive(true);

        }
    }
}
