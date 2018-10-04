using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour {

	public void OnQuitButtonClicked()
    {
        // Quit the application:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
