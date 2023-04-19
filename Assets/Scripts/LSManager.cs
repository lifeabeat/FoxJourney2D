using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LSManager : MonoBehaviour
{
    public LVLPlayer thePlayer;

    private MovingPoints[] allPoints;

    public void Start()
    {
        allPoints = FindObjectsOfType<MovingPoints>();

        if(PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach(MovingPoints point in allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.currentPoint = point;
                }    
            }    
        }    

    }
    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }
    public IEnumerator LoadLevelCo()
    {
        LVLSelectUIController.instance.FadeToBlack();
        LVLSelectUIController.instance.HideInfo();

       // Wait for Fadescreen
       yield return new WaitForSeconds((1f / LVLSelectUIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad);
        if (thePlayer.currentPoint.levelToLoad == "Testing3")
        {
            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_LEVELSELECT, 0.5f);
            }
        } else
        {
            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_MAINLEVEL, 0.5f);
            }
        }
    }
}
