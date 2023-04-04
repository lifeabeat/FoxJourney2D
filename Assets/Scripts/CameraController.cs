using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Singleton 
    public static CameraController instance;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform farBackground, middleBackground;

    // Highest and Lowest camera point
    public float minHeight, maxHeight;

    // Stop follow Player
    public bool stopFollow;

    //private float lastXPos;
    private Vector2 lastPos;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        // float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        // transform.position = new Vector3(target.position.x, clampedY, transform.position.z);

        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);


            //float amountToMoveX = transform.position.x - lastXPos;
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            //farBackground.position = farBackground.position + new Vector3(amountToMoveX, 0f, 0f);
            //middleBackground.position = middleBackground.position + new Vector3(amountToMoveX * 0.5f, 0f, 0f);

            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
            middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) *0.25f;


            //lastXPos = transform.position.x;
            lastPos = transform.position;
        }
    }
}
