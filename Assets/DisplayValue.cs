using UnityEngine;
using TMPro;

public class DisplayValue : MonoBehaviour
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
        myValue = comp.numStars;
        valueText.text = "Stars: " + myValue.ToString("0") + "/50";
    }
}
