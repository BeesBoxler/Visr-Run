using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public static bool isPaused = false;
    float escPrev;

	void Update ()
    {
        float esc = Input.GetAxis("Cancel");
        if (esc == 1 && esc != escPrev)
        {
            Debug.Log("Bloop");
            if (isPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }

        escPrev = esc;

        //if (input.getkeydown("joystick button 0"))
        //{
        //    //a
        //    resumegame();
        //}
        //else if (input.getkeydown("joystick button 1"))
        //{
        //    //b
        //    showmenu();
        //}
        //else if (input.getkeydown("joystick button 2"))
        //{
        //    //y
        //    quitgame();
        //}
    }



    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
