using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

public class StoryLoader : MonoBehaviour
{
    public string StoryName;

    public ArrayList story = new ArrayList(); //Story Array
    public int storyIndex; //Story Array's Index

    public Text StoryText;
    public Text NameText;

    public bool stopLoading;

    private bool isChainingDone;
    private string chainingString;
    private int chainingStringIndex;

    public bool startBranch;
    public bool firstBranch;

    public Sprite myCharacter;
    public Sprite opponentCharacter;
    public Sprite noCharacter;
    public Image CharacterPos;

    private static StoryLoader instance = null;

    public static StoryLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(StoryLoader)) as StoryLoader;

                if (instance == null)
                {
                    Debug.LogError("StoryLoader is not exist in this game");
                }
            }

            return instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        stopLoading = false;
        storyIndex = 0;
        isChainingDone = false;
        startBranch = false;
        firstBranch = false;
        chainingStringIndex = 0;

        SetStory(StoryName);
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if ((!stopLoading && Input.GetMouseButtonDown(0)))  //버튼을 누름.
        {
            if (isChainingDone)
            {
                isChainingDone = false;
                chainingStringIndex = 0;
                SetText();
            }
            else
            {
                StopCoroutine("ChainingText");
                isChainingDone = true;
                StoryText.text = chainingString;
            }
        }
#endif
#if UNITY_ANDROID
        if (!stopLoading && Input.touchCount > 0)
        {    //터치가 1개 이상이면.
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    if (isChainingDone)
                    {
                        isChainingDone = false;
                        chainingStringIndex = 0;
                        SetText();
                    }
                    else
                    {
                        StopCoroutine("ChainingText");
                        isChainingDone = true;
                        StoryText.text = chainingString;
                    }
                    break;
                }
            }
        }
#endif
        if (storyIndex >= story.Count)
        {
            if (DataManager.Instance.getCurrentGameScene().Equals("B612Scene"))
                SceneChangeManager.Instance.MainScene();
            SceneChangeManager.Instance.FlyingGameScene();
        }
    }

    public void Vibrate()
    {
#if UNITY_ANDROID
        Handheld.Vibrate();
#endif
    }

    public void SetStory(string fileName) //Reading StoryText at TextFile's Location
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Stories/" + fileName);
        StringReader reader = new StringReader(textAsset.text);
        
        string readStr = null;
        while ((readStr = reader.ReadLine()) != null)
        {
            story.Add(readStr);
        }
        reader.Close();
    }

    public void SetText()
    {
        string tmp = story[storyIndex++].ToString();
        if (startBranch)
        {
            if (firstBranch)
            {
                if (tmp.StartsWith("2>"))
                {
                    storyIndex = story.Count;
                    return;
                }
            }
            else
            {
                while (story[storyIndex++].ToString().StartsWith("1>")) { }
                tmp = story[--storyIndex].ToString();
            }
        }
        else
        {
            if (tmp.Equals(">"))
            {
                startBranch = true;
            }
        }
        if (tmp.Contains(":"))
        {
            int tmpLocate = 0;
            string[] tmps = tmp.Split(':');
            if (startBranch)
                tmpLocate += 1;
            NameText.text = tmps[tmpLocate].Trim();
            if (NameText.text.Equals("이로운"))
            {
                CharacterPos.GetComponent<Image>().sprite = myCharacter;
            }
            else
            {
                CharacterPos.GetComponent<Image>().sprite = opponentCharacter;
            }
            chainingString = tmps[tmpLocate + 1].Trim();
        }
        else
        {
            NameText.text = "";
            chainingString = tmp;
            CharacterPos.GetComponent<Image>().sprite = noCharacter;
        }
        StartCoroutine("ChainingText");
    }

    IEnumerator ChainingText()
    {
        do
        {
            StoryText.text = chainingString.Substring(0, ++chainingStringIndex);
            yield return new WaitForSeconds(0.1f);
        } while (chainingStringIndex != chainingString.Length);
        isChainingDone = true;
    }
}
