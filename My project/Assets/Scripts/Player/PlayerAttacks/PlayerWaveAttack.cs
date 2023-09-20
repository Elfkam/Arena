using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
    Basic attack which is not destroyed on collision. (only distance check)
*/
public class PlayerWaveAttack : PlayerBasicAttack
{
    public static PlayerWaveAttack Create(Vector3 position, GameObject gm, int damage, TypeSpellElement typeSpellElement, float speed, float distance){
        Transform spellTransform = Instantiate(gm, position, Quaternion.identity).transform;
        PlayerWaveAttack spell = spellTransform.GetComponent<PlayerWaveAttack>();
        spell.Setup(typeSpellElement, damage, speed);
        spell.SetupDistance(distance);
        return spell;
    }

    private void SetupDistance(float distance){
        this.distance = distance;
    }
    protected override void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){  
            DmgBasedOnType(gm, typeSpellElement, new Vector3((gm.transform.position - transform.position).normalized.x, (gm.transform.position - transform.position).normalized.y, 0), 2f, transform.gameObject);
        }   
    }
}

