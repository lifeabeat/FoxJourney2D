using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHealth;

    public GameObject pickupEffect;

    private bool isCollected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemCollected++;
                

                isCollected = true;
                Destroy(gameObject);

                // Tao 1 ban copy cua 1 game object
                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCount();
                if (AudioManagerUpdateVer1.HasInstance)
                {
                    AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_PICKUPGEM);
                    AudioManagerUpdateVer1.Instance.PlayRandomSEPitch();
                }
            }


            if (isHealth)
            {
                if (HealthController.instance.currentHealth != HealthController.instance.maxHealth)
                {
                    HealthController.instance.HealPlayer();
                    
                    isCollected = true;
                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    if (AudioManagerUpdateVer1.HasInstance)
                    {
                        AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_PICKUPHEALTH);
                        AudioManagerUpdateVer1.Instance.PlayRandomSEPitch();
                    }
                }

            }
        }    

        
    }    
}
