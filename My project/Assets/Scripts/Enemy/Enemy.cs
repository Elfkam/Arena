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
        int critChange = GameData.GetPlayerCritChange();
        int random = Random.Range(0, 100);
        bool critHit = random < critChange ? true : false;
        int finalDamage = (int) (damage * (1f + GameData.GetPlayerBonusDmg()/100f));
        finalDamage = critHit ? finalDamage * 2 : finalDamage;
        health -= finalDamage;
        DamagePopup.Create(transform.position, finalDamage, critHit, typeSpellElement);
        player.GetComponent<DamageDone>().AddDamage(spell.Replace("(Clone)", ""), finalDamage);
        if(health <= 0){
            Die();
        }
    }

    private void Die(){
        Destroy(gameObject);
        GameObject [] hearts = GameObject.FindGameObjectsWithTag("HPHeart");
        // only 2 hphearts can be at the same time
        switch(Random.Range(0, 50)){
            case < 47:
                Instantiate(GameAssets.i.XP, transform.position, Quaternion.identity);
                return;
            case < 50:
                if(hearts.Length < 2 ){
                    Instantiate(GameAssets.i.Heart, transform.position, Quaternion.identity);
                }else{
                    Instantiate(GameAssets.i.XP, transform.position, Quaternion.identity);
                }
                return;
            default:
                return;
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
    public State GetState(){
        return state;
    }
}
