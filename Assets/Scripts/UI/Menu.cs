using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    private void Start()
    {
        ScoreManager scoreManagerScript = null;
        GameObject[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
        GameObject highScoreMenu = (from obj in objects
                                    where (obj.tag.Equals("HighScoreMenu"))
                                    select obj).Last();
        Debug.Log(highScoreMenu.name);

        if (highScoreMenu != null)
            scoreManagerScript = highScoreMenu.GetComponent<ScoreManager>();
        else
            Debug.Log("highScoreMenu is null.");

        if (scoreManagerScript != null)
            // Load the current high score:
            scoreManagerScript.UpdateHighScore();
        else
            Debug.Log("scoreManagerScript is null.");
    }

    public void OnPlayButtonClicked()
    {
        // Load the next scene in the build qeue (scene "Level01")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnExitButtonClicked()
    {
        // Quit the game:
        Application.Quit();
    }

}
