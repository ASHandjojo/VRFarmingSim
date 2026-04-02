using UnityEngine;

public class Clicker : MonoBehaviour
{
    PlayerSimulation playerScript;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        playerScript.cherries += 1;
        audioSource.Play();
    }
}
