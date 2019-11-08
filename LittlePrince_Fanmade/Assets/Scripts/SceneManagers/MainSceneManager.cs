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
#if UNITY_EDITOR
        if ((Input.GetMouseButtonDown(0)))  //버튼을 누름.
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                SceneChangeManager.Instance.GameScene();
            }
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {    //터치가 1개 이상이면.
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (EventSystem.current.IsPointerOverGameObject(i) == false)
                {
                    Touch touch = Input.GetTouch(i);
                    if (touch.phase == TouchPhase.Began)
                    {
                        SceneChangeManager.Instance.GameScene();
                        break;
                    }
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
