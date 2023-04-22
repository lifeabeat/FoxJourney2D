using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    // Singleton
    public static UIController instance;

    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartEmpty, heartHalf;
    // add joystick
    public VariableJoystick variableJoystick;
    // add jumpbutton
    public Button jumpButton;

    [SerializeField]
    public TextMeshProUGUI gemText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private float timeRemaining;
    private bool timerIsRunning = false;

    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelCompleted;
    public GameObject LosePanel;

    private void Awake()
    {
        instance = this;
        SetTimeRemain(5);
    }

    private void OnEnable()
    {
        SetTimeRemain(5);
        timerIsRunning = true;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateGemCount();
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

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                
                timeRemaining = 0;
                timerIsRunning = false;
                Time.timeScale = 0f;
                LosePanel.SetActive(true);

            }
        }
    }

    public void UpdateHealthDisplay()
    {
        switch(HealthController.instance.currentHealth)
        {
            case 6: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;
            case 5:
                heart1.sprite = heartHalf;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;
            case 4:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;
            case 3:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartHalf;
                heart3.sprite = heartFull;

                break;
            case 2:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartFull;

                break;
            case 1:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartHalf;

                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            default:

                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
        }

    }

    public void UpdateGemCount()
    {
        gemText.text = LevelManager.instance.gemCollected.ToString();
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

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetTimeRemain(float v)
    {
        timeRemaining = v;
    }

}
