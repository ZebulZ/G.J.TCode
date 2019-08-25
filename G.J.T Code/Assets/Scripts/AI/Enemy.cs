using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform enemyObj;
    [SerializeField]
    public PathFinder pathFinder;
    [SerializeField]
    public EditorPath editorPath;

    //The different states the enemy can be in
    protected enum EnemyState
    {
        Attack,
        Flee,
        Patrol,
        MoveTowardsPlayer
    }

    //protected Enemy(Transform pEnemyObj)
    //{
    //    PathFinder pathFind;
    //    gameObject.AddComponent<PathFinder>();
    //    Debug.Log("this happens");
    //    //base.pathFinder = pathFind;
    //    enemyObj = pEnemyObj;
    //}

    //Update the enemy by giving it a new state
    public virtual void UpdateEnemy(Transform playerObj)
    {

    }

    //Do something based on a state
    protected void DoAction(Transform playerObj, EnemyState enemyMode)
    {
        if (pathFinder == null) return;
        if (editorPath == null) return;

        float fleeSpeed = 10f;
        float patrolSpeed = 1f;
        float attackSpeed = 5f;
        float rotationSpeed = 5f;

        switch (enemyMode)
        {
            case EnemyState.Attack:
                break;
            case EnemyState.Flee:
                enemyObj.transform.position +=  new Vector3(-0.1f, 0, 0);
                break;
            case EnemyState.Patrol:
                pathFinder.MoveOnPath(patrolSpeed, rotationSpeed, editorPath);
                break;
            case EnemyState.MoveTowardsPlayer:
                break;
            default:
                break;
        }
    }
}
