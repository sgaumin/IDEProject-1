using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerCommands : MonoBehaviour {

    [Header("Player Components")]
    public GameObject tool;
    public int level = 1;
    public int nbtool = 1;

    [Space(10)]
    public GameObject paper;
    public float paperWait;

    [Space(10)]
    public GameObject bullet;
    public GameObject cartouche;
    public GameObject explosion;
    public Transform shootPoint;
    public Transform cartouchePoint;
    public float kickback;
    public float reloadTime;

    [Space(10)]
    public GameObject hitBox;
    public float hitWait;

    [Space(10)]
    public PullBody pullBox;
    public float pullSpeedFactor = 0.5f;

    private bool canPaper = true;
    private bool canShoot = true;
    private bool canHit = true;
    private PlayerMovement playerMove;
    private Rigidbody2D rb;

    private List<GameObject> listWalls;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        if (hitBox != null)
        {
            hitBox.SetActive(false);
        }
        listWalls = new List<GameObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && canHit)
        {
            StartCoroutine(Hit());
        }
        
        if (Input.GetKey(KeyCode.R) && canShoot)
        {
            StartCoroutine(Shoot());
        }

        //if (Input.GetKeyDown(KeyCode.Return) && nbtool > 0 && level == 1)
        //{
        //    Instantiate(tool, new Vector3(transform.position.x + 1, transform.position.y, 1), Quaternion.identity);
        //    nbtool--;
        //}
    }

    IEnumerator PlacePaper()
    {
        canPaper = false;
        yield return new WaitForSeconds(paperWait);
        canPaper = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        //GameObject bulletLaunched;
        //bulletLaunched = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Instantiate(cartouche, cartouchePoint.position, cartouchePoint.rotation);

        explosion.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        explosion.SetActive(false);

        // Recul sur le Player
        rb.AddForce(-transform.right * kickback);

        // Effet de Camera
        CameraShaker.Instance.ShakeOnce(1f, 3f, .1f, 1f);

        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

    IEnumerator Hit()
    {
        hitBox.SetActive(true);
        canHit = false;

        yield return new WaitForSeconds(hitWait);

        hitBox.SetActive(false);
        canHit = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            //Debug.Log("building");
            if (Input.GetKeyDown(KeyCode.Return) && nbtool > 0 && level == 1 && canPaper)
            {
                foreach (GameObject wall in listWalls)
                {
                    if (wall == collision.gameObject)
                    {
                        //Mur déjà utilisé
                        return;
                    }

                }

                Instantiate(tool, new Vector3(hitBox.transform.position.x, transform.position.y, 1), Quaternion.identity);
                listWalls.Add(collision.gameObject);
                StartCoroutine(PlacePaper());
                nbtool--;
                collision.gameObject.SetActive(false);
                
            }
        }
    }
}
