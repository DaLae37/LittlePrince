using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLampSceneManager : MonoBehaviour
{
    public GameObject characterPos;
    public GameObject nameText;
    public GameObject storyText;

    bool onPanel = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPanel && StoryLoader.Instance.startBranch)
        {
            StoryLoader.Instance.stopLoading = true;
            map.instance.GenerateMap();
            onPanel = true;
            characterPos.SetActive(false);
            nameText.SetActive(false);
            storyText.SetActive(false);
        }
        if (onPanel && map.instance.isDone)
        {
            StoryLoader.Instance.firstBranch = true;
            StoryLoader.Instance.stopLoading = false;
            characterPos.SetActive(true);
            nameText.SetActive(true);
            storyText.SetActive(true);
        }
    }
}
