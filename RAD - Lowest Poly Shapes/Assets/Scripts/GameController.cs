using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject newAlert;
    public Text bestText;
    public Text currentText;
    public Text scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Invoke("GameOverPanel", 2.0f);
    }

    void GameOverPanel()
    {
        scoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);

        if(score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            newAlert.SetActive(true);
        }

        bestText.text = "Best Score: " + PlayerPrefs.GetInt("Best", 0).ToString();
        currentText.text = "Current Score: " + score.ToString();
    }
    public void Restart()
    {

    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
