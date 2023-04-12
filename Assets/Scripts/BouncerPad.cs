using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerPad : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public float bounceForce = 20f;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.TheRB.velocity = new Vector2(PlayerController.instance.TheRB.velocity.x, bounceForce);
            anim.SetTrigger("Bounce");
            if (AudioManagerUpdateVer1.HasInstance)
            {
                AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_BOUNCING);
            }
        }    
    }
}
