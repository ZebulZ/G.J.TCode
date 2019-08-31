using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Update the enemy by giving it a new state
    public virtual void UpdateEnemy(Transform playerObj)
    {

    }

    //Do something based on a state
    public virtual void DoAction(Transform playerObj, EnemyState enemyMode)
    {
    }

    //Deleting itself
    public virtual void Delete()
    {
    }
}
