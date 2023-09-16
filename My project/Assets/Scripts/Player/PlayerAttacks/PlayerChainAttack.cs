using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerChainAttack : PlayerSmartAttack
{
    private int numAdditionalCasts;
    public static PlayerChainAttack Create(Vector3 position, GameObject gm, TypeSpellElement typeSpellElement, int damage, int numAdditionalCasts, float speed){
        Transform spellTransform = Instantiate(gm, position, Quaternion.identity).transform;
        PlayerChainAttack spell = spellTransform.GetComponent<PlayerChainAttack>();
        spell.Setup(typeSpellElement, damage, speed);
        spell.SetupChain(numAdditionalCasts);
        return spell;
    }

    private void SetupChain(int numAdditionalCasts){
        this.numAdditionalCasts = numAdditionalCasts;
    }
    protected override void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){  
            DmgBasedOnType(gm, typeSpellElement);
            if(numAdditionalCasts == 0) {
                Destroy(gameObject);
            }else{
                ChooseNewTarget(gm);
            }
            numAdditionalCasts -= 1;   
        }   
    }

    private void ChooseNewTarget(GameObject gm){
        if(gm){
            enemy = GetNearestEnemyToCurrentLocation(gm);
        }else{
            enemy = GetNearestEnemyToCurrentLocation();
        }
        
    }
}
