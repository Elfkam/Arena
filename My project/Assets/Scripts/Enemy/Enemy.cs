using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float moveSpeed;
    protected Player player;
    protected int Health;
    protected State state;
    protected float attackSpeed;
    protected int dmg;
    protected int xp;
    protected abstract void Act();
    private Animator animator;
    protected float speedReduction;
    protected float debuffDuration;
    protected float currDebuffDuration;
    protected bool hasDebuff;

    public enum State{
        ChasePlayer,
        Attack,
        Charge,
        Death,
        PrepareToCharge,
    }

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = transform.GetComponent<Animator>();
        speedReduction = 0;
    }  

    protected virtual void Update()
    {
        if(hasDebuff) HandleDebuff();
    }

    protected void MoveToPlayer(){
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        Vector3 moveDir = new Vector3(directionToPlayer.x, directionToPlayer.y, 0f);

        // turn player acording to witch side he is going
        if(directionToPlayer != Vector2.zero){    
            if(directionToPlayer.x > 0){
                transform.eulerAngles = new Vector2(0, 0);
            }else{
                transform.eulerAngles = new Vector2(0, 180);                
            }
        }
        transform.position += moveDir * getMoveSpeed() * Time.deltaTime;
    }

    public void TakeDamage(int damage, PlayerAttacks.TypeSpellElement typeSpellElement){
        Health -= damage;
        DamagePopup.Create(transform.position, damage, false, typeSpellElement);
        if(Health <= 0){
            Destroy(gameObject);
            player.GetComponent<PlayerXP>().setPlayerXP(xp);
            // state = State.Death;
            // StartCoroutine(Die());
        }
    }

    public void TakeFrostDamage(int initialDamage){
        TakeDamage(initialDamage, PlayerAttacks.TypeSpellElement.Frost);        
        debuffDuration = 5f;
        // debuff is at max stacks
        if(speedReduction == 1f) return;
        speedReduction += 0.25f;
        Color color = new Color(1, 1, 1);;
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
        hasDebuff = true;
    }

    public void TakeWindDamage(int initialDamage, float duration, float speedReduction, float distance){
        TakeDamage(initialDamage, PlayerAttacks.TypeSpellElement.Wind);
        debuffDuration = duration;
        this.speedReduction = speedReduction;

        //Knockback 
        moveSpeed *= -1;
    }

    private void HandleDebuff(){
        currDebuffDuration += Time.deltaTime;

        if(currDebuffDuration > debuffDuration){
            hasDebuff = false;
            currDebuffDuration = 0;
            speedReduction = 0;
            SpriteRenderer [] arr = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer spriteRenderer in arr)
            {
                spriteRenderer.material.color = new Color(1, 1, 1);
            }
        }
    }

    protected float getMoveSpeed(){
        return moveSpeed * (1 - speedReduction);
    }

    private IEnumerator Die()
    {
        float time = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);       
    }

    public State GetState(){
        return state;
    }
    
}
