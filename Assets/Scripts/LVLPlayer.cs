using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVLPlayer : MonoBehaviour
{
    public MovingPoints currentPoint;

    public float moveSpeed = 10f;

    private bool levelLoading;

    public LSManager theManager;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed*Time.deltaTime);
        
        if (Vector3.Distance(transform.position, currentPoint.transform.position ) < .1f && !levelLoading)
        {
            

            if (Input.GetAxisRaw("Horizontal") > .5f || Input.touchCount == 1)
            {

                if (currentPoint.right != null)
                {
                    
                    SetNextPoint(currentPoint.right);
                    
                }
            }

            if (Input.GetAxisRaw("Horizontal") < -.5f || Input.touchCount == 1)
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                    
                }
            }

            if (Input.GetAxisRaw("Vertical") > .5f || Input.touchCount == 1)
            {
                
                if (currentPoint.up != null)
                {
                    
                    SetNextPoint(currentPoint.up);
                    
                }
            }
            if (Input.GetAxisRaw("Vertical") < -.5f || Input.touchCount == 1)
            {
                if (currentPoint.down != null)
                {
                    
                    SetNextPoint(currentPoint.down);
                    
                }
            }

            if(currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
            {
                LVLSelectUIController.instance.ShowInfo(currentPoint);

                if(Input.GetButtonDown("Jump") || Input.touchCount == 1)
                {
                    levelLoading = true;
                    theManager.LoadLevel();
                    if (AudioManagerUpdateVer1.HasInstance)
                    {
                        AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_LEVELSELECTED);
                    }

                    
                }
            }
        }
    }

    public void SetNextPoint(MovingPoints nextPoint)
    {
        currentPoint = nextPoint;
        MovementSE();
        LVLSelectUIController.instance.HideInfo();
    }

    public void MovementSE()
    {
        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_MAPMOVEMENT);
        }
    }
}
