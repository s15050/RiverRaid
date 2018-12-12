using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float amplitude;
    public float frequency;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = amplitude * Mathf.Sin(Time.time * frequency * 2f * Mathf.PI);
        transform.position = pos;
    }
}