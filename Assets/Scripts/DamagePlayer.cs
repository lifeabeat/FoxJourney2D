using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    // Du
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
        if (other.tag == "Player")
        {
            // Cach 1
            // FindObjectOfType<HealthController>().DealDamage();

            // Cach 2 Dung singleton
            HealthController.instance.DealDamage();
            
        }    
        
    }

}
