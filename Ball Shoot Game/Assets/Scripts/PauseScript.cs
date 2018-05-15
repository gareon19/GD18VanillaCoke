using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject victoryMenuUI;
    public TextMeshProUGUI victoryText;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !victoryMenuUI.activeSelf) {
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

    public void showVictory(string winnerText) {
        victoryText.text = winnerText;
        victoryMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        victoryMenuUI.SetActive(false);

        // reset PlayerPrefs (scores)
        PlayerPrefs.DeleteAll();

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // reset PlayerPrefs (scores)
        PlayerPrefs.DeleteAll();

        Time.timeScale = 1f;
        GameIsPaused = false;
        // hardcoded for now
        SceneManager.LoadScene("Menu");
    }
}
