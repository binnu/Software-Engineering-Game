using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public int currentScore;
    string createUserURL = "http://localhost/UnityGame/score.php";
    UserLogin login;

    // Use this for initialization
    void Start () {
       // login = GameObject.FindObjectOfType<UserLogin>();
        PlayerPrefs.SetInt("CurrentScore", 0);
        if (PlayerPrefs.HasKey("CurrentScore"))
        {
            currentScore = PlayerPrefs.GetInt("CurrentScore");
        }
        else
        {
            currentScore = 0;
            PlayerPrefs.SetInt("CurrentScore",0);
        }
        scoreText.text = "Score: " + currentScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        scoreText.text = "Score: " + currentScore;
        Debug.Log("score is " + currentScore);
        WWWForm form = new WWWForm();
        form.AddField("score", currentScore);
        string username = PlayerPrefs.GetString("username");
          print(username);
          form.AddField("username", username);


        WWW msg = new WWW(createUserURL, form);
    }
}
