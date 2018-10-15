using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore = 0;
    public static int playerHealth;
    [SerializeField] int mCurrentHighScore = 0;
    [SerializeField] Text mCurrentHighScoreText;
    Text text;


    void Awake ()
    {
    }


    void Update ()
    {

    }


    public void UpdateHighScore()
    {
        mCurrentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if(mCurrentHighScoreText != null && mCurrentHighScoreText.text != null)
               mCurrentHighScoreText.text = mCurrentHighScore.ToString();
    }
    public void SetHighScore()
    {
        if(PlayerPrefs.GetInt("HighScore") < currentScore)
            PlayerPrefs.SetInt("HighScore", currentScore);
        Debug.Log("Playerprefs int: " + PlayerPrefs.GetInt("HighScore"));
    }

    public void UpdateCurrentScore(int score)
    {
        currentScore=score;
    }

    public void UpdateCurrentPlayerHealth(int health)
    {
        playerHealth = health;
    }
}
