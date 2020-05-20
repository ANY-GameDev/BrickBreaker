using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Number of player lives")]
    int lives;
    [SerializeField]
    [Tooltip("Number of player points")]
    int score;
    [SerializeField]
    Text livesText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    [Tooltip("Delay after game is over in seconds")]
    float restartDelay;
    bool isGameOver;
    [SerializeField]
    GameObject gameOverPanel;

    void Start()
    {
        isGameOver = false;
        gameOverPanel.SetActive(isGameOver);
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (isGameOver)
        {
            Invoke("Restart", restartDelay);
        }
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(isGameOver);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
