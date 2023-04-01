using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource[] soundEffects;
    public AudioSource bgm, levelEndMusic;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundtoPlay)
    {
        soundEffects[soundtoPlay].Stop();
        soundEffects[soundtoPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[soundtoPlay].Play();
    }    
}
