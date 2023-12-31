using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame() {
        Application.Quit();
        Debug.Log("quit button pressed");
    }

    public void PauseGame(){
        Time.timeScale = 0.0F;
    }

    public void UnpauseGame(){
        Time.timeScale = 1.0F;
    }

}
