using UnityEngine;
using System.Collections;

public class LineOfSightChecker2 : MonoBehaviour
{
    public Transform target;
    public float delayTime = 0f;      // time before the action runs
    public float cooldownTime = 2f;   // time before it can run again

    private bool onCooldown = false;
    public GameObject managerobj;
    private void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction.normalized, out hit, distance))
        {
            if (hit.transform == target)
            {
                managerobj.GetComponent<SimpleSpawner>().locations[1].active = false;
                CallWithDelay();
            }
            else
            {
                //Debug.Log("Line of sight blocked by: " + hit.collider.name);
                 managerobj.GetComponent<SimpleSpawner>().locations[1].active = true;
            }
        }
    }
    public void CallWithDelay()
    {
        if (!onCooldown)
        {
            StartCoroutine(RunAfterDelay());
        }
    }

    IEnumerator RunAfterDelay()
    {
        onCooldown = true;

        // Wait before executing the command
        yield return new WaitForSeconds(delayTime);
        Debug.Log("Loc2 Line of sight is clear.");
        //Debug.Log("numenemies1: " + numEnemies1);

       // if (numEnemies1 <= 10) {
      //      SpawnObject();
       // }

        // Wait for cooldown
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}
