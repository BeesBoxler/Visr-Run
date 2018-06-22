using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame () {
		SceneManager.LoadScene("RunnerScene", LoadSceneMode.Single);
	}

	public void QuitGame () {
		Application.Quit();
	}

    private void FixedUpdate()
    {

        if (Input.anyKey)
        {
            PlayGame();
        }


    }
}

public static class StaticScoreClass
{
    public static int ScoreInformation { get; set; }
}