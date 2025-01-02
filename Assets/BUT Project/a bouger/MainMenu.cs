using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button btn;
    private Text text;
    public void Start()
    {
        btn = GameObject.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(ButtonSelected);
    }

    void ButtonSelected()
    {
        Debug.Log("clickkk");
        SceneManager.LoadScene("SampleScene");
    }

    private void OnDisable()
    {
        Debug.Log("remove listener");
        btn.onClick.RemoveListener(ButtonSelected);
    }

}
