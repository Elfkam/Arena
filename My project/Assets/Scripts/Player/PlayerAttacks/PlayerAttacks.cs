using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Fire spell to nearest enemy to player. 

*/
public class PlayerAttacks : MonoBehaviour
{
    private GameObject player;
    private GameObject[] arrayEnemies;

    protected Vector3 enemyPosition;
    protected float speed;    
    protected int damage;
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        arrayEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // TODO: pridat vystreli na random enemy

    protected Vector3 GetPossNearestEnemyToPlayer(){
        GameObject nearestEnemy = null;
        float nearestEnemyDistance = float.PositiveInfinity;
        foreach (GameObject gm in arrayEnemies) 
        {
            float distance = Vector3.Distance(player.transform.position, gm.transform.position);
            if(nearestEnemyDistance > distance){
                nearestEnemy = gm;
            }
        }
        return nearestEnemy.transform.position;
    }
}
