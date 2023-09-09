using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Goes to nearest enemy, and when it collides deals element dmg.
    Doesnt change direction. 
*/
public class PlayerBasicAttack : PlayerAttacks
{
    private float distance;
    protected Vector3 enemyPosition;
    protected Vector2 directionToEnemy;
    private Vector3 startPossition;
    protected override void Start()
    {
        base.Start();
        enemyPosition = GetNearestEnemyToPlayer().transform.position;
        distance = 10f;
        directionToEnemy = (enemyPosition - transform.position).normalized;
        startPossition = transform.position;
        setRotation(directionToEnemy);        
    }

    protected virtual void Update()
    {
        HandleMovement();
        CheckDistance();   
    }

    public static PlayerBasicAttack Create(Vector3 position, GameObject gm, int dmg, TypeSpellElement typeSpellElement, float speed){
        Transform spellTransform = Instantiate(gm, position, Quaternion.identity).transform;
        PlayerBasicAttack spell = spellTransform.GetComponent<PlayerBasicAttack>();
        spell.Setup(typeSpellElement, dmg, speed);
        return spell;
    }

    protected void Setup(TypeSpellElement typeSpellElement, int dmg, float speed){        
        damage = dmg;        
        this.typeSpellElement = typeSpellElement;
        this.speed = speed;
    }

    private void HandleMovement(){        
        Vector3 moveDir = new Vector3(directionToEnemy.x, directionToEnemy.y, 0f);      
        setRotation(directionToEnemy);
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void CheckDistance(){
        if(Vector3.Distance(transform.position, startPossition) >= distance){
            Destroy(gameObject);
        }
    }    
}
