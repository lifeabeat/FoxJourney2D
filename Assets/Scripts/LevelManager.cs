using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public int gemCollected;

    public string sceneToLoad;

    public float timeInLevel;
   

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeInLevel = 0;
    }

    private void Update()
    {
        timeInLevel += Time.deltaTime;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }    

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_PLAYERDEATH);
        }
        yield return new WaitForSeconds(waitToRespawn - ( 1f / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed) + 1.75f);
        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;

        HealthController.instance.currentHealth = 3;
        UIController.instance.UpdateHealthDisplay();
    }    


    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {

        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleted.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) *2.25f);

        // Creating PlayRef to store data

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Gems", gemCollected);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_Gems"))
        {
            if (gemCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_Gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Gems", gemCollected);
            }    
        }    
        else
        {     
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_Time", timeInLevel);
        }

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_Time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_Time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_Time", timeInLevel);
            }    
        } 
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_Time", timeInLevel);
        }    

        SceneManager.LoadScene(sceneToLoad);

         if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_TITLESCREEN, 0.25f);
               
            }
     
    }
}
