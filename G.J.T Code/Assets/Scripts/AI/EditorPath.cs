using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPath : MonoBehaviour
{
    public Color rayColor = Color.white;
    public List<Transform> pathObjs = new List<Transform>();
    private Transform[] transfArray;

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
}
