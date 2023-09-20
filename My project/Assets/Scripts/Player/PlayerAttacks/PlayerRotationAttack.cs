using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationAttack : PlayerAttacks
{
    private float radius;
    private float angle;
    protected override void Start()
    {
        base.Start();       
    }

    protected override void Update()
    {
        base.Update();
        HandleMovement();

    }

    public static PlayerRotationAttack Create(Vector3 playerPosition, GameObject gm, int dmg, TypeSpellElement typeSpellElement, float distanceFromPlayer, float speed){
        Vector3 spawnPoint = new Vector3(playerPosition.x, playerPosition.y + distanceFromPlayer, 0);
        Transform spellTransform = Instantiate(gm, spawnPoint, Quaternion.identity).transform;
        PlayerRotationAttack spell = spellTransform.GetComponent<PlayerRotationAttack>();
        spell.Setup(typeSpellElement, dmg, speed, distanceFromPlayer);
        return spell;
    }
    protected void Setup(TypeSpellElement typeSpellElement, int dmg, float speed, float radius){        
        damage = dmg;        
        this.typeSpellElement = typeSpellElement;
        this.speed = speed;
        this.radius = radius;
    }

    private void HandleMovement(){
        angle += speed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = player.transform.position + (Vector3)offset;
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){            
            DmgBasedOnType(gm, typeSpellElement, Vector3.zero, 0f, transform.gameObject);
        }        
    }
}
