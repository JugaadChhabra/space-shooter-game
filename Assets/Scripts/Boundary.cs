using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boundary : MonoBehaviour
{
    private Vector2 ScreenBounds;

    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, ScreenBounds.x, ScreenBounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, ScreenBounds.y, ScreenBounds.y * -1);
        transform.position = viewPos;
    }
}
