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
    
    public enum TypeSpellElement{
        Fire,
        Frost,
        Wind,
        Lightning,
    }
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        arrayEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    protected Vector3 GetPossNearestEnemyToPlayer(){
        GameObject nearestEnemy = null;
        float nearestEnemyDistance = float.PositiveInfinity;
        foreach (GameObject gm in arrayEnemies) 
        {
            float distance = Vector3.Distance(player.transform.position, gm.transform.position);
            if(distance < nearestEnemyDistance){
                nearestEnemy = gm;
                nearestEnemyDistance = distance;
            }
        }
        return nearestEnemy.transform.position;
    }

    protected void setRotation(Vector3 directionToEnemy){
        Vector3 moveDir = new Vector3(directionToEnemy.x, directionToEnemy.y, 0f);      
        if (moveDir != Vector3.zero) {
        	float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
