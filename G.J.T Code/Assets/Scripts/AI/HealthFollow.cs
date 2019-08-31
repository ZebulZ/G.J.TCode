using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFollow : MonoBehaviour
{
    [SerializeField]
    private Transform objToFollow;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = objToFollow.position;
        transform.position += new Vector3(-0.1400007f, 1.78f, -2.878906f);
    }
}
