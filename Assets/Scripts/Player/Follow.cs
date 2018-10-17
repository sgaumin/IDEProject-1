using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    [Header("Variables")]
    public GameObject objectToFollow;
    public float speed = 2.0f;
    public float minCamX = 0;
    public float maxCamX = 4.5f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        if ((position.x > minCamX) && (position.x < maxCamX))
        {
            this.transform.position = position;
        }
        
    }
}
