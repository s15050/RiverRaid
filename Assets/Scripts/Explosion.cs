using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float factor = 1f;
    public bool shouldBoom;

    void Update()
    {
        if (shouldBoom)
        {
            factor -= Time.deltaTime;
            transform.localScale = Vector3.one * factor;
        }

        if (factor < 0f)
        {
            Destroy(gameObject);
        }
    }
}
