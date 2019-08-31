using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private GameObject playerObj;
    private Enemy[] allEnemies;

    List<Enemy> enemies = new List<Enemy>();

    [Header("Enemy stats")]
    public float fleeSpeed = 10f;
    public float fleeThreshold = 20f;
    public float patrolSpeed = 5f;
    public float chargingSpeed = 10f;
    public float attackRange = 3f;
    public float attackDamage = 10f;
    public float sightRange = 3f;
    public float rotationSpeed = 5f;
    public float attackSpeed = 1f;

    private void Awake()
    {
        allEnemies = GetComponentsInChildren<Enemy>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        foreach(Enemy enemy in allEnemies)
        {
            enemies.Add(enemy);
        }
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
