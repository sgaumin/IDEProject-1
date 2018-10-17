using System.Collections;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

    public float timeToDestroy;

	// Use this for initialization
	void Start () {
        StartCoroutine(Destroy());
	}
	
	IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
