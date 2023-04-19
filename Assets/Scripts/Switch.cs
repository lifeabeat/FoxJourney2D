using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToSwitch;

    private SpriteRenderer theSR;
    public Sprite downSprite;

    private bool hasSwitched;

    private void Start()
    {
        theSR = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasSwitched)
        {
            objectToSwitch.SetActive(false);

            theSR.sprite = downSprite;
            hasSwitched = true;

        }    
    }
}
