using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    [SerializeField] int mCurrentHighScore = 0;
    [SerializeField] Text mCurrentHighScoreText;

    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;
    }

    
    public void UpdateHighScore()
    {
        mCurrentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        mCurrentHighScoreText.text = mCurrentHighScore.ToString();
    }
}
