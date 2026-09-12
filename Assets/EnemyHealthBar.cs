using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image fillImage;        // Drag HealthBarFill here
    public EnemyHealth enemyHealth;
   // public GameObject enemE; // Reference to enemy health script

   // void Start()
   // {
        
   // }
    void Update()
    {
      // EnemyHealth scr = enemE.GetComponent<EnemyHealth>();
      float fillAmount = enemyHealth.currentHealth / enemyHealth.maxHealth;
      // float fillAmount = scr.currentHealth/scr.maxHealth;
      //Debug.Log(fillAmount + " " + gameObject);
        //Debug.Log(fillAmount);
       fillImage.fillAmount = fillAmount;
    }

    void LateUpdate()
    {
        // Make the bar face the camera
        transform.LookAt(Camera.main.transform);
    }
}
