using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EditorPath pathToFollow;

    private int currentWayPointID = 0;
    private float reachDistance = 1.0f;

    private Vector3 lastPosition;
    private Vector3 currentPosition;
    
    public void Awake()
    {
        lastPosition = transform.position;
    }
    
    public void MoveOnPath(float speed, float rotationSpeed, EditorPath editorPath)
    {
        float distance = Vector3.Distance(pathToFollow.pathObjs[currentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.pathObjs[currentWayPointID].position, Time.deltaTime * speed);

    }
}
