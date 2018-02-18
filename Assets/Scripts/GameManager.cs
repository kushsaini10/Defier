using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject pauseMenuUI;
    public GameObject levelCompleteUI;
    public GameObject gameOverUI;
    public int enemyCount;

    public bool gameOver;
    public bool pausedState;

    public void Start()
    {
        gameOver = false;
        pausedState = false;
        GameObject[] gm = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = gm.Length;
        Debug.Log("enemyCount = " + enemyCount);
    }

    public bool IsGamePaused()
    {
        return pausedState;
    }

    public bool IsGameOver()
    {
        Debug.Log(gameOver.ToString());
        return gameOver;
    }

    public void OnPauseClick(bool pause)
    {
        pausedState = pause;
        if(!gameOver)
            pauseMenuUI.SetActive(pause);
    }

    public void OnRetryClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
    public void OnMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 5)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            OnPauseClick(true);
            gameOverUI.SetActive(true);
        }
    }

    public void Update()
    {
        //Debug.Log("enemyCount = " + enemyCount);
        if (enemyCount <= 0)
        {
            levelCompleteUI.SetActive(true);
            gameOver = true;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!gameOver)
            {
                if (pausedState == false)
                    OnPauseClick(true);
                else
                    OnPauseClick(false);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
