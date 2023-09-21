using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDebuffs : MonoBehaviour
{
    private float DEBUFF_DURATION = 5f;
    private float speedReduction;
    private int fireDmgDot;
    private Enemy enemy;
    private Dictionary<PlayerAttacks.TypeSpellElement, float> debuffs;
    private Coroutine fireDot;
    private Vector3 moveDirection;
    private float windDuration;
    private void Start()
    {
        speedReduction = 0;
        fireDmgDot = 0;
        windDuration = 0;
        moveDirection = Vector3.zero;
        enemy = transform.GetComponent<Enemy>();
        debuffs = new Dictionary<PlayerAttacks.TypeSpellElement, float>{
            {PlayerAttacks.TypeSpellElement.Frost, 0f},
            {PlayerAttacks.TypeSpellElement.Fire, 0f},
            {PlayerAttacks.TypeSpellElement.Wind, 0f},
            {PlayerAttacks.TypeSpellElement.Lightning, 0f},
        };
    }

    private void Update()
    {
        HandleDebuff();        
    }

    public void TakeFrostDamage(int initialDamage, string spell){
        enemy.TakeDamage(initialDamage, PlayerAttacks.TypeSpellElement.Frost, spell);
        debuffs[PlayerAttacks.TypeSpellElement.Frost] = 0;

        // debuff is at max stacks
        if(speedReduction == 1f) return;
        speedReduction += 0.25f;
        Color color = new Color(1, 1, 1);
        switch(speedReduction){
            case(0.25f):
                color = new Color(77f/255f, 241f/255f, 227f/231f);
                break;
            case(0.5f):
                color = new Color(37f/255f, 108f/255f, 147f/231f);
                break;
            case(0.75f):
                color = new Color(35f/255f, 35f/255f, 231f/231f);
                break;
            case(1f):
                color = new Color(14f/255f, 14f/255f, 68f/231f);
                break;
            default:
                break;
        }
        SpriteRenderer [] arr = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in arr)
        {
            spriteRenderer.material.color = color;
        }
    }

    public void TakeFireDamage(int initialDamage, string spell){
        enemy.TakeDamage(initialDamage, PlayerAttacks.TypeSpellElement.Fire, spell);
        // check if enemy has already fire debuff
        if(gameObject.transform.childCount != 3){
            debuffs[PlayerAttacks.TypeSpellElement.Fire] = 0;
            fireDmgDot = initialDamage / 4;
            GameObject fire = Instantiate(GameAssets.i.FireDebuff, transform.position, Quaternion.identity);
            fire.transform.parent = gameObject.transform;
            fireDot = StartCoroutine(FireDmgTick(spell));       
        }else{
            debuffs[PlayerAttacks.TypeSpellElement.Fire] = 0;
            fireDmgDot = initialDamage / 4;
        }      
    }

    public void TakeWindDamage(int initialDamage, Vector3 moveDirection, float duration, string spell){
        enemy.TakeDamage(initialDamage, PlayerAttacks.TypeSpellElement.Wind, spell);
        debuffs[PlayerAttacks.TypeSpellElement.Wind] = 0;
        this.moveDirection = moveDirection;  
        windDuration = duration;
    }



    private void HandleDebuff(){
        if(fireDmgDot != 0) debuffs[PlayerAttacks.TypeSpellElement.Fire] += Time.deltaTime;        
        if(debuffs[PlayerAttacks.TypeSpellElement.Fire] > DEBUFF_DURATION){
            fireDmgDot = 0;
            if(gameObject.transform.childCount == 3){
                Destroy(gameObject.transform.GetChild(2).gameObject); 
            }                       
            debuffs[PlayerAttacks.TypeSpellElement.Fire] = 0;
            StopCoroutine(fireDot);
        }

        if(speedReduction != 0) debuffs[PlayerAttacks.TypeSpellElement.Frost] += Time.deltaTime;        
        if(debuffs[PlayerAttacks.TypeSpellElement.Frost] > DEBUFF_DURATION){
            speedReduction = 0;
            SpriteRenderer [] arr = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer spriteRenderer in arr)
            {
                spriteRenderer.material.color = new Color(1, 1, 1);
            }
            debuffs[PlayerAttacks.TypeSpellElement.Frost] = 0;
        }

        if(moveDirection != Vector3.zero) debuffs[PlayerAttacks.TypeSpellElement.Wind] += Time.deltaTime;        
        if(debuffs[PlayerAttacks.TypeSpellElement.Wind] > windDuration){
            moveDirection = Vector3.zero;
            debuffs[PlayerAttacks.TypeSpellElement.Wind] = 0;
        }
    }

    public float GetSpeedReduction(){
        return speedReduction;
    }
    public Vector3 GetMoveDirection(){
        return moveDirection;
    }
    IEnumerator FireDmgTick(string spell) {        
        while(true) {
            yield return new WaitForSeconds(1);
            enemy.TakeDamage(fireDmgDot, PlayerAttacks.TypeSpellElement.Fire, spell);
        }         
    }
}
