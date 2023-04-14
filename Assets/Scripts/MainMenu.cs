using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public string startScene;

     void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_MAINLEVEL, 0.5f);
        }
    }    



    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    



}
