using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour {

    [Header("Player Components")]
    public GameObject paper;
    public float paperWait;

    public int level = 1;

    public GameObject tool;
    public int nbtool = 1;

    [Space(10)]
    public GameObject hitBox;
    public float hitWait;

    private bool canHit = true;
    private bool canPaper = true;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Hit());
        }
        if (Input.GetKeyDown(KeyCode.Return) && nbtool > 0 && level == 1)
        {
            Instantiate(tool, new Vector3(transform.position.x + 1, transform.position.y, 1), Quaternion.identity);
            nbtool--;
        }
    }

    IEnumerator Hit()
    {
        hitBox.SetActive(true);
        canHit = false;

        yield return new WaitForSeconds(hitWait);

        hitBox.SetActive(false);
        canHit = true;
    }

    IEnumerator PlacePaper()
    {
        canPaper = false;
        yield return new WaitForSeconds(paperWait);
        canPaper = true;
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
