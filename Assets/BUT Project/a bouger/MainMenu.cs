using System.Collections;
using System.Collections.Generic;
using BUT;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
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
