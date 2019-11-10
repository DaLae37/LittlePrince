using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessmanScene : MonoBehaviour
{
    public GameObject panel;
    public Text answerText;

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
            onPanel = true;
            panel.SetActive(true);
        }
    }

    public void SubmitAnswer()
    {
        if (answerText.text.Equals("39"))
        {
            panel.SetActive(false);
            StoryLoader.Instance.firstBranch = true;
            StoryLoader.Instance.stopLoading = false;
        }
        else
        {
            panel.SetActive(false);
            StoryLoader.Instance.firstBranch = false;
            StoryLoader.Instance.stopLoading = false;
        }
    }
}
