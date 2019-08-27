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

public class Enemy : MonoBehaviour
{
    protected Transform enemyObj;
    [SerializeField]
    public PathFinder pathFinder;
    [SerializeField]
    public EditorPath editorPath;
    
    //Update the enemy by giving it a new state
    public virtual void UpdateEnemy(Transform playerObj)
    {

    }

    //Do something based on a state
    public virtual void DoAction(Transform playerObj, EnemyState enemyMode)
    {
    }
}

