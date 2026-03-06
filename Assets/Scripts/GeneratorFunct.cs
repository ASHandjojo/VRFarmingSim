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
    void Start()
    {
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
        upgradeCost = generatorType * 10;
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
                if(playerScript.apples > upgradeCost)
                myTextMesh.text = "Cost: " + upgradeCost + " apples";

                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ticker += Time.deltaTime;
        if(ticker >= timeStep)
        {
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
            switch (fruit)
            {
                case fruitType.cherries:
                    myTextMesh.text = "Cost: " + upgradeCost + " cherries";
                    break;
                case fruitType.oranges:
                    myTextMesh.text = "Cost: " + upgradeCost + " oranges";
                    break;
                case fruitType.apples:
                    if(playerScript.apples > upgradeCost)
                    myTextMesh.text = "Cost: " + upgradeCost + " apples";

                    break;
            }
        }
        else
        {
            myTextMesh.text += "not enough fruits :(";
        }
        
        return;
    }
}
