using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour {

    [Header("Player Components")]
    public GameObject paper;
    public float paperWait;

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
