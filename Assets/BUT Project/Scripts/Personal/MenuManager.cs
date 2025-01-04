using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public void ChangeScene(string _sceneName)
    {
        Debug.Log("change");
        SceneManager.LoadScene(_sceneName);

    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
