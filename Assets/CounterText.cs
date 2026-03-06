using UnityEngine;
using TMPro; // Make sure you have TextMeshPro installed!

public class CounterText : MonoBehaviour
{
    public PlayerSimulation playerScript; 

    public TextMeshProUGUI myTextMesh; 

    public string fruitName; 

    void Update()
    {
        if (playerScript == null || myTextMesh == null) return;

        // We check the string to see which Euler variable to show
        if (fruitName == "Cherry")
            myTextMesh.text = "Cherries: " + Mathf.FloorToInt(playerScript.cherries).ToString();
        
        if (fruitName == "Orange")
            myTextMesh.text = "Oranges: " + Mathf.FloorToInt(playerScript.oranges).ToString();
            
        if (fruitName == "Apple")
            myTextMesh.text = "Apples: " + Mathf.FloorToInt(playerScript.apples).ToString();
    }
}
