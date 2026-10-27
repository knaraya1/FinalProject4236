using UnityEngine;

public class EndGame : MonoBehaviour
{
    public bool activateObject = false;
    public GameObject targetObject;
    public GameObject targetObject2;
    
    public bool unlockgate = false;
    public bool isGameEnding = false;
    public GameObject Managerobj;
    [SerializeField] private GameObject targetObject3;
    [SerializeField] private Material newMaterial;
    

    void Update()
    {
        if (activateObject == true)
        {
            isGameEnding = true;
            //unlockgate = true;
            targetObject.SetActive(true);
            targetObject2.SetActive(true);

            if (Managerobj.GetComponent<SimpleSpawner>().numEnemies1 <= 0) 
            {
                unlockgate = true;
                targetObject.SetActive(false);
                targetObject2.SetActive(false);
                targetObject3.GetComponent<MeshRenderer>().material = newMaterial;

            }

        }
    }
}