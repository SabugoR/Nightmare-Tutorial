using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    [SerializeField] int mCurrentHighScore = 0;
    [SerializeField] Text mCurrentHighScoreText;
    HUDManager hudManager = null;
    Text text;


    void Awake ()
    {
        hudManager = GetComponent<HUDManager>();
    }


    void Update ()
    {
        hudManager.UpdateCurrentNumberOfKills(score);
    }

    
    public void UpdateHighScore()
    {
        mCurrentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        mCurrentHighScoreText.text = mCurrentHighScore.ToString();
    }

    public void UpdateCurrentScore()
    {
        score++;
    }
}
