using System;
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

    private TypeSpellElement typeSpellElement;
    protected override void Start()
    {
        base.Start();
        enemyPosition = GetPossNearestEnemyToPlayer();
        speed = 1f;
        distance = 10f;
        directionToEnemy = (enemyPosition - transform.position).normalized;
        startPossition = transform.position;
        setRotation(directionToEnemy);        
    }

    void Update()
    {
        HandleMovement();
        CheckDistance();   
    }

    public static PlayerBasicAttack Create(Vector3 position, GameObject gm, int dmg, TypeSpellElement typeSpellElement){
        Transform spellTransform = Instantiate(gm, position, Quaternion.identity).transform;
        PlayerBasicAttack spell = spellTransform.GetComponent<PlayerBasicAttack>();
        spell.Setup(typeSpellElement, dmg);
        return spell;
    }

    private void Setup(TypeSpellElement typeSpellElement, int dmg){        
        damage = dmg;        
        this.typeSpellElement = typeSpellElement;
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
    
    private void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){            
            DmgBasedOnType(gm);
            Destroy(gameObject);
        }        
    }

    private void DmgBasedOnType(GameObject enemy){
        if(TypeSpellElement.Fire == typeSpellElement){
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        } else if(TypeSpellElement.Frost == typeSpellElement){
            enemy.GetComponent<Enemy>().TakeFrostDamage(damage, 5f, 0.25f); // TODO: refactor
        }
    }
}
