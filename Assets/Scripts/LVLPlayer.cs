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
            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }
            }

            if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }
            }

            if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }
            }
            if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }
            }

            if(currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
            {
                LVLSelectUIController.instance.ShowInfo(currentPoint);

                if(Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;
                    theManager.LoadLevel();
                    
                }
            }
        }
    }

    public void SetNextPoint(MovingPoints nextPoint)
    {
        currentPoint = nextPoint;
        LVLSelectUIController.instance.HideInfo();
    }
}