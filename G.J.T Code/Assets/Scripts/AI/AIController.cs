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

    private int lifetime = 0;
    private bool startAI = false;
    Skeleton sk;

    private void Start()
    {
        PreSetup();
    }

    private void PreSetup()
    {
        Skeleton skeleton = new Skeleton(skeletonObj.transform);
        sk = skeleton;
    }

    private void Setup()
    {
        enemies.Add(sk);
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
