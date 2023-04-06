using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : MonoBehaviour
{
    public Transform Body;
    public Transform Target;
    public float SmashSpeed;
    public float ReturnSpeed;

    private Vector2 startPosition;
    private bool isSmashing;
    private bool isReturning;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial resting position of the Smasher.
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSmashing)
        {
            Debug.Log("Smash");
            SmashTarget();
        }
        else
        {
            ReturnToStart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the Smasher is not returning to the start position and the 
        // player triggers the Smasher, then smash.
        if (collision.tag == "Player" && !isReturning)
        {
            isSmashing = true;
        }
    }

    private void SmashTarget()
    {
        Body.position = Vector3.MoveTowards(Body.position, Target.position,
            SmashSpeed * Time.deltaTime);
        // When the Smasher reaches the target on the ground, set the smash 
        // flag to false and the return flag to true.
        if (Vector3.Distance(Body.position, Target.position) < .05f)
        {
            isSmashing = false;
            isReturning = true;
        }
    }

    private void ReturnToStart()
    {
        Body.position = Vector3.MoveTowards(Body.position, startPosition,
            ReturnSpeed * Time.deltaTime);

        // When the Smasher reaches the starting position, set the return 
        // flag to false.
        if (Vector3.Distance(Body.position, startPosition) == 0f)
        {
           isReturning = false;
        }
    }
}
