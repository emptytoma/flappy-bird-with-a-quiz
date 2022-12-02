using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameStartUI;
    public GameObject gameOverUI;
    public GameObject quizUi;
    public GameObject quizWinUi;
    public GameObject scoreUI;
    
    public FlyBird flyBird;
    public Spawner spawner;

    public Vector3 flyBirdStartPosition;

    private void Awake()
    {
        Time.timeScale = 0;
        flyBird.rb.isKinematic = true;
        flyBirdStartPosition = flyBird.rb.position;

        gameStartUI.SetActive(true);
        gameOverUI.SetActive(false);
        quizWinUi.SetActive(false);
        quizUi.SetActive(false);
        scoreUI.SetActive(false);
    }

    public void StartGame()
    {
        scoreUI.SetActive(true);
        gameStartUI.SetActive(false);
        flyBird.rb.isKinematic = false;
        Time.timeScale = 1;
    }

    public void Fail()
    {
        Time.timeScale = 0;
        quizUi.SetActive(true);
    }

    public void GameOver()
    {
        quizUi.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void Recover()
    {
        quizUi.SetActive(false);
        spawner.DestroyAllColumns();
        flyBird.rb.isKinematic = true;
        flyBird.transform.position = flyBirdStartPosition;
        quizWinUi.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        quizWinUi.SetActive(false);
        
        Time.timeScale = 1;
        flyBird.rb.isKinematic = false;
    }
}

