using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PlayerAttacks
{
    private Animation anim;
    private float timeUntilDestroy;
    protected override void Start()
    {
        base.Start();
        timeUntilDestroy = 1f; 
    }

    protected override void Update()
    {
        base.Update();
        CheckDuration();
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

    private void CheckDuration(){
        timeUntilDestroy -= Time.deltaTime;
        if(timeUntilDestroy < 0) Destroy(gameObject);
    }


    protected override void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){            
            DmgBasedOnType(gm, typeSpellElement, Vector3.zero, 0f, transform.gameObject);
        }        
    }
}
