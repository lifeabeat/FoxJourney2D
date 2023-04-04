using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField]
    private float movingSpeed = 2f;
    [SerializeField]
    private GameObject[] Waypoints;
    // curwaypoint index de biet dang o waypoint nao
    private int curWaypointIndex = 0;

    private void Update()
    {
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
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[curWaypointIndex].transform.position, movingSpeed * Time.deltaTime);
    }
}
