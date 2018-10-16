using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 inputs;

        inputs = new Vector3(Input.GetAxisRaw("Horizontal"), 0);

        rb.AddForce(inputs * speed);
	}
}
