using UnityEngine;

public class AchievementUnlocks : MonoBehaviour
{
    PlayerSimulation playerScript;
    [SerializeField] GameObject[] cherryTrophies;
    int cherryGoal = 10;
    int orangeGoal = 10;
    int appleGoal = 10;

    [SerializeField] GameObject[] orangeTrophies;
    [SerializeField] GameObject[] appleTrophies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cherryGoal < 40)
        {
            if(playerScript.cherries >= cherryGoal)
            {
                cherryTrophies[cherryGoal/10].SetActive(true);
                cherryGoal += 10;
            }
        }
        if(orangeGoal < 40)
        {
            if(playerScript.oranges >= orangeGoal)
            {
                orangeTrophies[orangeGoal/10].SetActive(true);
                orangeGoal += 10;
            }
        }
        if(appleGoal < 40)
        {
            if(playerScript.apples >= appleGoal)
            {
                appleTrophies[appleGoal/10].SetActive(true);
                appleGoal += 10;
            }
        }
    }
}
