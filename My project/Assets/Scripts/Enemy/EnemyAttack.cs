using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Vector3 playerStartPos;
    private float speed;    
    private int damage;
    private float distance;
    private Vector3 startPosition;
    private void Start()
    {
        playerStartPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        speed = 2f;
        damage = 10;
        distance = 5f;
    }
    private void Update()
    {
        HandleMovement();
        CheckDistance();   
    }

    public static EnemyAttack Create(Vector3 position){
        Transform enemyAttackTransform = Instantiate(GameAssets.i.EnemyAttack.transform, position, Quaternion.identity);
        EnemyAttack enemyAttack = enemyAttackTransform.GetComponent<EnemyAttack>();
        enemyAttack.Setup(position);
        return enemyAttack;
    }

    private void Setup(Vector3 position){
        startPosition = position;
    }


    private void HandleMovement(){        
        Vector3 moveDir = new Vector3(playerStartPos.x, playerStartPos.y, 0f);        
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void CheckDistance(){
        if(Vector3.Distance(transform.position, startPosition) >= distance){
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Player")){            
            gm.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }        
    }
}
