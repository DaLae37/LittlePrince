using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class map : MonoBehaviour
{
    public bool isDone = false;
    public static map instance;
    public GameObject tile;
    int[,] mapArray = new int[8, 6] { { 0, 0, 1, 5, 1 , 3 }, { 3, 1, 8, 0, 7, 1 }, { 6, 6, 2, 2, 9, 2 }, { 1, 1, 5, 1, 3, 5 }, { 1, 8, 8, 0, 0, 9 }, { 7, 10, 0, 7, 0, 3 }, { 1, 6, 0, 1, 2, 9 }, { 3, 1, 4, 2, 0, 1 } };
    GameObject[,] _tiles = new GameObject[8, 6];
    public Sprite[] images = new Sprite[3];
    private Camera cam;

    private float touchTime = 0f;

    void Start()
    {
        instance = this;
        cam = Camera.main;
        gameObject.SetActive(false);
    }

    public void GenerateMap()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject _tile = tile;
                _tile.transform.rotation = Quaternion.EulerRotation(new Vector3(0, 0, 0));
                _tile.transform.position = new Vector3(-2.5f + (1.0f * j), 3.5f - (1.0f * i), 10);
                switch (mapArray[i, j])
                {
                    case 0:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[0];
                        break;
                    case 1:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[0];
                        _tile.transform.Rotate(new Vector3(0, 0, -90));
                        break;
                    case 2:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[1];
                        break;
                    case 3:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[1];
                        _tile.transform.Rotate(new Vector3(0, 0, -90));
                        break;
                    case 4:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[1];
                        _tile.transform.Rotate(new Vector3(0, 0, -180));
                        break;
                    case 5:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[1];
                        _tile.transform.Rotate(new Vector3(0, 0, -270));
                        break;
                    case 6:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[2];
                        break;
                    case 7:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[2];
                        _tile.transform.Rotate(new Vector3(0, 0, -90));
                        break;
                    case 8:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[2];
                        _tile.transform.Rotate(new Vector3(0, 0, -180));
                        break;
                    case 9:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[2];
                        _tile.transform.Rotate(new Vector3(0, 0, -270));
                        break;
                    case 10:
                        _tile.GetComponent<SpriteRenderer>().sprite = images[3];
                        break;
                }
                _tiles[i, j] = Instantiate(_tile);
                _tiles[i, j].transform.SetParent(transform);
            }
        }
    }

    void Update()
    {
        chkEnd();
        if (touchTime > 0)
            touchTime -= Time.deltaTime;
        else if (touchTime < 0)
            touchTime = 0;

        if ((Input.GetMouseButton(0) || Input.touchCount > 0) && touchTime == 0)
        {
            touchTime = 0.1f;
            Vector3 mos = new Vector3(0,0,0);
            if (Input.GetMouseButton(0))
                mos = Input.mousePosition;
            if (Input.touchCount > 0)
                mos = Input.GetTouch(0).position;

            mos.z = -10;

            Vector3 dir = cam.ScreenToWorldPoint(mos);


            int xPos, yPos;

            if (dir.x >= -3.0 && dir.x <= -2.0)
                xPos = 0;
            else if (dir.x >= -2.0 && dir.x <= -1.0)
                xPos = 1;
            else if (dir.x >= -1.0 && dir.x <= 0)
                xPos = 2;
            else if (dir.x >= 0 && dir.x <= 1)
                xPos = 3;
            else if (dir.x >= 1 && dir.x <= 2)
                xPos = 4;
            else if (dir.x >= 2 && dir.x <= 3)
                xPos = 5;
            else
                xPos = -1;


            if (dir.y <= 4 && dir.y >= 3)
                yPos = 0;
            else if(dir.y <= 3 && dir.y >= 2)
                yPos = 1;
            else if (dir.y <= 2 && dir.y >= 1)
                yPos = 2;
            else if(dir.y <= 1 && dir.y >= 0)
                yPos = 3;
            else if (dir.y <= 0 && dir.y >= -1)
                yPos = 4;
            else if (dir.y <= -1 && dir.y >= -2)
                yPos = 5;
            else if(dir.y <= -2 && dir.y >= -3)
                yPos = 6;
            else if (dir.y <= -3 && dir.y >= -4)
                yPos = 7;
            else
                yPos = -1;

            if (xPos != -1 && yPos != -1)
            {
                switch (mapArray[yPos, xPos])
                {
                    case 0:
                        mapArray[yPos, xPos]++;
                        _tiles[yPos, xPos].transform.Rotate(0, 0, 90);
                        break;
                    case 1:
                        mapArray[yPos, xPos] = 0;
                        _tiles[yPos, xPos].transform.Rotate(0, 0, 90);
                        break;
                    case 2:
                    case 3:
                    case 4:
                        _tiles[yPos, xPos].transform.Rotate(0, 0, 90);
                        mapArray[yPos, xPos]++;
                        break;
                    case 5:
                        _tiles[yPos, xPos].transform.Rotate(0, 0, 90);
                        mapArray[yPos, xPos] = 2;
                        break;

                    case 6:
                    case 7:
                    case 8:
                        _tiles[yPos, xPos].transform.Rotate(0, 0, 90);
                        mapArray[yPos, xPos]++;
                        break;
                    case 9:
                        _tiles[yPos, xPos].transform.Rotate(0, 0, 90);
                        mapArray[yPos, xPos] = 6;
                        break;
                }
            }

        }
    }


    void chkEnd()
    {
        if (mapArray[7, 5] == 0)
        {
            isDone = true;
            gameObject.SetActive(false);
        }

    }
}
