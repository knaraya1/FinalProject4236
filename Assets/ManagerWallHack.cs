using UnityEngine;
using System.Collections;

public class ManagerWallHack : MonoBehaviour
{
    public GameObject menuman;
    public GameObject menuman2;
    public GameObject managerobj;
    public GameObject mbutton;

    public GameObject WallHack1;
    public GameObject WallHack2;
    public GameObject crosshair;

    public GameObject WallHackCanvas;

    public GameObject[] parent;
    public GameObject[] parent2;
    public bool WallHack = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update() 
    {
        if (WallHack == true) {

            parent = GameObject.FindGameObjectsWithTag("Enemy");
    

            for (int i=0; i<parent.Length;i++) {
                if (parent[i] != null)
                {
                    Transform child = parent[i].transform.Find("WallHackCanvas");
                    

                    if (child != null)
                    {
                        child.gameObject.SetActive(true);
                    }

                }
            }
            
           // if (parent2 != null)
            //{
            //    Transform child2 = parent2.transform.Find("WallHackCanvas");
//
            //    if (child2 != null)
//
            //    {
            //        child2.gameObject.SetActive(true);
            //    }
            //}
        } 
    }
    public void ActivateWallHack()
    {
        SimpleSpawner msmth = managerobj.GetComponent<SimpleSpawner>();
        
        if (msmth.numStars >= 15)
        {
            //if (WallHack1 == null) {
               // WallHack1.SetActive(true);
                WallHack = true;
            //}
            
            //WallHack2.SetActive(true);
            //multishot = true;
            //currentHealth += 100f;
            msmth.numStars -= 15;
            menuman.SetActive(false);
            SimpleMenu msmth2 = menuman2.GetComponent<SimpleMenu>();
            msmth2.isActive = true;
            crosshair.SetActive(true);
            mbutton.SetActive(false);
            Debug.Log("activatewallhack");


        }
    }
}
