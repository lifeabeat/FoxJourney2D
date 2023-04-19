using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerController playerController;
    private int clicked = 0;
    private float clicktime = 0;
    private float clickdelay = 0.3f;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        clicked++;
        if (clicked == 1)
        {
            clicktime = Time.time;
            Debug.Log("Clicked");
        }
    

        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            // Double click detected
            clicked = 0;
            clicktime = 0;
            playerController.SetDoubleJump(false);
            Debug.Log("Clicked");
        }
        else if (clicked > 2 || Time.time - clicktime > 1)
        {
            clicked = 0;
        }
     }
    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.SetJump(false);

    }
}
