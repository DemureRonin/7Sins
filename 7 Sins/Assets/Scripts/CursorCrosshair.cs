using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCrosshair : MonoBehaviour
{
    void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouseCursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPosition;   
    }
}
