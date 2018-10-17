using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CineMode : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }

    public void LaunchCineMode()
    {
        anim.SetBool("CineMode", true);
    }

    public void QuitCineMode()
    {
        anim.SetBool("CineMode", false);
    }
}
