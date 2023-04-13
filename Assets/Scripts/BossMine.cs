using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMine : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            HealthController.instance.BossDealDamage();
        }    
    }

    public void Explode()
    {
        Destroy(gameObject);

        Instantiate(explosion, transform.position, transform.rotation);
        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_BOSSEXPLODE);
            AudioManagerUpdateVer1.Instance.PlayRandomSEPitch();
        }
    }
}    
