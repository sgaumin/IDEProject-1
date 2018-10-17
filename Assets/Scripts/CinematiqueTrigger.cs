using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematiqueTrigger : MonoBehaviour {

    public Cinematique cine;
    public Image fond;
    
    public void StartCine()
    {
        StartCoroutine(Display());
    }
	
	IEnumerator Display()
    {
        foreach (Sprite sprite in cine.sprites)
        {
            fond.sprite = sprite;
            yield return new WaitForSeconds(cine.timeBetweenSprite);
        }
    }
}
