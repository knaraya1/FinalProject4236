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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ActivateWallHack()
    {
        SimpleSpawner msmth = managerobj.GetComponent<SimpleSpawner>();

        if (msmth.numStars >= 15)
        {
            WallHack1.SetActive(true);
            WallHack2.SetActive(true);
            //multishot = true;
            //currentHealth += 100f;
            msmth.numStars -= 15;
            menuman.SetActive(false);
            SimpleMenu msmth2 = menuman2.GetComponent<SimpleMenu>();
            msmth2.isActive = true;
            crosshair.SetActive(true);
            mbutton.SetActive(false);


        }
    }
}
