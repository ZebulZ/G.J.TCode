using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private Skeleton skeletonObj;

    List<Skeleton> enemies = new List<Skeleton>();

    private int lifetime = 0;
    private bool startAI = false;
    
    private void Setup()
    {
        enemies.Add(skeletonObj);
    }

    //Did the presetup and setup to try and give 30 frames to the object to see if the null goes away
    private void Update()
    {
        if (lifetime <= 30) { lifetime++; }
        else if (lifetime > 30 && !startAI)
        {
            startAI = true;
            Setup();
        }

        if (!startAI) return;
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].UpdateEnemy(playerObj.transform);
        }
    }
}
