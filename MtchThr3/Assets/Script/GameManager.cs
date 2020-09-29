using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float time;
    public float timeLimit = 120f;
    public GameObject gameOver;
    //Instace sebagai global access
    public static GameManager Instance;
    int playerScore;
    public Text scoreText;
    public Text scoreGameover;
    public Text timeText;

    // singleton
    void Start()
    {
        time = timeLimit;
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (time > 0)
        {
            time -= 1 * Time.deltaTime;
        }
        timeText.text = time.ToString();

        if (time <= 0)
        {
            time = 00;
            scoreGameover.text = scoreText.text;
            gameOver.SetActive(true);
        }
    }

    // Update score and UI
    public void GetScore(int point)
    {
        playerScore += point;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        time = timeLimit;
        SceneManager.LoadScene(0);
    }
}
