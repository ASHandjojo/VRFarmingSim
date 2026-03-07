using UnityEngine;
using TMPro;
using Unity.VisualScripting;

enum generatorType
{
    lower = 1, higher = 2
};
public class SpawnTreeButton : MonoBehaviour
{
    [SerializeField] fruitType fruit;
    [SerializeField] generatorType generatorLvl;
    PlayerSimulation playerScript;
    [SerializeField] TextMeshProUGUI myTextMesh;
    [SerializeField] Vector3 nextSpawnLoc;
    [SerializeField] GameObject generatorToSpawn;
    [SerializeField] int upgradeCost = 10;
    [SerializeField] int SpawnOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
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
            nextSpawnLoc.x += SpawnOffset; 
        }
        else
        {
            myTextMesh.text += "not enough fruits :(";
        }
    }
}
