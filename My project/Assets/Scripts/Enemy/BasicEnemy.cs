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

    protected override void Update()
    {
        base.Update();
        Act();
    }

    public static BasicEnemy Create(Vector3 position, GameObject gm, int hp, float attackSpeed, float speed, int dmg, int xp){
        Transform enemyTransform = Instantiate(gm, position, Quaternion.identity).transform;
        BasicEnemy enemy = enemyTransform.GetComponent<BasicEnemy>();
        enemy.Setup(hp, attackSpeed, speed, dmg, xp);
        return enemy;
    }

    private void Setup(int hp, float attackSpeed, float speed, int dmg, int xp){
        base.Health = hp;
        base.attackSpeed = attackSpeed;
        base.moveSpeed = speed;
        base.dmg = dmg;
        base.xp = xp;
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
