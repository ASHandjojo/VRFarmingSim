using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public enum fruitType
{
    cherries = 1,
    oranges = 2,
    apples = 3,
    grapes = 3,
    dragonfruit = 4,
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
    [SerializeField] float k_Ease = 4f;
    float visualScale = 0f;
    float targetScale = 4f;                               
    // for exponential costs
    float visualCostDisplay;
    [SerializeField] float k_UI = 2f;
    
    void Start()
    {
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
        upgradeCost = generatorType * numGenerated * 5;
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
        // ease visualCostDisplay toward the real upgradeCost
        visualCostDisplay += k_UI * (upgradeCost - visualCostDisplay) * Time.deltaTime;
        myTextMesh.text = "Cost: " + (int)visualCostDisplay + " " + fruit.ToString();
        ticker += Time.deltaTime;

        // ease generator
        visualScale += k_Ease * (targetScale - visualScale) * Time.deltaTime;
        transform.localScale = new Vector3(visualScale, visualScale, visualScale);

        if(ticker >= timeStep)
        {
            // emit particles
            if (fruitParticles != null)
            {
                // int burstAmount = Mathf.Min(numGenerated * generatorType, 50); // Cap at 50 particles
                fruitParticles.Emit(numGenerated * generatorType);
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
        }
        else
        {
            myTextMesh.text += "not enough fruits :(";
        }
        
        return;
    }
}
