using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

    public Material OneShot;
    public Material TwoShot;
    public ScoreKeeping scoring;
    private MeshRenderer rend;
    private int shotNo;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        shotNo = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ShiftMesh()
    {
        shotNo++;
        switch (shotNo)
        {
            case 0: break;
            case 1: rend.material = OneShot; break;
            case 2: rend.material = TwoShot; break;
            default: scoring.score += 10; Destroy(this.gameObject); break;
        }
    }
}
