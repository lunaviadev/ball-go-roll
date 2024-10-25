using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneTransfer : MonoBehaviour
{
    public void StartGameplay() {
        SceneManager.LoadScene("monkeyballproject");
    }

    public void QuitGame() {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void Settings() {
        SceneManager.LoadScene("");
    }
}
