using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LSManager : MonoBehaviour
{
    public LVLPlayer thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }
    public IEnumerator LoadLevelCo()
    {
        LVLSelectUIController.instance. FadeToBlack();

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
