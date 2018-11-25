using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour {
    public int score = 0;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    void SetScore (int count)
    {
        score = count;
    }

	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
    }
}
