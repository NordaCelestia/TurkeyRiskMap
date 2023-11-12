using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followmouse : MonoBehaviour
{
    

    
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y + 2);
    }
}
