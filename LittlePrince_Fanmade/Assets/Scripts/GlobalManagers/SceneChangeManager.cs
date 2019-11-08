using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private static SceneChangeManager instance = null;
    public static SceneChangeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(SceneChangeManager)) as SceneChangeManager;

                if (instance == null)
                {
                    Debug.LogError("SceneChangeManager is not exist in this game");
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SettingScene()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MiniGameScene()
    {
        SceneManager.LoadScene("MiniGameScene");
    }
}
