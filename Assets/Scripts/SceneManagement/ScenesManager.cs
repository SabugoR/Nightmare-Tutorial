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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void OnCongratulateClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
