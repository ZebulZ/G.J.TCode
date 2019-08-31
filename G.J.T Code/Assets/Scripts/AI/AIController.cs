using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private GameObject playerObj;
    [SerializeField]
    private Skeleton skeletonObj;

    List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        enemies.Add(skeletonObj);
    }

    public void DeleteEnemy<T> (T enemy) where T : Enemy
    {
        enemies.Remove(enemy);
    }

    //Did the presetup and setup to try and give 30 frames to the object to see if the null goes away
    private void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].UpdateEnemy(playerObj.transform);
        }
    }
}
