using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Player Settings")]
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool grounded;
    private bool facingRight = true;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        grounded = true;
    }

    void FixedUpdate() {

        // Horizontal movements
        Vector3 inputs = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight){
            Flip();
        }
        else if(Input.GetAxisRaw("Horizontal") < 0 && facingRight){
            Flip();
        }
        rb.AddForce(inputs * moveSpeed);

        // Jump (a revoir)
        //if (Input.GetAxisRaw("Vertical") > 0 && grounded)
        //{
        //    rb.AddForce(transform.up * jumpForce);
        //    grounded = false;
        //}
    }

    // Pivot the player according to his direction
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
