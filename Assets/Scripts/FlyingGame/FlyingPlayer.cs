using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpPower = 5.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Jump();

        if (gameObject.transform.position.y < -4.6 || gameObject.transform.position.y > 4.7)
            SceneChangeManager.Instance.FlyingGameScene();
    }

    void Jump()
    {
        if ((Input.GetMouseButtonDown(0)))  //버튼을 누름.
        {
            rb.velocity = new Vector3(0, jumpPower, 0);
        }
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {    //터치가 1개 이상이면.
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    rb.velocity = new Vector3(0, jumpPower, 0);
                    break;
                }
            }
        }
#endif
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            SceneChangeManager.Instance.FlyingGameScene();
        }
    }
}
