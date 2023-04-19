using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{

    public string Menu;


    public void StartGame()
    {
        SceneManager.LoadScene(Menu);
    }

    public void QuitGame()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();



    }





}
