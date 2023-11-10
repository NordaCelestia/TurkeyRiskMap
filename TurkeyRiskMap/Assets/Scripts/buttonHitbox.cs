using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonHitbox : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void openCanvas()
    {
        canvas.SetActive(true);
    }
    
    public void closeCanvas()
    {
        canvas.SetActive(false);
    }
}
