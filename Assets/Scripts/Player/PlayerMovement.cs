using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Settings")] public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool grounded;
    private bool facingRight = true;
    private Collider2D collider;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        grounded = true;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.gameState == GameManager.gameStates.Playing) 
        {
            // Horizontal movements
            Vector3 inputs = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
            if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)     
            {
                Flip();
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
            {
                Flip();
            }
            rb.AddForce(inputs * moveSpeed);
            //Debug.Log(grounded);
            if (Input.GetKeyDown(KeyCode.Space)&&grounded)
            {
                Jump();
            }
        }
    }

    // Pivot the player according to his direction
    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);

        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;

        //float theScale = rb.rotation;
        //theScale += 180;
        //rb.rotation = theScale;
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0));
        grounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!grounded)
        {
            grounded = true;
        }
    }
}
