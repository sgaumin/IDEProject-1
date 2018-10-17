using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Transform shootPoint;
    public float reloadTime;

    [Space(10)]
    public GameObject hitBox;
    public float hitWait;

    private bool canPaper = true;
    private bool canShoot = true;
    private bool canHit = true;

    // Use this for initialization
    void Start () {
        if (hitBox != null)
        {
            hitBox.SetActive(false);
        }
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

        if (Input.GetKeyDown(KeyCode.Return) && nbtool > 0 && level == 1)
        {
            Instantiate(tool, new Vector3(transform.position.x + 1, transform.position.y, 1), Quaternion.identity);
            nbtool--;
        }
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
        GameObject bulletLaunched;
        bulletLaunched = Instantiate(bullet, shootPoint.position, shootPoint.rotation);

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
            if (Input.GetKeyDown(KeyCode.E) && canPaper)
            {
                Instantiate(paper, transform.position, Quaternion.identity);
                StartCoroutine(PlacePaper());
            }
        }
    }
}
