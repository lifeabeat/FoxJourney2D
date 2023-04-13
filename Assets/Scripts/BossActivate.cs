using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{
    public GameObject BossBattle;
    public SpriteRenderer theSR;
    public Sprite on;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            theSR.sprite = on;
            BossBattle.SetActive(true);
            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_BOSSBATTLE);
            }
        }    
    }
}
