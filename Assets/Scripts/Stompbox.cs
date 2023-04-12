using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{

    public GameObject deadEffect;

    public GameObject collectible;
    
    [Range(0,100)] public float chanceToDrop;
    
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
        if (collision.tag == "Enemy")
        {
            collision.transform.parent.gameObject.SetActive(false);

            Instantiate(deadEffect, collision.transform.position, collision.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, collision.transform.position, collision.transform.rotation);
            }

            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_ENEMYEXPLODE);
            }
        }
        if (collision.tag == "Box")
        {
            collision.transform.gameObject.SetActive(false);

            Instantiate(deadEffect, collision.transform.position, collision.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if (dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, collision.transform.position, collision.transform.rotation);
            }

            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_ENEMYEXPLODE);
            }
        }
    }
}
