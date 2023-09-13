using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Goes to nearest enemy, and when it collides deals element dmg.
    Folow enemy until it hits him. 
*/
public class PlayerSmartAttack : PlayerAttacks
{
    protected GameObject enemy;

    protected override void Start()
    {
        base.Start();
        enemy = GetNearestEnemyToPlayer();
    }
    protected override void Update()
    {
        base.Update();
        HandleMovement();
    }

    public static PlayerSmartAttack Create(Vector3 position, GameObject gm, int dmg, TypeSpellElement typeSpellElement, float speed){
        Transform spellTransform = Instantiate(gm, position, Quaternion.identity).transform;
        PlayerSmartAttack spell = spellTransform.GetComponent<PlayerSmartAttack>();
        spell.Setup(typeSpellElement, dmg, speed);
        return spell;
    }

    protected void Setup(TypeSpellElement typeSpellElement, int dmg, float speed){        
        damage = dmg;        
        this.typeSpellElement = typeSpellElement;
        this.speed = speed;
    }

    private void HandleMovement(){
        try{  
            Vector3 directionToEnemy = (enemy.transform.position - transform.position).normalized;
            Vector3 moveDir = new Vector3(directionToEnemy.x, directionToEnemy.y, 0f);      
            setRotation(directionToEnemy);
            transform.position += moveDir * speed * Time.deltaTime;
        }catch{
            enemy = GetNearestEnemyToCurrentLocation();
            if(enemy == null) Destroy(gameObject);
        }        
    }
}
