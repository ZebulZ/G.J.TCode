using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    EnemyState skeletonState = EnemyState.Patrol;

    float health = 100f;

    //Constructor for the enemy. Binds to the tranform of the actual object
    public Skeleton(Transform skeletonObj)
    {
        base.enemyObj = skeletonObj;
    }

    /// <summary>
    /// Will be different for every enemy. Updates the state of the enemy depending on the situation
    /// </summary>
    /// <param name="playerObj"></param>
    public override void UpdateEnemy(Transform playerObj)
    {
        float distance = (base.enemyObj.position - playerObj.position).magnitude;

        switch (skeletonState)
        {
            case EnemyState.Attack:
                break;
            case EnemyState.Flee:
                break;
            case EnemyState.Patrol:
                if (distance < 3)
                {
                    enemyObj.rotation = Quaternion.Inverse(enemyObj.rotation);
                    skeletonState = EnemyState.Flee;
                }
                break;
            case EnemyState.MoveTowardsPlayer:
                break;
            default:
                break;
        }

        DoAction(playerObj, skeletonState);
    }

    /// <summary>
    /// Will be different for every enemy. Executed an action based on the state of the enemy.
    /// </summary>
    /// <param name="playerObj"></param>
    /// <param name="enemyMode"></param>
    public override void DoAction(Transform playerObj, EnemyState enemyMode)
    {
        //if (pathFinder == null) return;
        //if (editorPath == null) return;

        float fleeSpeed = 10f;
        float patrolSpeed = 1f;
        float attackSpeed = 5f;
        float rotationSpeed = 5f;

        switch (enemyMode)
        {
            case EnemyState.Attack:
                break;
            case EnemyState.Flee:
                enemyObj.transform.position += new Vector3(-0.1f, 0, 0);
                break;
            case EnemyState.Patrol:
                //enemyObj.transform.position += new Vector3(0.1f, 0, 0);
                pathFinder.MoveOnPath(patrolSpeed, rotationSpeed, editorPath);
                break;
            case EnemyState.MoveTowardsPlayer:
                break;
            default:
                break;
        }
    }
}
