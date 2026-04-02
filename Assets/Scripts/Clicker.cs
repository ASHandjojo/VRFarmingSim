using UnityEngine;
public class Clicker : MonoBehaviour
{
    PlayerSimulation playerScript;
    AudioSource audioSource;
    ParticleSystem ps;
    float ticker = 20f;
    bool isPlaying = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = (GameObject.Find("PlayerSimulation")).GetComponent<PlayerSimulation>();
        audioSource = GetComponent<AudioSource>();
        ps = (GameObject.Find("ClickerParticle")).GetComponent<ParticleSystem>();
    }

    void Update()
    {
        ticker += Time.deltaTime;
        if(ticker > 20f && !isPlaying)
        {
            ps.Play();
            isPlaying = true;
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(ticker > 20f)
        {
            playerScript.cherries += 1;
            audioSource.Play();
            ticker = 0;
            ps.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            isPlaying = false;
        }
    }
}
