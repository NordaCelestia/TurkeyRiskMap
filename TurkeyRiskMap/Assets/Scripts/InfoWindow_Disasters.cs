using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoWindow_Disasters : MonoBehaviour
{
    [SerializeField]
    GameObject disasterInfoPanel, pInfo;
    string control;


    private void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void openPanel()
    {
        control = this.gameObject.tag;
        pInfo.SetActive(false);
        disasterInfoPanel.SetActive(true);

        

        switch (control)
        {
            case "earthquake":
                Debug.Log(control);
                break;

            case "fire":
                Debug.Log(control);
                break;

            case "flood":
                Debug.Log(control);
                break;

            case "landslide":
                Debug.Log(control);
                break;
        }
    }
}
