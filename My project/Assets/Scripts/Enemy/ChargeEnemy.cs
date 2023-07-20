using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : Enemy
{
    private float chargeRange;
    private float timeToAttack = 0;

    private float prepareToCharge = 1f;

    private float timeToCharge = 0;
    protected override void Start()
    {
        base.Start();
        state = State.ChasePlayer;
    }  

    private void Update()
    {

    }

    public static ChargeEnemy Create(Vector3 position, Transform gm, int hp, float attackSpeed, float speed, int dmg, float chargeRange){
        Transform enemyTransform = Instantiate(gm, position, Quaternion.identity);
        ChargeEnemy enemy = enemyTransform.GetComponent<ChargeEnemy>();
        enemy.Setup(hp, attackSpeed, speed, dmg, chargeRange);
        return enemy;
    }

    private void Setup(int hp, float attackSpeed, float speed, int dmg, float chargeRangeInput){
        base.Health = hp;
        base.attackSpeed = attackSpeed;
        base.moveSpeed = speed;
        base.dmg = dmg;
        timeToAttack = attackSpeed;
        chargeRange = chargeRangeInput;
        timeToCharge = prepareToCharge;
    }

    protected override void Act() {
        switch (state)
        {
            case State.ChasePlayer:
                if(InChargeRange()){
                    state = State.PrepareToCharge;
                }else{
                    MoveToPlayer();
                }                       
                break;
            case State.Attack:
                Attack();
                break;
            case State.PrepareToCharge:
                PrepareToCharge();
                break;
            case State.Charge:
                Charge();
                break;
        }
    }

    private bool InChargeRange(){
        // TODO: podle chargeRange -> pokud je hrac v nejakem rozmezi tak se chargne -> aby se nechargoval porad (mozna muze jen jednou)
        return true;
    }

    private void Charge(){
        // zrychleni az 3x a bezi tam kde hrac byl!!
    }

    private void PrepareToCharge() {
        timeToCharge -= Time.deltaTime;
        if(timeToCharge < 0){    
            state = State.Charge;
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
