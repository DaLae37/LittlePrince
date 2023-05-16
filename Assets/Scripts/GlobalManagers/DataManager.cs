using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string currentGameScene;
    private static DataManager instance = null;
    
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(DataManager)) as DataManager;

                if (instance == null)
                {
                    Debug.LogError("DataManager is not exist in this game");
                }
            }

            return instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentGameScene = PlayerPrefs.GetString("currentGameScene", "EarthScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getCurrentGameScene()
    {
        return currentGameScene;
    }

    public void setCurrentGameScene(string currentGameScene)
    {
        this.currentGameScene = currentGameScene;
    }

    public void nextCurrentGameScene()
    {
        switch (currentGameScene)
        {
            case "EarthScene":
                currentGameScene = "GeographerScene";
                break;
            case "GeographerScene":
                currentGameScene = "StreetLampScene";
                break;
            case "StreetLampScene":
                currentGameScene = "BusinessmanScene";
                break;
            case "BusinessmanScene":
                currentGameScene = "DrunkardScene";
                break;
            case "DrunkardScene":
                currentGameScene = "VainmanScene";
                break;
            case "VainmanScene":
                currentGameScene = "KingScene";
                break;
            case "KingScene":
                currentGameScene = "B612Scene";
                break;
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("currentGameScene", currentGameScene);
    }
}
