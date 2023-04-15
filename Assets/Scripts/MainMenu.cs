using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public string startScene,lvlselectScene;

     void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void Setting()
    {
        SceneManager.LoadScene(lvlselectScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    



}
