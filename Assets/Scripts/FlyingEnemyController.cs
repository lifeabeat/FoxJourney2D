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
    private Rigidbody2D theRB;
    [SerializeField]
    public SpriteRenderer theSR;
    [SerializeField]
    private Animator anim;

    public Vector3 Offset;
    public float timeToAttack;
    public float time;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movingRight = true;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position,PlayerController.instance.Pos.position) < 8f)
        {

            transform.position = Vector2.MoveTowards(transform.position, PlayerController.instance.Pos.position , movingSpeed * Time.deltaTime);

            InvokeRepeating("Countdown", 1, 2);
            
        }
        else {
            // vector2.dstance tra ve khoang cach giua 2 vector, tu waypoin cho den moving flatform la bao nhieu, < 0.f1 thi doi index sang vi tri tiep theo
            if (Vector2.Distance(Waypoints[curWaypointIndex].transform.position, transform.position) < 0.1f)
            {
                curWaypointIndex++;
                if (curWaypointIndex >= Waypoints.Length)
                {
                    curWaypointIndex = 0;
                }
            }

            // Di chuyen tu vi tri nay sang vi tri kia
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
        
    }

    void CountDown()
    {
        time--;
        if (time < 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.instance.Pos.position, movingSpeed * Time.deltaTime);
        }
    }

}

