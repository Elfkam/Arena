using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Fire spell on the position of nearest enemy to player. 
*/
public class PlayerBasicAttack : PlayerAttacks
{
    private float distance;
    private Vector2 directionToEnemy;
    private Vector3 startPossition;
    protected override void Start()
    {
        base.Start();
        enemyPosition = GetPossNearestEnemyToPlayer();
        speed = 1f;
        damage = 5;
        distance = 10f;
        directionToEnemy = (enemyPosition - transform.position).normalized;
        startPossition = transform.position;
    }

    void Update()
    {
        HandleMovement();
        CheckDistance();   
    }

    private void HandleMovement(){        
        Vector3 moveDir = new Vector3(directionToEnemy.x, directionToEnemy.y, 0f);        
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void CheckDistance(){
        if(Vector3.Distance(transform.position, startPossition) >= distance){
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){            
            gm.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }        
    }
}
