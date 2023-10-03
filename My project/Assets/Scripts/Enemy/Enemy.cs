using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float moveSpeed;
    protected Player player;
    protected int health;
    protected State state;
    protected float attackSpeed;
    protected int dmg;
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

    public void TakeDamage(int damage, PlayerAttacks.TypeSpellElement typeSpellElement, string spell){
        health -= damage;
        DamagePopup.Create(transform.position, damage, false, typeSpellElement);
        player.GetComponent<DamageDone>().AddDamage(spell.Replace("(Clone)", ""), damage);
        if(health <= 0){
            Die();
        }
    }

    private void Die(){
        Destroy(gameObject);
        GameObject [] hearts = GameObject.FindGameObjectsWithTag("HPHeart");
        // only 2 hphearts can be at the same time
        if(hearts.Length < 2 ){
            int randomNum = Random.Range(0, 10);
            if(randomNum == 9) Instantiate(GameAssets.i.Heart, transform.position, Quaternion.identity);
            else Instantiate(GameAssets.i.XP, transform.position, Quaternion.identity);
        }
        else Instantiate(GameAssets.i.XP, transform.position, Quaternion.identity);
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
    public State GetState(){
        return state;
    }
}
