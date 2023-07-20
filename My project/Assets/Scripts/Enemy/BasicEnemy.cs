using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private float timeToAttack = 0;
    protected override void Start()
    {
        base.Start();
        state = State.ChasePlayer;
    }  

    private void Update()
    {
        Act();
    }

    public static BasicEnemy Create(Vector3 position, Transform gm, int hp, float attackSpeed, float speed, int dmg){
        Transform enemyTransform = Instantiate(gm, position, Quaternion.identity);
        BasicEnemy enemy = enemyTransform.GetComponent<BasicEnemy>();
        enemy.Setup(hp, attackSpeed, speed, dmg);
        return enemy;
    }

    private void Setup(int hp, float attackSpeed, float speed, int dmg){
        base.Health = hp;
        base.attackSpeed = attackSpeed;
        base.moveSpeed = speed;
        base.dmg = dmg;
        timeToAttack = attackSpeed;
    }

    protected override void Act() {
        switch (state)
        {
            case State.ChasePlayer:
                MoveToPlayer();            
                break;
            case State.Attack:
                Attack();
                break;
        }
    }    
    private void Attack() {
        timeToAttack -= Time.deltaTime;
        if(timeToAttack < 0){    
            timeToAttack = attackSpeed;
            player.TakeDamage(dmg);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Player")){            
            state = State.Attack;
        }        
    }

    private void OnTriggerExit2D(Collider2D collider2D) {     
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Player")){            
            state = State.ChasePlayer;
            timeToAttack = attackSpeed; //reset attack
        }        
    }
}
