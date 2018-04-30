using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
	}

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        // pause the running game by setting the timescale to 0
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    
    public void QuitGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        // hardcoded for now
        SceneManager.LoadScene("Menu");
    }
}
