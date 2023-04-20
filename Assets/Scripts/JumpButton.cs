using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    [SerializeField]
    private PlayerController playerController;
    private bool isClicked;
    private bool isDoubleClicked;
    private float clickDelay = 0.1f;
    private void Start()
    {
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        clickDelay -= Time.deltaTime;
        //if (playerController == null )
        //{
        //    playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //}    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.clickCount >= 3) return;
        if (clickDelay > 0)
        {
            /*isDoubleClicked = true;*/
            StartCoroutine(Reset());
        }
        else
        {
            clickDelay = 0.2f;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isClicked = true;
        StartCoroutine(Reset());
        playerController.SetJump(isClicked);
    }

    private IEnumerator Reset()
    {
        if (isClicked)
        {
            yield return new WaitForEndOfFrame();
            isClicked = false;
            playerController.SetJump(false);
        }
        /*if (isDoubleClicked)
        {
            yield return new WaitForEndOfFrame();
            isDoubleClicked = false;
            PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            playerController.SetDoubleJump(false);
        }*/
    }
}
