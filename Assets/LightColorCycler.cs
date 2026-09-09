using UnityEngine;
using System.Collections;

public class LightColorCycler : MonoBehaviour
{
    public Light targetLightG1;
    public Light targetLightG2;
    public Light targetLightG3;
    public Light targetLightGr1;
    public Light targetLightGr2;
    public Light targetLightGr3;
    public Light targetLightR1;
    public Light targetLightR2;
    public Light targetLightR3;
    public Light targetLightRl1;
    public Light targetLightRl2;
    public Light targetLightRl3;
    public Color[] colors;
    public int index;
    public float interval;

    public float cooldownTime = 3f;   // time before it can run again
    public float delayTime = 2f; 
    public bool onCooldown = false;

    void Update()
    {
        CallWithDelay();
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
        if (index >= colors.Length)
            {
                index = 0;
            }
        Debug.Log(index);

       // while (true)
       // {
       if (index == 0)
       {
        targetLightG1.color = colors[0];
        targetLightG2.color = colors[1];
        targetLightG3.color = colors[2];

        targetLightGr1.color = colors[2];
        targetLightGr2.color = colors[1];
        targetLightGr3.color = colors[0];

        targetLightR1.color = colors[0];
        targetLightR2.color = colors[1];
        targetLightR3.color = colors[2];

        targetLightRl1.color = colors[2];
        targetLightRl2.color = colors[1];
        targetLightRl3.color = colors[0];
       }
       if (index == 1)
       {
        targetLightG1.color = colors[1];
        targetLightG2.color = colors[1];
        targetLightG3.color = colors[1];

        targetLightGr1.color = colors[2];
        targetLightGr2.color = colors[2];
        targetLightGr3.color = colors[2];

        targetLightR1.color = colors[0];
        targetLightR2.color = colors[0];
        targetLightR3.color = colors[0];

        targetLightRl1.color = colors[2];
        targetLightRl2.color = colors[1];
        targetLightRl3.color = colors[0];
       }
       if (index == 2)
       {
        targetLightG1.color = colors[2];
        targetLightG2.color = colors[2];
        targetLightG3.color = colors[2];

        targetLightGr1.color = colors[0];
        targetLightGr2.color = colors[0];
        targetLightGr3.color = colors[0];

        targetLightR1.color = colors[1];
        targetLightR2.color = colors[1];
        targetLightR3.color = colors[1];

        targetLightRl1.color = colors[2];
        targetLightRl2.color = colors[0];
        targetLightRl3.color = colors[1];
       }
        

        index = (index + 1);
            
            
            
            
      //  }

        // Wait before executing the command
        yield return new WaitForSeconds(delayTime);
        //Debug.Log("numenemies1: " + numEnemies1);

        // Wait for cooldown
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}

