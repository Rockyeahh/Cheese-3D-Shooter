﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scorePerHit = 12;

    int score; // By default int will start at 0.
    Text scoreText;

	void Start () {
        scoreText = GetComponent<Text>(); // Gives us a reference to the component in the editor.
        scoreText.text = score.ToString(); // text is the UI bit that you type whereas scoreText is the whole thing.
	}

    public void ScoreHit()
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();
    }

}
