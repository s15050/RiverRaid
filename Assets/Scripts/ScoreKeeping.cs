using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeping : MonoBehaviour {

    public int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        score = 0;
        scoreText.text = score+"";
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score + "";
	}
}
