using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Game" && Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScene("Game");
        }
    }
    public void ChangeScene(string _sceneName)
    {
        if (_sceneName == "Game")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadSceneAdditively(string _sceneName)
    {
        if(_sceneName == "PauseMenu")
        {
            Time.timeScale = 0f; // Arrête le temps
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
    }
    public void UnloadScene(string _sceneName)
    {

        if (_sceneName == "PauseMenu")
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        SceneManager.UnloadSceneAsync(_sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
