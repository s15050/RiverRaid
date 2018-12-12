using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    public float speed;
    public GameObject explosion;
    public ScoreKeeping scoreKeeper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        EnemyPlane enemyPlane = other.GetComponentInParent<EnemyPlane>();
        Bridge bridge = other.GetComponentInParent<Bridge>();
        if (enemy)
        {
            Destroy(enemy.gameObject);
            scoreKeeper.score++;

            this.triggerBoom(enemy.transform);
        }
        else if (enemyPlane)
        {
            Destroy(enemyPlane.gameObject);
            scoreKeeper.score += 5;

            this.triggerBoom(enemyPlane.transform);
        }
        else if (bridge)
        {
            bridge.ShiftMesh();
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    private void triggerBoom(Transform tra)
    {
        if (explosion)
        {
            GameObject explosionInstance = Instantiate(explosion, tra.position, tra.rotation, null);
            Explosion boom = (Explosion)explosionInstance.GetComponent("Explosion");
            if (boom)
            {
                boom.shouldBoom = true;
            }
        }

        Destroy(this.gameObject);
    }
}
