using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        // reset PlayerPrefs (scores)
        PlayerPrefs.DeleteAll();

        // loads the next scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Player vs Player");
    }

    public void PlayTutorial()
    {
        // reset PlayerPrefs (scores)
        PlayerPrefs.DeleteAll();

        // loads the next scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        // does not work in the editor
        Application.Quit();
    }

}
