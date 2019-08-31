using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The different states the enemy can be in
public enum EnemyState
{
    Attack,
    Flee,
    Patrol,
    MoveTowardsPlayer
}

public class Skeleton : MonoBehaviour
{
    [Header ("Path Finding")]
    //Patrol path to follow
    [SerializeField]
    private EditorPath pathToFollow;

    [Header ("Enemy stats")]
    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private float fleeSpeed = 10f;
    [SerializeField]
    private float fleeThreshold = 20f;
    [SerializeField]
    private float patrolSpeed = 5f;
    [SerializeField]
    private float chargingSpeed = 10f;
    [SerializeField]
    private float attackRange = 3f;
    [SerializeField]
    private float attackDamage = 10f;
    [SerializeField]
    private float sightRange = 3f;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private float attackSpeed = 1f;


    private EnemyState skeletonState = EnemyState.Patrol;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }

    /// <summary>
    /// Will be different for every enemy. Updates the state of the enemy depending on the situation
    /// </summary>
    /// <param name="playerObj"></param>
    public void UpdateEnemy(Transform playerObj)
    {
        float distance = (transform.position - playerObj.position).magnitude;

        switch (skeletonState)
        {
            case EnemyState.Attack:
                if(health <= fleeThreshold)
                {
                    skeletonState = EnemyState.Flee;
                }
                break;
            case EnemyState.Flee:
                break;
            case EnemyState.Patrol:
                if (distance < sightRange)
                {
                    skeletonState = EnemyState.MoveTowardsPlayer;
                }
                break;
            case EnemyState.MoveTowardsPlayer:
                Debug.Log(Vector3.Distance(transform.position, playerObj.position));
                if(Vector3.Distance(transform.position, playerObj.position) < attackRange)
                {
                    skeletonState = EnemyState.Attack;
                }
                if(Vector3.Distance(transform.position, playerObj.position) > sightRange)
                {
                    pathToFollow.ResetCurrentWaypoint();
                    skeletonState = EnemyState.Patrol;
                }
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
    public void DoAction(Transform playerObj, EnemyState enemyMode)
    {
        //if (pathFinder == null) return;
        //if (editorPath == null) return;


        switch (enemyMode)
        {
            case EnemyState.Attack:
                break;
            case EnemyState.Flee:
                pathToFollow.ResetCurrentWaypoint();
                pathToFollow.MoveOnPath(transform, fleeSpeed, rotationSpeed);
                break;
            case EnemyState.Patrol:
                //enemyObj.transform.position += new Vector3(0.1f, 0, 0);
                pathToFollow.MoveOnPath(transform, patrolSpeed, rotationSpeed);
                break;
            case EnemyState.MoveTowardsPlayer:
                Debug.Log("this is the problem");
                transform.position = Vector3.Lerp(transform.position, playerObj.position, Time.deltaTime * chargingSpeed);
                break;
            default:
                break;
        }
    }
}
