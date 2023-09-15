using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PlayerAttacks
{
    private Animation anim;
    protected override void Start()
    {
        base.Start();
    }

    public static Explosion Create(Vector3 position, GameObject gm, int dmg, TypeSpellElement typeSpellElement){
        Transform spellTransform = Instantiate(gm, position, Quaternion.identity).transform;
        Explosion spell = spellTransform.GetComponent<Explosion>();
        spell.Setup(typeSpellElement,  dmg);
        return spell;
    }

    protected void Setup(TypeSpellElement typeSpellElement, int dmg){        
        damage = dmg;        
        this.typeSpellElement = typeSpellElement;
    }


    protected override void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){            
            DmgBasedOnType(gm, typeSpellElement);
            Die();
            Destroy(this);          
        }        
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);        
    }
}
