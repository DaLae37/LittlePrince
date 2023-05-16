using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baskin : MonoBehaviour
{

    public int idx = 1;
    public Text txt1, txt2, txt3;
    public GameObject selectPanel;
    public Text text;
    bool onPanel = false;

    void Start()
    {

    }

    private void Update()
    {
        if(!onPanel && StoryLoader.Instance.startBranch)
        {
            StoryLoader.Instance.stopLoading = true;
            onPanel = true;
            selectPanel.SetActive(true);
            playerTurn();
        }
    }

    void playerTurn()
    {
        if(idx >= 31)
        {
            StoryLoader.Instance.firstBranch = false;
            StoryLoader.Instance.stopLoading = false;
            selectPanel.SetActive(false);
            return;
        }
        selectPanel.SetActive(true);
        txt1.text = idx.ToString();
        txt2.text = idx.ToString() +", "+ (idx+1).ToString();
        txt3.text = idx.ToString() + ", " + (idx + 1).ToString() + ", " + (idx + 2).ToString();
    }

    public void button1()
    {
        idx++;
        enemyTurn();
    }
    public void button2()
    {
        idx+=2;
        enemyTurn();
    }
    public void button3()
    {
        idx += 3;
        enemyTurn();
    }

    void enemyTurn()
    {
        selectPanel.SetActive(false);
        if (idx >= 31)
        {
            StoryLoader.Instance.firstBranch = true;
            StoryLoader.Instance.stopLoading = false;
            selectPanel.SetActive(false);
            return;
        }

        selectPanel.SetActive(false);
        int rnd = Random.Range(1, 4);

        //텍스트 표시
        if (idx == 28)
        {
            text.text = idx.ToString() + ", " + (idx + 1).ToString() + ", " + (idx + 2).ToString();
            idx += 3;
        }
        else if (idx == 29)
        {
            text.text = idx.ToString() + ", " + (idx + 1).ToString();
            idx += 2;
        }
        else if (idx == 30)
        {
            text.text = idx.ToString();
            idx++;
        }
        else
        {
            switch (rnd)
            {
                //텍스트 표시 추가
                case 1: text.text = idx.ToString(); idx++; break;
                case 2: text.text = idx.ToString() + ", " + (idx + 1).ToString(); idx += 2; break;
                case 3: text.text = idx.ToString() + ", " + (idx + 1).ToString() + ", " + (idx + 2).ToString(); idx += 3; break;
            }
        }


        
        playerTurn();
    }

}
