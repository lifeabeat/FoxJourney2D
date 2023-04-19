using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider seSlider;

    public float bgmValue;
    public float seValue;

    private void Awake()
    {
        if (AudioManagerUpdateVer1.HasInstance)
        {
            bgmValue = AudioManagerUpdateVer1.Instance.AttachBGMSource.volume;
            seValue = AudioManagerUpdateVer1.Instance.AttachBGMSource.volume;

            bgmSlider.value = bgmValue;
            seSlider.value = seValue;
        }
    }

    private void OnEnable()
    {
        if (AudioManagerUpdateVer1.HasInstance)
        {
            bgmValue = AudioManagerUpdateVer1.Instance.AttachBGMSource.volume;
            seValue = AudioManagerUpdateVer1.Instance.AttachBGMSource.volume;

            bgmSlider.value = bgmValue;
            seSlider.value = seValue;
        }
    }

    public void OnSliderChangeBGMValue(float v)
    {

        bgmValue = v;
    }

    public void OnSliderChangeSEValue(float v)
    {
        seValue = v;
    }

    public void OnCancelButtonClick()
    {
        Debug.Log("Change");
        MainMenu.instance.settingPanel.SetActive(false);
    }

    public void OnSubmitButtonClick()
    {
        Debug.Log("Change");
        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.ChangeBGMVolume(bgmValue);
            AudioManagerUpdateVer1.Instance.ChangeSEVolume(seValue);
        }


       MainMenu.instance.settingPanel.SetActive(false);
    }
}
