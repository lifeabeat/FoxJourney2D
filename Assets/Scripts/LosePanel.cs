using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    
    public string sceneToLoad;
    public string scenePlaying;
    public void OnClickedMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoad);

        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_TITLESCREEN, 0.25f);
        }
    }

    public void OnClickRestartButton()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        if (scene.name == "Testing3")
        {
            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_LEVELSELECT, 0.25f);
            }
        } else
        {
            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_MAINLEVEL, 0.25f);
            }
        }
        UIController.instance.FadeFromBlack();
        
    }
}
