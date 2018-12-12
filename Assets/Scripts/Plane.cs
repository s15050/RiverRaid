using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    public GameObject explosion;
    public GameObject stagePrefab;
    public GameObject currentStage;
    private GameObject nextStage;
    private Player play;


    void Start()
    {
        play = (Player)transform.parent.gameObject.GetComponent("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        EnemyPlane enemyPlane = other.GetComponentInParent<EnemyPlane>();
        //Śmierć
        if (enemy || enemyPlane || other.CompareTag("Wall"))
        {
            this.Wreck();
        }
        else
        {
            if (other.gameObject.name.Equals("FuelTank"))
            {
                play.fuelCount += 20f;
            }
            else if (other.gameObject.name.Equals("SpawnWall"))
            {
                var oldpos = currentStage.transform.position;
                Vector3 newpos = new Vector3(oldpos.x, oldpos.y, oldpos.z + 50);
                nextStage = Instantiate(stagePrefab, newpos, currentStage.transform.rotation, null);
                EnemyPlane enpl = nextStage.GetComponentInChildren<EnemyPlane>();
                enpl.player = play.gameObject;
            }
            else if (other.gameObject.name.Equals("DespawnWall"))
            {
                Destroy(currentStage);
                currentStage = nextStage;
            }
        }
    }

    public void Wreck()
    {
        Destroy(this.gameObject);

        if (explosion)
        {
            GameObject explosionInstance = Instantiate(explosion, this.transform.position, this.transform.rotation, null);
            Explosion boom = (Explosion)explosionInstance.GetComponent("Explosion");
            boom.factor = 2;
            boom.shouldBoom = true;
        }

    }
}
