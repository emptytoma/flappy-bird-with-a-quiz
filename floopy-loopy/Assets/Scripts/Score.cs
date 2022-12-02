using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public int highScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = highScore.ToString();
        
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }
}
