using UnityEngine;
using TMPro;

public class UnlockNextFruit : MonoBehaviour
{
    [SerializeField] fruitType fruit;
    PlayerSimulation playerScript;
    [SerializeField] TextMeshProUGUI myTextMesh;
    [SerializeField] GameObject counter;
    [SerializeField] GameObject tree;
    [SerializeField] GameObject shop;
    bool bought = false;
    int upgradeCost = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
        switch (fruit)
            {
                case fruitType.oranges:
                    myTextMesh.text = "Cost: " + upgradeCost + " cherries";
                    break;
                case fruitType.apples:
                    myTextMesh.text = "Cost: " + upgradeCost + " oranges";
                    break;
            }
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(!bought){
            bool canBuy = false;
            switch (fruit)
            {
                case fruitType.oranges:
                    if(playerScript.cherries > upgradeCost)
                    {
                        playerScript.cherries -= upgradeCost;
                        canBuy = true;
                    }

                    break;
                case fruitType.apples:
                    if(playerScript.oranges > upgradeCost)
                    {
                        canBuy = true;
                        playerScript.oranges -= upgradeCost;
                    }
                    break;
            }
            if (canBuy)
            {
                counter.SetActive(true);
                shop.SetActive(true);
                tree.SetActive(true);
                myTextMesh.text = "already bought!";
            }
            else
            {
                myTextMesh.text += "not enough fruits :(";
            }
        }
    }
}
