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

    protected abstract void Act();

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
    }  

    private void Update()
    {
       Act();
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
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    public void TakeDamage(int damage){
        Health -= damage;
        DamagePopup.Create(transform.position, damage, false);
        if(Health <= 0){
            Destroy(gameObject);
        }
    }

    public State GetState(){
        return state;
    }
    
}
