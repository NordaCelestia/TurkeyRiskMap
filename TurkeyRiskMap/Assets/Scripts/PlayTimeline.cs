using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class PlayTimeline : MonoBehaviour
{
    
    public GameObject canvas,buttons;
    public PlayableDirector director;
    public bool isLocked = false;
    void Start()
    {
        //buttons.SetActive(false);
        //canvas.SetActive(true);
        //StartCoroutine(CanvasDisable()); 
        
    }

   IEnumerator CanvasDisable()
    {
        isLocked = true;
        director.Play();

        yield return new WaitForSeconds(4.9f);
        canvas.SetActive(false);
        buttons.SetActive(true);
        isLocked = false;
    }
}
