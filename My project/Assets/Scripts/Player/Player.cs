using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private EndMenu endMenu;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private HealthBar healthBar;
    private Rigidbody2D playerRigidBody2d;
    private bool isWalking;
    private int MAX_HEALTH = 100;

    private int Health;
    private int Coins;

    private void Awake() {
        playerRigidBody2d = GetComponent<Rigidbody2D>();
        MAX_HEALTH += GameData.GetPlayerBonusHp();
        Health = MAX_HEALTH;
        healthBar.SetMaxHealth(Health);
        moveSpeed += GameData.GetPlayerBonusSpeed() / 100f;
    }
    private void Update()
    {

    }

    private void FixedUpdate() {
        playerRigidBody2d.MovePosition(transform.position + HandleMovement());
    }

    private Vector3 HandleMovement(){
        Vector2 inputVector = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
        //transform.position +=  moveDir * moveSpeed * Time.deltaTime;

        // turn player acording to witch side he is going
        if(inputVector != Vector2.zero){    
            isWalking = true;        
            if(inputVector.x > 0){
                transform.eulerAngles = new Vector2(0, 0);
            }else{
                transform.eulerAngles = new Vector2(0, 180);                
            }
        }else{
            isWalking = false;
        }
        return moveDir * moveSpeed * Time.deltaTime;
    }    
    
    public bool IsWalking(){
        return isWalking;
    }

    public void TakeDamage(int damage){
        Health -= damage;
        healthBar.SetHealth(Health);
        gameObject.GetComponent<DamageEffect>().ShowDamageEffect();
        if(Health <= 0){
            endMenu.SetActiveEndMenu(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        GameObject gm = collider2D.gameObject;
        if(gm.CompareTag("XP")){            
            gameObject.GetComponent<PlayerXP>().setPlayerXP(1);
            Destroy(gm);
        }
        if(gm.CompareTag("HPHeart")){        
            Health += 50;
            if(Health > MAX_HEALTH) Health = MAX_HEALTH;
            healthBar.SetHealth(Health);
            Destroy(gm);
        }
        if(gm.CompareTag("Coin")){
            Coins ++;
            GameObject.Find("GameHandler/UI/Coins/CoinsCount").GetComponent<CoinCount>().SetCoinText(Coins.ToString());                  
            Destroy(gm);
        }      
    }

    public int GetCoins(){
        return Coins;
    }
}
