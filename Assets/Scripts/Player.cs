using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float bankSpeed = 2f;
    public float speed = 0f;
    public Bullet bulletPrefab;
    public Transform visualObject;
    public float defuelSpeed = 2;
    public Text fuelKeep;
    public float fuelCount = 100;

    public GameObject restartButton;
    public GameObject exitButton;

	// Use this for initialization
	void Start () {
        fuelKeep.text = fuelCount+"";
        restartButton.SetActive(false);
        exitButton.SetActive(false);
	}

    // Update is called once per frame
    void Update() {
        float control = Input.GetAxis("Horizontal");
        float throttle = Input.GetAxis("Vertical");

        if (visualObject)
        {
            fuelCount -= Time.deltaTime * defuelSpeed;
            int disp = (int)Mathf.Round(fuelCount);
            fuelKeep.text = disp + "";
            if (disp == 0)
            {
                Plane plane = (Plane)visualObject.GetComponent("Plane");
                plane.Wreck();
            }

            transform.position += Vector3.right * control * Time.deltaTime * bankSpeed;
            transform.position += Vector3.forward * (speed + (1.5f * throttle)) * Time.deltaTime;
            visualObject.localRotation = Quaternion.Euler(0f, 0f, control * -30f);

            if (Input.GetKeyDown(KeyCode.Space) && bulletPrefab)
            {
                Bullet bulletComponent = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation, null);
                bulletComponent.speed = 10;
            }
        }
        else
        {
            restartButton.SetActive(true);
            exitButton.SetActive(true);
        }
		
	}

}
