using UnityEngine;
using TMPro;

public class displaynumenemies : MonoBehaviour
{
    public TMP_Text valueText;   // Drag your TMP text here
    public int myValue;
    public GameObject Manager;        // The variable you want to display
    
    void Start() 
    {
        
        
    }
    void Update()
    {
        SimpleSpawner comp = Manager.GetComponent<SimpleSpawner>();
        myValue = comp.numEnemies1;
        valueText.text = "Enemies Remaning: " + myValue.ToString("0");
    }
}