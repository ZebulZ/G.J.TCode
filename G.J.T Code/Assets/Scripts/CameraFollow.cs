using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    void Update()
    {
        transform.position = target.transform.position;
    }
}
