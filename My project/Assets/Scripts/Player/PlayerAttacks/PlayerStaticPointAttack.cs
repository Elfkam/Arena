using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStaticPointAttack : PlayerAttacks
{
    private float timeUntilDestroy;

    private Dictionary<GameObject, float> enemiesInCollision;
    protected override void Start()
    {
        base.Start();
        enemiesInCollision = new Dictionary<GameObject, float>();
    }

    protected override void Update()
    {
        base.Update();
        CheckDuration();
    }

    public static PlayerStaticPointAttack Create(Vector3 playerPosition, GameObject gm, int dmg, TypeSpellElement typeSpellElement, float duration, float distanceFromPlayer){
        Vector3 spawnPoint = playerPosition + (Vector3)(distanceFromPlayer * UnityEngine.Random.insideUnitCircle);
        Transform spellTransform = Instantiate(gm, spawnPoint, Quaternion.identity).transform;
        PlayerStaticPointAttack spell = spellTransform.GetComponent<PlayerStaticPointAttack>();
        spell.Setup(typeSpellElement, dmg, duration);
        return spell;
    }
    protected void Setup(TypeSpellElement typeSpellElement, int dmg, float duration){        
        damage = dmg;        
        this.typeSpellElement = typeSpellElement;
        timeUntilDestroy = duration;
    }
    private void CheckDuration(){
        timeUntilDestroy -= Time.deltaTime;
        if(timeUntilDestroy < 0) Destroy(gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){            
            DmgBasedOnType(gm, typeSpellElement, new Vector3((transform.position - gm.transform.position).normalized.x, (transform.position - gm.transform.position).normalized.y, 0), timeUntilDestroy, transform.gameObject);
            enemiesInCollision.Add(gm, 1f);
        }        
    }
    protected void OnTriggerStay2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){        
            enemiesInCollision[gm] -= Time.deltaTime;    
            if(enemiesInCollision[gm] < 0){
                DmgBasedOnType(gm, typeSpellElement, new Vector3((transform.position - gm.transform.position).normalized.x, (transform.position - gm.transform.position).normalized.y, 0), timeUntilDestroy, transform.gameObject);
                enemiesInCollision[gm] = 1f;
            }
        }
    }
    protected void OnTriggerExit2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("Enemy")){        
            enemiesInCollision.Remove(gm);
        }
    }
}
