using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterEnemy : Enemy
{
    private float attackRange;
    private float timeToAttack = 0;
    private void Start()
    {
        base.Start();
        state = State.ChasePlayer;
    }  

    private void Update()
    {
        Act();
    }

    public static CasterEnemy Create(Vector3 position, GameObject gm, int hp, float attackSpeed, float speed, int dmg, float attackRange){
        Transform enemyTransform = Instantiate(gm, position, Quaternion.identity);
        CasterEnemy enemy = enemyTransform.GetComponent<CasterEnemy>();
        enemy.Setup(hp, attackSpeed, speed, dmg, attackRange);
        return enemy;
    }

    private void Setup(int hp, float attackSpeed, float speed, int dmg, float attackRange){
        base.Health = hp;
        base.attackSpeed = attackSpeed;
        base.moveSpeed = speed;
        base.dmg = dmg;
        timeToAttack = attackSpeed;
        attackRange = attackRange;
    }

    private override void Act() {
        switch (state)
        {
            case State.ChasePlayer:
                if (InAttackRange())
                {
                    state = State.Attack;
                }
                else
                {
                    MoveToPlayer(movementSpeed); 
                }
                break;
            case State.Attack:
                Attack();
                if (!InAttackRange())
                {
                    state = State.ChasePlayer;
                }
                break;
        }
    }

    private bool InAttackRange(){
        // TODO: podle distance
    } 
       
    private void Attack() {
        timeToAttack -= Time.deltaTime;
        if(timeToAttack < 0){    
            timeToAttack = attackSpeed;
            spawnProjectile();
        }
    }

    private void spawnProjectile(){

    }
    
}
