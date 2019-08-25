using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private GameObject skeletonObj;

    List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        enemies.Add(new Skeleton(skeletonObj.transform));
    }

    private void Update()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].UpdateEnemy(playerObj.transform);
        }
    }
}
