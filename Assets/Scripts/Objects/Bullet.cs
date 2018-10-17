using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        float y = Random.Range(-0.2f, 0.2f);

        rb.velocity = transform.right * moveSpeed + y * transform.up;
    }
}
