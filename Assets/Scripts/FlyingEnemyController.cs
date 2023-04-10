using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    private bool movingRight;

    private int curWaypointIndex = 0;

    [SerializeField]
    private float movingSpeed = 2f;
    [SerializeField]
    private GameObject[] Waypoints;
    [SerializeField]
    public SpriteRenderer theSR;
    [SerializeField]
    private Animator anim;

    public float distancetoAttack, chaseSpeed;
    public float waitAfterAttack;
    private float attackCounter;
    private bool hasAttacked;

    private Vector3 attackTarget;
   

    void Start()
    {
        anim = GetComponent<Animator>();
        movingRight = true;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[curWaypointIndex].transform.position, movingSpeed * Time.deltaTime);

        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }   
        else
        {
  
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distancetoAttack)
            {
                attackTarget = Vector3.zero;

                if (Vector3.Distance(Waypoints[curWaypointIndex].transform.position, transform.position) < 0.5f)
                {
                    curWaypointIndex++;
                    if (curWaypointIndex >= Waypoints.Length)
                    {
                        curWaypointIndex = 0;
                    }
                }
                if (movingRight)
                {
                    theSR.flipX = false;
                    transform.position = Vector3.MoveTowards(transform.position, Waypoints[curWaypointIndex].transform.position, movingSpeed * Time.deltaTime);
                    if (transform.position.x < Waypoints[curWaypointIndex].transform.position.x)
                    {
                        movingRight = false;

                    }
                }
                else
                {
                    theSR.flipX = true;
                    transform.position = Vector3.MoveTowards(transform.position, Waypoints[curWaypointIndex].transform.position, movingSpeed * Time.deltaTime);
                    if (transform.position.x > Waypoints[curWaypointIndex].transform.position.x)
                    {
                        movingRight = true;

                    }

                }


            }
            else
            {
                // Attack player
                if (attackTarget == Vector3.zero)
                {
                    attackTarget = PlayerController.instance.transform.position;
                }

                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= 0.1f)
                {
                    hasAttacked = true;
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }

            }
        }
        
        
        
    }

    /*void Update()
    {
        
        
            if (Vector2.Distance(transform.position, PlayerController.instance.transform.position) > distancetoAttack)
            {
                attackTarget = Vector2.zero;

                if (Vector2.Distance(Waypoints[curWaypointIndex].transform.position, transform.position) < 0.1f)
                {
                    curWaypointIndex++;
                    if (curWaypointIndex >= Waypoints.Length)
                    {
                        curWaypointIndex = 0;
                    }
                }
                if (movingRight)
                {
                    theSR.flipX = false;
                    transform.position = Vector2.MoveTowards(transform.position, Waypoints[curWaypointIndex].transform.position, movingSpeed * Time.deltaTime);
                    if (transform.position.x < Waypoints[curWaypointIndex].transform.position.x)
                    {
                        movingRight = false;

                    }
                }
                else
                {
                    theSR.flipX = true;
                    transform.position = Vector2.MoveTowards(transform.position, Waypoints[curWaypointIndex].transform.position, movingSpeed * Time.deltaTime);
                    if (transform.position.x > Waypoints[curWaypointIndex].transform.position.x)
                    {
                        movingRight = true;

                    }

                }


            }
            else
            {
                // Attack player
                if (attackTarget == Vector2.zero)
                {
                    attackTarget = PlayerController.instance.transform.position;
                }

                transform.position = Vector2.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

            }
        



    }*/


}

