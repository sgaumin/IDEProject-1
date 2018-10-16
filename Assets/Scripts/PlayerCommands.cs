using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour {

    public GameObject paper;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            Debug.Log("Building");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(paper, transform.position + transform.up, Quaternion.identity);
            }
        }
    }
}
