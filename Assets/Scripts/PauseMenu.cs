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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }    
    }

    public void PauseUnpause()
    {
        if(isPause)
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

  
}
