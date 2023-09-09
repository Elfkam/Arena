using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerExplosionAttack : PlayerBasicAttack
{
    private GameObject explosionGm;
    private int dmgExplosion;
    private TypeSpellElement typeSpellElementExpolison;
    public static PlayerExplosionAttack Create(Vector3 position, GameObject gm, TypeSpellElement typeSpellElement, float speed, GameObject explosionGm, int dmgExplosion, TypeSpellElement typeSpellElementExpolison){
        Transform spellTransform = Instantiate(gm, position, Quaternion.identity).transform;
        PlayerExplosionAttack spell = spellTransform.GetComponent<PlayerExplosionAttack>();
        spell.Setup(typeSpellElement, 0, speed);
        spell.SetupExplosion(explosionGm, dmgExplosion, typeSpellElementExpolison);
        return spell;
    }
    private void SetupExplosion(GameObject explosionGm, int dmgExplosion, TypeSpellElement typeSpellElementExpolison){
        this.explosionGm = explosionGm;
        this.dmgExplosion = dmgExplosion;
        this.typeSpellElementExpolison = typeSpellElementExpolison;
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){            
            SpawnExplosion();
            Destroy(gameObject);
        }        
    }

    private void SpawnExplosion(){
        Explosion.Create(transform.position, explosionGm, dmgExplosion, typeSpellElementExpolison);
    }
}
