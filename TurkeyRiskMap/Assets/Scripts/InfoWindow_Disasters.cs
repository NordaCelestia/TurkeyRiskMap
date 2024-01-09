using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoWindow_Disasters : MonoBehaviour
{
    [SerializeField]
    GameObject disasterInfoPanel, pInfo;
    string control;
    AudioSource ass;

    private void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void openPanel()
    {
        control = this.gameObject.tag;


    

        switch (control)
        {
            case "earthquake":
                Application.OpenURL("file:///C:/Users/fatih/Desktop/earthquake_map.html");
                Debug.Log(control);
                ass = this.gameObject.GetComponent<AudioSource>();
                ass.Play();
                break;

            case "fire":
                Application.OpenURL("file:///C:/Users/fatih/fire_map.html");
                Debug.Log(control);
                ass = this.gameObject.GetComponent<AudioSource>();
                ass.Play();
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
