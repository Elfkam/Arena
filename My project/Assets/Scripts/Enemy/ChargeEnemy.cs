using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : Enemy
{
    private float chargeRange;
    private float timeToAttack = 0;
    private float prepareToCharge = 2f;
    private float timeToCharge = 0;
    private bool alreadyCharged = false;
    private Vector3 directionToPlayer = Vector3.zero;
    private Vector3 chargeStartPos = Vector3.zero;
    private float chargeSpeed = 5f;
    private float normalSpeed;
    protected override void Start()
    {
        base.Start();
        state = State.ChasePlayer;
    }  

    private void Update()
    {
        Act();
    }

    public static ChargeEnemy Create(Vector3 position, GameObject gm, int hp, float attackSpeed, float speed, int dmg, float chargeRange, int xp){
        Transform enemyTransform = Instantiate(gm, position, Quaternion.identity).transform;
        ChargeEnemy enemy = enemyTransform.GetComponent<ChargeEnemy>();
        enemy.Setup(hp, attackSpeed, speed, dmg, chargeRange, xp);
        return enemy;
    }

    private void Setup(int hp, float attackSpeed, float speed, int dmg, float chargeRangeInput, int xp){
        base.Health = hp;
        base.attackSpeed = attackSpeed;
        base.moveSpeed = speed;
        base.dmg = dmg;
        base.xp = xp;
        timeToAttack = attackSpeed;
        chargeRange = chargeRangeInput;
        timeToCharge = prepareToCharge;
        normalSpeed = speed;
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
                HandleChargeMovement();
                break;
        }
    }

    private bool InChargeRange(){
        if(alreadyCharged) return false;
        if(Vector3.Distance(transform.position, player.transform.position) > chargeRange) return false;
        return true;
    }

    private void HandleChargeMovement(){        
        Vector3 moveDir = new Vector3(directionToPlayer.x, directionToPlayer.y, 0f);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        if(Vector3.Distance(transform.position, chargeStartPos) > chargeRange + chargeRange / 2){
            state = State.ChasePlayer;
            moveSpeed = normalSpeed;
        }
    }

    private void PrepareToCharge() {
        if(chargeStartPos == Vector3.zero){
            directionToPlayer = (player.transform.position - transform.position).normalized;
            chargeStartPos = transform.position;
        }
		/* foreach(SpriteRenderer c in gameObject.GetComponentsInChildren<SpriteRenderer>()) {
			c.color = new Color(122, 95, 48);
        } */
		
        timeToCharge -= Time.deltaTime;
        if(timeToCharge < 0){
            moveSpeed = chargeSpeed;
            alreadyCharged = true;    
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
            if(state != State.Charge) state = State.Attack;
            else player.TakeDamage(dmg); // deal dmg to player during charge
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
