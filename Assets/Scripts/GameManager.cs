using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
    // Old
    public string startScene;
    public string levelSelect, mainMenu;
    public bool isPause;

    [SerializeField]
    public GameObject pauseScreen;

    // New
    private bool isPlaying = false;
    public bool IsPlaying => isPlaying;

    // Using Delegate

    private int cherries = 0;
    public int Cherries => cherries;

    public void UpdateCherries(int v)
    {
        cherries = v;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    public void PauseGame()
    {
        if (isPause)
        {
            isPause = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPause = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void EndGame()
    {
#if  UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


    public void StartGame()
    {
        isPlaying = true;
        SceneManager.LoadScene(startScene);
        Time.timeScale = 1f;
    }

    /*public void PauseGame()
    {
        if (isPlaying)
        {
            isPlaying = false;
            Time.timeScale = 0f;
        }

    }*/
    /*public void ResumeGame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
    }*/

   /* public void RestartGame()
    {
        cherries = 0;
        ChangeScene("Menu");
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveVictoryPanel(false);
            UIManager.Instance.ActiveGamePanel(false);
            UIManager.Instance.ActiveLosePanel(false);
            UIManager.Instance.ActiveMenuPanel(true);
            // Cach Cu
            *//*UIManager.Instance.GamePanel.GetComponent<GamePanel>.NumberOfCherries.SetText("0");*//*
            UIManager.Instance.GamePanel.NumberOfCherries.SetText("0");

        }
    }*/

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
