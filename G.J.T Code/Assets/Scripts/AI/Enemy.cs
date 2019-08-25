using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform enemyObj;

    //The different states the enemy can be in
    protected enum EnemyState
    {
        Attack,
        Flee,
        Patrol,
        MoveTowardsPlayer
    }

    //Update the enemy by giving it a new state
    public virtual void UpdateEnemy(Transform playerObj)
    {

    }

    //Do something based on a state
    protected void DoAction(Transform playerObj, EnemyState enemyMode)
    {
        float fleeSpeed = 10f;
        float patrolSpeed = 1f;
        float attackSpeed = 5f;

        switch (enemyMode)
        {
            case EnemyState.Attack:
                break;
            case EnemyState.Flee:
                enemyObj.transform.Translate(new Vector2(-0.1f, 0));
                break;
            case EnemyState.Patrol:
                enemyObj.transform.Translate(new Vector2(0.1f, 0));
                break;
            case EnemyState.MoveTowardsPlayer:
                break;
            default:
                break;
        }
    }
}
