using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Fire spell to nearest enemy to player. 

*/
public class PlayerAttacks : MonoBehaviour
{
    protected GameObject player;
    private GameObject[] arrayEnemies;
    protected float speed;    
    protected int damage;    
    protected TypeSpellElement typeSpellElement;
    
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
    protected virtual void Update()
    {
        
    }

    protected GameObject GetNearestEnemyToPlayer(){
        arrayEnemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        return nearestEnemy;
    }

    protected GameObject GetNearestEnemyToCurrentLocation(){
        arrayEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float nearestEnemyDistance = float.PositiveInfinity;
        foreach (GameObject gm in arrayEnemies) 
        {
            if(gm){
                float distance = Vector3.Distance(transform.position, gm.transform.position);
                if(distance < nearestEnemyDistance){
                    nearestEnemy = gm;
                    nearestEnemyDistance = distance;
                }
            }
        }
        return nearestEnemy;
    }

    protected GameObject GetNearestEnemyToCurrentLocation(GameObject skipGm){
        arrayEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float nearestEnemyDistance = float.PositiveInfinity;
        foreach (GameObject gm in arrayEnemies) 
        {
            if(gm){
                if(gm != skipGm){
                    float distance = Vector3.Distance(transform.position, gm.transform.position);
                    if(distance < nearestEnemyDistance){
                        nearestEnemy = gm;
                        nearestEnemyDistance = distance;
                    }
                }
            }
        }
        return nearestEnemy;
    }

    protected void setRotation(Vector3 directionToEnemy){
        Vector3 moveDir = new Vector3(directionToEnemy.x, directionToEnemy.y, 0f);      
        if (moveDir != Vector3.zero) {
        	float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    protected void DmgBasedOnType(GameObject enemy, TypeSpellElement typeSpellElement, Vector3 moveDir, float duration, GameObject spell){
        if(TypeSpellElement.Fire == typeSpellElement){
            enemy.GetComponent<EnemyDebuffs>().TakeFireDamage(damage, spell);
        } else if(TypeSpellElement.Frost == typeSpellElement){
            enemy.GetComponent<EnemyDebuffs>().TakeFrostDamage(damage, spell);
        } else if(TypeSpellElement.Lightning == typeSpellElement){
            enemy.GetComponent<Enemy>().TakeDamage(damage, typeSpellElement, spell); 
        } else if(TypeSpellElement.Wind == typeSpellElement){
            enemy.GetComponent<EnemyDebuffs>().TakeWindDamage(damage, moveDir, duration, spell); 
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){      
            DmgBasedOnType(gm, typeSpellElement, new Vector3((gm.transform.position - transform.position).normalized.x, (gm.transform.position - transform.position).normalized.y, 0), 2f, transform.gameObject);
            Destroy(gameObject);
        }        
    }
}
