using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SpawnTreeButton : MonoBehaviour
{
    [SerializeField] fruitType fruit;
    [SerializeField] int generatorLvl;
    PlayerSimulation playerScript;
    [SerializeField] TextMeshProUGUI myTextMesh;
    [SerializeField] Vector3 nextSpawnLoc;
    [SerializeField] GameObject generatorToSpawn;
    int upgradeCost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradeCost = generatorLvl * 2;
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
        switch (fruit)
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
            }
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
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
            upgradeCost *= upgradeCost;
            Instantiate(generatorToSpawn, nextSpawnLoc, Quaternion.identity);
            switch (fruit)
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
            }
            nextSpawnLoc.z -= 15; 
        }
        else
        {
            myTextMesh.text += " not enough fruits :(";
        }
    }
}
