using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float duration;
    public float magnitude;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shake();
        }
    }

    public void Shake()
    {
        //StopAllCoroutines();
        StartCoroutine(DoShake(duration, magnitude));
    }

    public IEnumerator DoShake(float duration,float magnitude) {

        Vector3 originalPos = transform.position;

        float elapsed = 0.0f;

        while (duration < 0)
        {
            float x = Random.Range(-1,1) * magnitude;
            float y = Random.Range(-1,1) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            yield return null;

            elapsed += Time.deltaTime;
        }
    }
}
