using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField] GameObject generator;
    GeneratorFunct script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script = generator.GetComponent<GeneratorFunct>();
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        script.Upgrade();
    }
}
