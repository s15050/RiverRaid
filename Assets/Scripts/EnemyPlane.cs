using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour {

    public GameObject player;
    public float speed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float pz = player.transform.position.z;
        float yz = transform.position.z;
        if (Mathf.Abs(pz-yz) < 12)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (transform.position.x <= -20)
        {
            Destroy(this);
        }
        
	}

}
