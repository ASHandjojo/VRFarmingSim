using Unity.VisualScripting;
using UnityEngine;

enum fruitType
{
    cherries = 1,
    oranges = 2,
    apples = 3,
}
public class GeneratorFunct : MonoBehaviour
{
    [SerializeField] int generatorLevel;
    [SerializeField] fruitType fruit;
    //amount of time before resource is incremented
    int timeStep = 30;
    [SerializeField] int numGenerated = 1;
    float ticker = 0;
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
                    //increment func
                    break;
                case fruitType.oranges:
                    //increment func
                    break;
                case fruitType.apples:
                //increment func
                break;
            }
            ticker = 0;
        }
    }
    void Upgrade()
    {
        numGenerated += 2;
    }
}
