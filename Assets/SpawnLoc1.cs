using UnityEngine;
using System.Collections;

public class LineOfSightChecker : MonoBehaviour
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
                //managerobj.GetComponent<SimpleSpawner>().Loc1LOS = false;
                managerobj.GetComponent<SimpleSpawner>().locations[0].active = false;

                CallWithDelay();
            }
            else
            {
               //Debug.Log("Line of sight blocked by: " + hit.collider.name);
               managerobj.GetComponent<SimpleSpawner>().locations[0].active = true;
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
        Debug.Log("Loc1 Line of sight is clear.");
       // managerobj.GetComponent<SimpleSpawner>().Loc1LOS = true;
        //Debug.Log("numenemies1: " + numEnemies1);

       // if (numEnemies1 <= 10) {
      //      SpawnObject();
       // }

        // Wait for cooldown
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}
