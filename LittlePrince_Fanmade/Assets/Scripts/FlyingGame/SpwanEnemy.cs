using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
    public GameObject spot1;
    public GameObject spot2;
    public GameObject spot3;
    public GameObject spot4;
    public GameObject spot5;
    public GameObject enemy;

    private float spawnTime = 3.0f;
    private int randNum;
    private int countNum = 0;

    void Update()
    {
        if (countNum > 5)
        {
            DataManager.Instance.nextCurrentGameScene();
            SceneChangeManager.Instance.CurrentGameScene();
        }
        if (spawnTime < 0)
        {
            countNum++;
            if (randNum == 1 || randNum == 5) //Difficulty Balancing
            {
                randNum = Random.Range(2, 5);
            }
            else
            {
                randNum = Random.Range(2, 6);
            }
            switch (randNum)
            {
                case 1:
                    Instantiate(enemy, spot2.transform);
                    Instantiate(enemy, spot3.transform);
                    Instantiate(enemy, spot4.transform);
                    Instantiate(enemy, spot5.transform);
                    break;
                case 2:
                    Instantiate(enemy, spot1.transform);
                    Instantiate(enemy, spot3.transform);
                    Instantiate(enemy, spot4.transform);
                    Instantiate(enemy, spot5.transform);
                    break;
                case 3:
                    Instantiate(enemy, spot1.transform);
                    Instantiate(enemy, spot2.transform);
                    Instantiate(enemy, spot4.transform);
                    Instantiate(enemy, spot5.transform);
                    break;
                case 4:
                    Instantiate(enemy, spot1.transform);
                    Instantiate(enemy, spot2.transform);
                    Instantiate(enemy, spot3.transform);
                    Instantiate(enemy, spot5.transform);
                    break;
                case 5:
                    Instantiate(enemy, spot1.transform);
                    Instantiate(enemy, spot2.transform);
                    Instantiate(enemy, spot3.transform);
                    Instantiate(enemy, spot4.transform);
                    break;

            }
            spawnTime = 3;
        }
        spawnTime -= Time.deltaTime;
    }
}
