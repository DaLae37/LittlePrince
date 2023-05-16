using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    private float scrollSpeed = 0.5f;
    float target_Offset;
    new Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        target_Offset -= Time.deltaTime * scrollSpeed;
        if (target_Offset <= -0.5)
        {
            target_Offset = 0;
        }
        renderer.material.SetTextureOffset("_MainTex", new Vector2(target_Offset, 0));
    }
}
