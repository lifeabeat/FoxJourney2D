using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect, mainMenu;
    public bool isPause;
    public GameObject pauseScreen;
    
    private void Awake()
    {
        instance = this;
    }
  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.touchCount == 3)
        {
            pauseScreen.SetActive(true);
            isPause = true;
            Time.timeScale = 0f;
        }    
    }

    public void Resume()
    {
            pauseScreen.SetActive(false);
            isPause = false;
            Time.timeScale = 1f;
    }    

    public void LevelSelect()
    {
        isPause = false;
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_TITLESCREEN, 0.5f);
        }

    }    

    public void MainMenu()
    {
        isPause = false;
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;

        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_TITLESCREEN, 0.5f);
        }
    }
}
