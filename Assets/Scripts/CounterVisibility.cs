using UnityEngine;

public class CounterVisibility : MonoBehaviour
{
    [SerializeField] GameObject orangeCounter;
    [SerializeField] GameObject appleCounter;

    AudioSource orangeAudio;
    AudioSource appleAudio;

    PlayerSimulation playerScript;

    void Start()
    {
        playerScript = GameObject.Find("PlayerSimulation").GetComponent<PlayerSimulation>();

        if (orangeCounter == null)
            orangeCounter = GameObject.Find("Orange Counter");
        if (appleCounter == null)
            appleCounter = GameObject.Find("Apple Counter");

        if (orangeCounter != null)
        {
            orangeAudio = orangeCounter.GetComponent<AudioSource>();
            orangeCounter.SetActive(false);
        }
        if (appleCounter != null)
        {
            appleAudio = appleCounter.GetComponent<AudioSource>();
            appleCounter.SetActive(false);
        }
    }

    void Update()
    {
        if (playerScript.hasOrangeGenerator && orangeCounter != null && !orangeCounter.activeSelf)
        {
            orangeCounter.SetActive(true);
            if (orangeAudio != null)
                orangeAudio.Play();
        }

        if (playerScript.hasAppleGenerator && appleCounter != null && !appleCounter.activeSelf)
        {
            appleCounter.SetActive(true);
            if (appleAudio != null)
                appleAudio.Play();
        }
    }
}
