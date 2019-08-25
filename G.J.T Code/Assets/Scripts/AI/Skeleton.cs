using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    EnemyState skeletonState = EnemyState.Patrol;

    float health = 100f;

    public Skeleton(Transform skeletonObj)
    {
        base.enemyObj = skeletonObj;
    }

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
}
