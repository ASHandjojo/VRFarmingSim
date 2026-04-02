using UnityEngine;
using System;

public class SessionSave : MonoBehaviour
{
    PlayerSimulation playerScript;

    void Awake()
    {
        playerScript = GameObject.Find("PlayerSimulation").GetComponent<PlayerSimulation>();
    }

    void Start()
    {
        LoadGame();
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
            SaveGame();
    }

    void OnDisable()
    {
        SaveGame();
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();

        playerScript.cherries = 0f;
        playerScript.oranges = 0f;
        playerScript.apples = 0f;

        playerScript.cherryRate = 1.0f;
        playerScript.orangeRate = 0f;
        playerScript.appleRate = 0f;

        playerScript.hasOrangeGenerator = false;
        playerScript.hasAppleGenerator = false;

        Debug.Log("Game reset to beginning.");
    }

    public void StopGame()
    {
        SaveGame();
        Debug.Log("Game saved. Quitting.");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("cherries", playerScript.cherries);
        PlayerPrefs.SetFloat("oranges", playerScript.oranges);
        PlayerPrefs.SetFloat("apples", playerScript.apples);

        PlayerPrefs.SetFloat("cherryRate", playerScript.cherryRate);
        PlayerPrefs.SetFloat("orangeRate", playerScript.orangeRate);
        PlayerPrefs.SetFloat("appleRate", playerScript.appleRate);

        PlayerPrefs.SetInt("hasOrangeGenerator", playerScript.hasOrangeGenerator ? 1 : 0);
        PlayerPrefs.SetInt("hasAppleGenerator", playerScript.hasAppleGenerator ? 1 : 0);

        PlayerPrefs.SetString("lastSaveTime", DateTime.UtcNow.ToBinary().ToString());

        PlayerPrefs.Save();
        Debug.Log("Game saved.");
    }

    void LoadGame()
    {
        if (!PlayerPrefs.HasKey("lastSaveTime"))
            return;

        playerScript.cherries = PlayerPrefs.GetFloat("cherries", 0f);
        playerScript.oranges = PlayerPrefs.GetFloat("oranges", 0f);
        playerScript.apples = PlayerPrefs.GetFloat("apples", 0f);

        playerScript.cherryRate = PlayerPrefs.GetFloat("cherryRate", 1.0f);
        playerScript.orangeRate = PlayerPrefs.GetFloat("orangeRate", 0f);
        playerScript.appleRate = PlayerPrefs.GetFloat("appleRate", 0f);

        playerScript.hasOrangeGenerator = PlayerPrefs.GetInt("hasOrangeGenerator", 0) == 1;
        playerScript.hasAppleGenerator = PlayerPrefs.GetInt("hasAppleGenerator", 0) == 1;

        // Euler step: add resources earned while away
        long binary = long.Parse(PlayerPrefs.GetString("lastSaveTime"));
        DateTime lastSave = DateTime.FromBinary(binary);
        float secondsAway = (float)(DateTime.UtcNow - lastSave).TotalSeconds;

        float cherriesGained = playerScript.cherryRate * secondsAway;
        float orangesGained = playerScript.orangeRate * secondsAway;
        float applesGained = playerScript.appleRate * secondsAway;

        playerScript.cherries += cherriesGained;
        playerScript.oranges += orangesGained;
        playerScript.apples += applesGained;

        Debug.Log("Welcome back! You were away for " + Mathf.RoundToInt(secondsAway) + "s. " +
                  "Gained: " + Mathf.RoundToInt(cherriesGained) + " cherries, " +
                  Mathf.RoundToInt(orangesGained) + " oranges, " +
                  Mathf.RoundToInt(applesGained) + " apples.");
    }
}
