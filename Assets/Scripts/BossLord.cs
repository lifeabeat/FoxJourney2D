using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLord : MonoBehaviour
{
    public enum bossStates { movement, shooting, hurt};
    public bossStates currentStates;
    public Transform theBoss;
    [SerializeField]
    private Animator Anim;

    [Header("Movement")]
    
    public float moveSpeed;
    private bool moveRight;
    public Transform leftPoint, rightPoint;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTimes;
    private float hurtCounter;

    void Start()
    {
        
        currentStates = bossStates.shooting;
    }

    void Update()
    {
        switch(currentStates)
        {
            case bossStates.shooting:

                shotCounter -= Time.deltaTime;

                if(shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    var newBullet =  Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = theBoss.localScale;
                    Debug.Log("sho");
                }    


                break;
            case bossStates.hurt:
                if (hurtCounter >0 )
                {
                    hurtCounter -= Time.deltaTime;
                    if(hurtCounter <=0 )
                    {
                        currentStates = bossStates.movement;
                    }    
                }    
                break;
            case bossStates.movement:

                if (moveRight)
                {
                    
                    theBoss.position = Vector3.MoveTowards(theBoss.position, rightPoint.transform.position, moveSpeed * Time.deltaTime);

                    if (theBoss.position.x >= rightPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(1f, 1f, 1f);

                        moveRight = false;

                        ChangeMovement();
                    }
                }
                else
                {
                        
                    theBoss.position = Vector3.MoveTowards(theBoss.position, leftPoint.transform.position, moveSpeed * Time.deltaTime);
                    if (theBoss.position.x <= leftPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);

                        moveRight = true;

                        ChangeMovement();
                    }
                }
                
                break;
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
#endif
    }

    public void TakeHit()
    {
        currentStates = bossStates.hurt;
        hurtCounter = hurtTimes;

        Anim.SetTrigger("Hit");
    }    

    private void ChangeMovement()
    {
        currentStates = bossStates.shooting;

        shotCounter = timeBetweenShots;

        Anim.SetTrigger("Stop");
    }    
   
       
}
