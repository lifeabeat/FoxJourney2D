using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    // phai biet 2 diem can di chuyen qua lai

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    [SerializeField]
    private Rigidbody2D theRB;

    // dung de tim components trong lop con cua game object nen phai de public
    [SerializeField]
    public SpriteRenderer theSR;

    [SerializeField]
    private Animator anim;


    public float moveTime, waitTime;
    private float moveCount, waitCount;


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)


        {
            moveCount -= Time.deltaTime;


            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                theSR.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;

                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                theSR.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }


            }

            if (moveCount <= 0)
            {

                // function random range dung de lay 1 so bat ki giao dong 
                waitCount = waitTime;
            }
            anim.SetBool("isMoving", true);

        }  else if(waitCount > 0)
        {
                waitCount -= Time.deltaTime;
                theRB.velocity = new Vector2(0f, theRB.velocity.y);  

                if (waitCount <= 0)
                {
                    moveCount = moveTime;
                }
            anim.SetBool("isMoving", false);
        }    

        

    }
}
