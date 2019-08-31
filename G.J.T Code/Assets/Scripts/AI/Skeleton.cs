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

public class Skeleton : Enemy
{
    [Header ("Needed connections")]
    //Patrol path to follow
    [SerializeField]
    private EditorPath pathToFollow;
    [SerializeField]
    private AIController aiController;
    [SerializeField]
    private EnemyHealth health;
    
    private float fleeSpeed;
    private float fleeThreshold;
    private float patrolSpeed;
    private float chargingSpeed;
    private float attackRange;
    private float attackDamage;
    private float sightRange;
    private float rotationSpeed;
    private float attackSpeed;


    private EnemyState skeletonState = EnemyState.Patrol;
    private bool executingAttack = false;

    private void Awake()
    {
        fleeSpeed = aiController.fleeSpeed;
        fleeThreshold = aiController.fleeThreshold;
        patrolSpeed = aiController.patrolSpeed;
        chargingSpeed = aiController.chargingSpeed;
        attackRange = aiController.attackRange;
        attackDamage = aiController.attackDamage;
        sightRange = aiController.sightRange;
        rotationSpeed = aiController.rotationSpeed;
        attackSpeed = aiController.attackSpeed;
    }

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
    public override void UpdateEnemy(Transform playerObj)
    {
        float distance = (transform.position - playerObj.position).magnitude;

        switch (skeletonState)
        {
            case EnemyState.Attack:
                if(health.health <= fleeThreshold)
                {
                    StopAttack();
                    skeletonState = EnemyState.Flee;
                }
                if (Vector3.Distance(transform.position, playerObj.position) > attackRange)
                {
                    StopAttack();
                    skeletonState = EnemyState.MoveTowardsPlayer;
                }
                break;
            case EnemyState.Flee:
                skeletonState = EnemyState.Patrol;
                break;
            case EnemyState.Patrol:
                if (distance < sightRange && health.health > fleeThreshold)
                {
                    skeletonState = EnemyState.MoveTowardsPlayer;
                }
                break;
            case EnemyState.MoveTowardsPlayer:
                if(Vector3.Distance(transform.position, playerObj.position) < attackRange)
                {
                    skeletonState = EnemyState.Attack;
                }
                if(Vector3.Distance(transform.position, playerObj.position) > sightRange)
                {
                    pathToFollow.ResetCurrentWaypoint();
                    skeletonState = EnemyState.Patrol;
                }
                if (health.health <= fleeThreshold)
                {
                    skeletonState = EnemyState.Flee;
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
    public override void DoAction(Transform playerObj, EnemyState enemyMode)
    {
        //if (pathFinder == null) return;
        //if (editorPath == null) return;
        
        switch (enemyMode)
        {
            case EnemyState.Attack:
                ExecuteAttack();
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
                transform.position = Vector3.Lerp(transform.position, playerObj.position, Time.deltaTime * chargingSpeed);
                break;
            default:
                break;
        }
    }

    private void ExecuteAttack()
    {
        if (executingAttack) return;
        else
        {
            StartCoroutine(Attack());
            executingAttack = true;
        }
    }
    
    private void StopAttack()
    {
        StopCoroutine(Attack());
        executingAttack = false;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackSpeed);
        //Here comes the actual damage done to player
        Debug.Log("bam");
        executingAttack = false;
    }

    public override void Delete()
    {
        aiController.DeleteEnemy(this);
        Destroy(transform.parent.gameObject);
    }
}
