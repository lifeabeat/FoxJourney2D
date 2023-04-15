using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LVLSelectUIController : MonoBehaviour
{
    public static LVLSelectUIController instance;

    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelInfoPanel;

    public TextMeshProUGUI levelName;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        FadeFromBlack();
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed*Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
                
            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeToBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }

    public void ShowInfo(MovingPoints levelInfo)
    {
        levelName.text = levelInfo.levelName;

        levelInfoPanel.SetActive(true);
    }   
    
    public void HideInfo()
    {
        levelInfoPanel.SetActive(false);
    }    

}
