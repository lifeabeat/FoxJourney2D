using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseManager<UIManager>
{
    /// <summary>
    ///  serrialize filed spirts luon de sai cac ham trong do
    /// </summary>
    /// 
    /*[SerializeField]
    private GameObject MenuPanel;*/
    [SerializeField]
    private MenuPanel menuPanel;
    public MenuPanel MenuPanel => menuPanel;

    /*[SerializeField]
    private SettingPanel settingPanel;
    public SettingPanel SettingPanel => settingPanel;
    [SerializeField]
    private GamePanel gamePanel;
    public GamePanel GamePanel => gamePanel;
    [SerializeField]
    private PausePanel pausePanel;
    public PausePanel PausePanel => pausePanel;
    *//*[SerializeField]
    private VictoryPanel victoryPanel;
    public VictoryPanel VictoryPanel => victoryPanel;
    [SerializeField]
    private LoadingPanel loadingPanel;
    public LoadingPanel LoadingPanel => loadingPanel;
    [SerializeField]
    private LosePanel losePanel;
    public LosePanel LosePanel => losePanel;*/
    


    /*private void Start()
    {
        menuPanel.gameObject.SetActive(true);
        settingPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(false);
        loadingPanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(false);
        victoryPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);

    }
    public void ActiveMenuPanel(bool active)
    {
        menuPanel.gameObject.SetActive(active);
    }

    public void ActiveSettingPanel(bool active)
    {
        settingPanel.gameObject.SetActive(active);
    }

    public void ActiveGamePanel(bool active)
    {
        gamePanel.gameObject.SetActive(active);
    }
    public void ActiveLoadingPanel(bool active)
    {
        loadingPanel.gameObject.SetActive(active);
    }
    public void ActiveLosePanel(bool active)
    {
        losePanel.gameObject.SetActive(active);
    }
    public void ActiveVictoryPanel(bool active)
    {
        victoryPanel.gameObject.SetActive(active);
    }
    public void ActivePausePanel(bool active)
    {
        pausePanel.gameObject.SetActive(active);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.HasInstance && GameManager.Instance.IsPlaying == true)
            {
                GameManager.Instance.PauseGame();
                ActivePausePanel(true);
            }
        }
    }*/
}
