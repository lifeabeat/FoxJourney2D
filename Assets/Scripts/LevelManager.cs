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

    private void Awake()
    {
        instance = this;
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

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed) + .2f);
        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;

        HealthController.instance.currentHealth = HealthController.instance.maxHealth;
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
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) *1.55f);

        // Creating PlayRef to store data

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Unlocked", 1);
        
        SceneManager.LoadScene(sceneToLoad);
         if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_TITLESCREEN, 0.5f);
            }
     
    }
}
