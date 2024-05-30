using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)))  //버튼을 누름.
        {
            SceneChangeManager.Instance.CurrentGameScene();
        }
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {    //터치가 1개 이상이면.
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    SceneChangeManager.Instance.CurrentGameScene();
                    break;
                }
            }
        }
#endif
    }
    public void SettingButton()
    {
        SceneChangeManager.Instance.SettingScene();
    }
}
