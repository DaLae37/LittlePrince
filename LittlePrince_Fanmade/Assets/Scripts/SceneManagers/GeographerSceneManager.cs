using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeographerSceneManager : MonoBehaviour
{
    public GameObject panel;

    public Text button1Text;
    public Text button2Text;

    bool onPanel;
    string currentString;

    // Start is called before the first frame update
    void Start()
    {
        onPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPanel && StoryLoader.Instance.startBranch)
        {
            StoryLoader.Instance.stopLoading = true;
            onPanel = true;
            currentString = StoryLoader.Instance.story[StoryLoader.Instance.storyIndex++].ToString();
            string []tmps = currentString.Split(':');
            button1Text.text = tmps[0].Trim();
            button2Text.text = tmps[1].Trim();
            panel.SetActive(true);
        }
    }

    public void First()
    {
        StoryLoader.Instance.firstBranch = true;
        StoryLoader.Instance.stopLoading = false;
        panel.SetActive(false);
    }

    public void Second()
    {
        StoryLoader.Instance.firstBranch = false;
        StoryLoader.Instance.stopLoading = false;
        panel.SetActive(false);
    }
}
