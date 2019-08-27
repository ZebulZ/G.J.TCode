using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private int currentWayPointID = 0;
    private float reachDistance = 1.0f;

    private Vector3 lastPosition;
    private Vector3 currentPosition;

    public void Awake()
    {
        lastPosition = transform.position;
    }
    
    //Uses the gizmost to move// Not finished yet but need to test which means I need it to connect to the Skeleton script
    public void MoveOnPath(float speed, float rotationSpeed, EditorPath pathToFollow)
    {
        float distance = Vector3.Distance(pathToFollow.pathObjs[currentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.pathObjs[currentWayPointID].position, Time.deltaTime * speed);

    }
}
