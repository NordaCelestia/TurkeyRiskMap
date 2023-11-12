using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class buttonHitbox : MonoBehaviour
{
    public GameObject canvas;
    public TMP_Text pName, pInfo;

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void openCanvas()
    {

        Debug.Log("openCanvas çalýþtý");
            if (this.gameObject.tag == "Ankara")
            {
            Debug.Log("ife girdi");
            pName.text = "Ankara";
                pInfo.text = "daðlýk yer";
            }
            canvas.SetActive(true);
        
    }
    
    public void closeCanvas()
    {
        canvas.SetActive(false);
    }
}
