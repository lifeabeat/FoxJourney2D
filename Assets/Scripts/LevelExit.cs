using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_COMPLETESCENE, 0.5f);
            }
            LevelManager.instance.EndLevel();
    
        }
    }
}
