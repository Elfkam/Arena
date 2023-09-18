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

    protected override void Update()
    {
        base.Update();
        Act();
        timeToAttack -= Time.deltaTime;
    }

    public static ChargeEnemy Create(Vector3 position, GameObject gm, int hp, float attackSpeed, float speed, int dmg, float chargeRange){
        Transform enemyTransform = Instantiate(gm, position, Quaternion.identity).transform;
        ChargeEnemy enemy = enemyTransform.GetComponent<ChargeEnemy>();
        enemy.Setup(hp, attackSpeed, speed, dmg, chargeRange);
        return enemy;
    }

    private void Setup(int hp, float attackSpeed, float speed, int dmg, float chargeRangeInput){
        base.Health = hp;
        base.attackSpeed = attackSpeed;
        base.moveSpeed = speed;
        base.dmg = dmg;
        timeToAttack = 0;
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
        transform.position += moveDir * getMoveSpeed() * Time.deltaTime;
        if(Vector3.Distance(transform.position, chargeStartPos) > chargeRange + chargeRange / 2){
            state = State.ChasePlayer;
            moveSpeed = normalSpeed;
            RemoveChargeColor();
        }
    }

    private void PrepareToCharge() {
        if(chargeStartPos == Vector3.zero){
            directionToPlayer = (player.transform.position - transform.position).normalized;
            chargeStartPos = transform.position;
        }
        SetChargeColor();		
        timeToCharge -= Time.deltaTime;
        if(timeToCharge < 0){
            moveSpeed = chargeSpeed;
            alreadyCharged = true;    
            state = State.Charge;
        }
    }
       
    private void Attack() {
        if(timeToAttack < 0){    
            timeToAttack = attackSpeed;
            player.TakeDamage(dmg);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Player")){
            state = State.Attack;
            moveSpeed = normalSpeed;
            RemoveChargeColor();
        }        
    }
    private void OnTriggerExit2D(Collider2D collider2D) {     
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Player")){            
            state = State.ChasePlayer;
        }        
    }

    private void SetChargeColor(){
        SpriteRenderer [] arr = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in arr)
        {
            spriteRenderer.material.color = new Color(174f/255f, 21f/255f, 21f/255f);
        }
    }

    private void RemoveChargeColor(){
        SpriteRenderer [] arr = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in arr)
        {
            spriteRenderer.material.color = new Color(1f, 1f, 1f);
        }
    }
}
