using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public void OnPlayButtonClicked() {
        Debug.Log("play button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void OnReturnButtonClicked() {
        Debug.Log("return button");
        // Go back to main menu from everywhere in the game:
        SceneManager.LoadScene(0);
    }

    public void OnCongratulateClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
