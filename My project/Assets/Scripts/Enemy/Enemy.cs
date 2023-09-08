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
        speedReduction = 1;
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

    public void TakeDamage(int damage){
        Health -= damage;
        DamagePopup.Create(transform.position, damage, false);
        if(Health <= 0){
            Destroy(gameObject);
            player.GetComponent<PlayerXP>().setPlayerXP(xp);
            // state = State.Death;
            // StartCoroutine(Die());
        }
    }

    public void TakeFrostDamage(int initialDamage, float duration, float speedReduction){
        TakeDamage(initialDamage);      
        debuffDuration = duration;
        this.speedReduction = speedReduction;

        SpriteRenderer [] arr = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in arr)
        {
            spriteRenderer.color = new Color(36, 52, 231);
        }
        hasDebuff = true;
    }

    private void HandleDebuff(){
        currDebuffDuration += Time.deltaTime;

        if(currDebuffDuration > debuffDuration){
            hasDebuff = false;
            currDebuffDuration = 0;
            speedReduction = 1;
            SpriteRenderer [] arr = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer spriteRenderer in arr)
            {
                spriteRenderer.color = new Color(255, 255, 255);
            }
        }
    }

    protected float getMoveSpeed(){
        return moveSpeed * speedReduction;
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
