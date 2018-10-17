using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBody : MonoBehaviour {

    [HideInInspector]
    public bool isNearBody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Body") && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Body");
            isNearBody = true;
            collision.gameObject.transform.parent = transform;
        }
    }
}
