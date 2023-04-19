using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject settingPanel;
    public string startScene;

     
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    



}
