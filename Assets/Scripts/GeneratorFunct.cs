using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public enum fruitType
{
    cherries = 1,
    oranges = 2,
    apples = 3,
}
public class GeneratorFunct : MonoBehaviour
{
    [SerializeField] public int generatorType;
    public fruitType fruit;
    //amount of time before resource is incremented
    int timeStep = 1;
    [SerializeField] TextMeshProUGUI myTextMesh; 
    [SerializeField] int numGenerated = 1;
    float ticker = 0;
    PlayerSimulation playerScript;
    int upgradeCost;
    // for particles for ramping resources
    [SerializeField] ParticleSystem fruitParticles;
    // for eases for planting generators
    [SerializeField] Transform generatorVisual; 
    [SerializeField] float k_Ease = 5.0f;       
    float visualHeight = 1.0f;                 
    float targetHeight = 1.0f;                
    // for exponential costs
    float visualCostDisplay; // This is 'x' (the needle on the speedometer)
    [SerializeField] float k_UI = 4f; // This is 'k' (the speed/stiffness)
    
    void Start()
    {
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
        upgradeCost = generatorType * numGenerated * 5;
        visualCostDisplay = upgradeCost;
        visualHeight = numGenerated; 
        targetHeight = numGenerated;
        switch (fruit)
        {
            case fruitType.cherries:
                myTextMesh.text = "Cost: " + upgradeCost + " cherries";
                break;
            case fruitType.oranges:
                myTextMesh.text = "Cost: " + upgradeCost + " oranges";
                break;
            case fruitType.apples:
                if (playerScript.apples > upgradeCost)
                    myTextMesh.text = "Cost: " + upgradeCost + " apples";

                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // juicy cost animation
        // v = k * (goal - x) * Time.deltaTime
        float velocity = k_UI * (upgradeCost - visualCostDisplay) * Time.deltaTime;
        visualCostDisplay += velocity;

        // juicy feedback
        myTextMesh.text = "Cost: " + (int)visualCostDisplay + " " + fruit.ToString();

        float heightVelocity = k_Ease * (targetHeight - visualHeight) * Time.deltaTime;
        visualHeight += heightVelocity;

        if (generatorVisual != null)
        {
            // This physically scales the object based on the "eased" height
            generatorVisual.localScale = new Vector3(1, visualHeight, 1);
        }

        ticker += Time.deltaTime;
        if(ticker >= timeStep)
        {
            // emit particles
            if (fruitParticles != null)
            {
                int burstAmount = Mathf.Min(numGenerated * generatorType, 50); // Cap at 50 particles
                fruitParticles.Emit(burstAmount);
            }
            //increment function on the resource
            switch (fruit)
            {
                case fruitType.cherries:
                    playerScript.cherries += numGenerated * generatorType;
                    break;
                case fruitType.oranges:
                    //increment func
                    playerScript.oranges += numGenerated * generatorType;
                    break;
                case fruitType.apples:
                //increment func
                    playerScript.apples += numGenerated * generatorType;
                    break;
            }
            ticker = 0;
        }
        return;
    }
    public void Upgrade()
    {
        bool canBuy = false;
        switch (fruit)
        {
            case fruitType.cherries:
                if(playerScript.cherries > upgradeCost)
                {
                    playerScript.cherries -= upgradeCost;
                    canBuy = true;
                }
                break;
            case fruitType.oranges:
                if(playerScript.oranges > upgradeCost)
                {
                    playerScript.oranges -= upgradeCost;
                    canBuy = true;
                }
                break;
            case fruitType.apples:
                if(playerScript.apples > upgradeCost)
                {
                    playerScript.apples -= upgradeCost;
                    canBuy = true;
                }
                break;
        }
        if (canBuy)
        {
            numGenerated += 2;
            upgradeCost *= 2;
            /*switch (fruit)
            {
                case fruitType.cherries:
                    myTextMesh.text = "Cost: " + upgradeCost + " cherries";
                    break;
                case fruitType.oranges:
                    myTextMesh.text = "Cost: " + upgradeCost + " oranges";
                    break;
                case fruitType.apples:
                    myTextMesh.text = "Cost: " + upgradeCost + " apples";

                    break;
            }*/
            targetHeight = numGenerated;
        }
        else
        {
            myTextMesh.text += "not enough fruits :(";
        }
        
        return;
    }
}
