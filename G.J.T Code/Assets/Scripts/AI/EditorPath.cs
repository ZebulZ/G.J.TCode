using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPath : MonoBehaviour
{
    //Used for drawing the path in the editor
    public Color rayColor = Color.white;
    public List<Transform> pathObjs = new List<Transform>();
    private Transform[] transfArray;

    //Used to follow the path at run-time
    private int currentWayPointID = 0;
    private float reachDistance = 1.0f;

    private Vector3 lastPosition;
    private Vector3 currentPosition;

    public void Awake()
    {
        lastPosition = transform.position;
    }

    //Draws the lines and spheres in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        transfArray = GetComponentsInChildren<Transform>();
        pathObjs.Clear();
        foreach (Transform pathObj in transfArray)
        {
            if (pathObj != this.transform)
            {
                pathObjs.Add(pathObj);
            }
        }

        for (int i = 0; i < pathObjs.Count; i++)
        {
            Vector3 pos = pathObjs[i].position;
            if (i > 0)
            {
                Vector3 previous = pathObjs[i - 1].position;
                Gizmos.DrawLine(previous, pos);
                Gizmos.DrawWireSphere(pos, 0.3f);
            }
        }
    }

    public void ResetCurrentWaypoint()
    {
        currentWayPointID = 0;
    }

    public void MoveOnPath(Transform objectToMove, float speed, float rotationSpeed)
    {
        float distance = Vector3.Distance(pathObjs[currentWayPointID].position, objectToMove.position);
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, pathObjs[currentWayPointID].position, Time.deltaTime * speed);

        objectToMove.up = objectToMove.position - pathObjs[currentWayPointID].position;

        if(distance <= reachDistance)
        {
            currentWayPointID++;
        }

        if(currentWayPointID >= pathObjs.Count)
        {
            currentWayPointID = 0;
        }
    }
}
