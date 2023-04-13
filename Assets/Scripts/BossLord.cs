using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLord : MonoBehaviour
{
    public enum bossStates { movement, shooting, hurt, finish};
    public bossStates currentStates;
    public Transform theBoss;
    [SerializeField]
    private Animator Anim;

    [Header("Movement")]
    
    public float moveSpeed;
    private bool moveRight;
    public Transform leftPoint, rightPoint;
    public Transform minePoint;
    public GameObject mine;
    public float timeBetweenMine;
    private float mineCounter;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTimes;
    private float hurtCounter;
    public GameObject HitBox;

    [Header("Health")]
    public int bossHealth = 5;
    public GameObject explosion, winObject;
    private bool isDefeated;
    public float shotSpeedUp, mineSpeedUp;
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
                    if (AudioManagerUpdateVer1.HasInstance)
                    {
                        AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_BOSSSHOT);
                        AudioManagerUpdateVer1.Instance.PlayRandomSEPitch();
                    }

                }    


                break;
            case bossStates.hurt:
                if (hurtCounter >0 )
                {
                    hurtCounter -= Time.deltaTime;
                    if(hurtCounter <=0 )
                    {
                        currentStates = bossStates.movement;
                        mineCounter = 0;

                        if (isDefeated)
                        {
                            theBoss.gameObject.SetActive(false);
                            Instantiate(explosion, theBoss.position, theBoss.rotation);
                            if (AudioManagerUpdateVer1.HasInstance)
                            {
                                AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_BOSSEXPLODE);
                            }

                            winObject.SetActive(true);
                            currentStates = bossStates.finish;
                            if (AudioManagerUpdateVer1.HasInstance)
                            {
                                AudioManagerUpdateVer1.Instance.PlayBGM(AUDIO.BGM_GAMECOMPLETE);
                            }
                        }    
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

                mineCounter -= Time.deltaTime;
                
                if (mineCounter <= 0 && bossHealth <=3)
                {
                    mineCounter = timeBetweenMine;

                    Instantiate(mine, minePoint.position, minePoint.rotation);
                    if (AudioManagerUpdateVer1.HasInstance)
                    {
                        AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_BOSSMINESPAWN);
                        AudioManagerUpdateVer1.Instance.PlayRandomSEPitch();
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

        if (AudioManagerUpdateVer1.HasInstance)
        {
            AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_BOSSHIT);
        }

        BossMine[] mines = FindObjectsOfType<BossMine>();

        if (mines.Length >0 )
        {
            foreach( BossMine foundMines in mines)
            {
                foundMines.Explode();
                
            }    
        }

        bossHealth--;

        if (bossHealth <= 0)
        {
            isDefeated = true;
        }    
        if (bossHealth <= 2)
        {
            timeBetweenMine /= mineSpeedUp;
            timeBetweenShots /= shotSpeedUp;
        }    
    }    

    private void ChangeMovement()
    {
        currentStates = bossStates.shooting;

        shotCounter = 0f;

        Anim.SetTrigger("Stop");

        HitBox.SetActive(true);
    }    


   
       
}
