using UnityEngine;

public class PlayerSimulation : MonoBehaviour
{
    [Header("Fruit Counts (Integrated)")]
    public float cherries = 0f;
    public float oranges = 0f;
    public float apples = 0f;

    [Header("Production Rates")]
    public float cherryRate = 1.0f; 
    public float orangeRate = 0f;  
    public float appleRate = 0f;

    [Header("Unlock Costs")]
    public float orangeCostInCherries = 50f;
    public float appleCostInOranges = 100f;

    [Header("Unlock Status")]
    public bool hasOrangeGenerator = false;
    public bool hasAppleGenerator = false;

    void Update()
    {
    }

    /*(public void UnlockOrangeGenerator()
    {
        if (!hasOrangeGenerator && cherries >= orangeCostInCherries)
        {
            cherries -= orangeCostInCherries; 
            hasOrangeGenerator = true;
            orangeRate = 2.0f; 
            Debug.Log("Orange Generator Unlocked!");
        }
    }

    public void UnlockAppleGenerator()
    {
        if (!hasAppleGenerator && oranges >= appleCostInOranges)
        {
            oranges -= appleCostInOranges; 
            hasAppleGenerator = true;
            appleRate = 5.0f; 
            Debug.Log("Apple Generator Unlocked!");
        }
    }*/
}
