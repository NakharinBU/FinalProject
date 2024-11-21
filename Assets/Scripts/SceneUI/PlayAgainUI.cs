using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainUI : MonoBehaviour
{
    public void PlayAgain() 
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu() 
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
