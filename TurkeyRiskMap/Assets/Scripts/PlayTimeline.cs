using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class PlayTimeline : MonoBehaviour
{

    public GameObject sky;
    
    void Start()
    {
        
        StartCoroutine(CanvasDisable()); 
        
    }

   IEnumerator CanvasDisable()
    {

        yield return new WaitForSeconds(2.3f);
        sky.SetActive(false);
    }
}
