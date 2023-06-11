using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public int highScore;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;
    // Update is called once per frame

    void Start() {
        highScore = PlayerPrefs.GetInt("highscore");
    }
    void Update()
    {
        scoreUI.text = score.ToString();
        highScoreUI.text = highScore.ToString();
        if(score > highScore){
            PlayerPrefs.SetInt("highscore",score);
        }
        highScore = PlayerPrefs.GetInt("highscore");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "scoreup"){
            score++;
        }
    }
}
