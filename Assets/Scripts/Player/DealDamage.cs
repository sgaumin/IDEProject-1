using UnityEngine;

public class DealDamage : MonoBehaviour {

    //public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            if (gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}
