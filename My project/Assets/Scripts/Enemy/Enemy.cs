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
    private EnemyDebuffs debuffs;


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
        debuffs = transform.GetComponent<EnemyDebuffs>();
    }  

    protected virtual void Update()
    {
        
    }

    protected void MoveToPlayer(){
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        Vector3 moveDir = getMoveDirection();

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

    protected float getMoveSpeed(){
        return moveSpeed * (1 - debuffs.GetSpeedReduction());
    }
    protected Vector3 getMoveDirection(){
        if(debuffs.GetMoveDirection() != Vector3.zero){
            return debuffs.GetMoveDirection();
        }else{
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 moveDir = new Vector3(directionToPlayer.x, directionToPlayer.y, 0f);
            return moveDir;
        }       
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
