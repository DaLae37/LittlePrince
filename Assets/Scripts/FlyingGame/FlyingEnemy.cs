using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 9.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector3(moveSpeed, 0, 0);
        if (gameObject.transform.position.x > 12)
            Destroy(gameObject);

    }
}
