using UnityEngine;

public class Cartouche : MonoBehaviour {

    public float power;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * power);
    }
}
