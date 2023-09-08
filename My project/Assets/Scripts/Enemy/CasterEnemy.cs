using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterEnemy : Enemy
{
    private float attackRange;
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

    public static CasterEnemy Create(Vector3 position, GameObject gm, int hp, float attackSpeed, float speed, int dmg, float attackRange, int xp){
        Transform enemyTransform = Instantiate(gm, position, Quaternion.identity).transform;
        CasterEnemy enemy = enemyTransform.GetComponent<CasterEnemy>();
        enemy.Setup(hp, attackSpeed, speed, dmg, attackRange, xp);
        return enemy;
    }

    private void Setup(int hp, float attackSpeed, float speed, int dmg, float attackRangeInput, int xp){
        base.Health = hp;
        base.attackSpeed = attackSpeed;
        base.moveSpeed = speed;
        base.dmg = dmg;
        base.xp = xp;
        timeToAttack = attackSpeed;
        attackRange = attackRangeInput;
    }

    protected override void Act() {
        switch (state)
        {
            case State.ChasePlayer:
                if (InAttackRange())
                {
                    state = State.Attack;
                }
                else
                {
                    MoveToPlayer();
                    timeToAttack = attackSpeed;
                }
                break;
            case State.Attack:

                if (!InAttackRange())
                {
                    state = State.ChasePlayer;
                }
                else
                {
                    Attack();
                }
                break;
        }
    }

    private bool InAttackRange(){
        if(Vector3.Distance(transform.position, player.transform.position) > attackRange) return false;
        return true;
    } 
       
    private void Attack() {
        timeToAttack -= Time.deltaTime;
        if(timeToAttack < 0){    
            timeToAttack = attackSpeed;
            spawnProjectile();
        }
    }

    private void spawnProjectile(){
        EnemyAttack.Create(this.transform.position);
    }
    
}
