using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.4f;
    private GameObject player;
    private bool isWalking;  

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }  

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement(){
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        Vector3 moveDir = new Vector3(directionToPlayer.x, directionToPlayer.y, 0f);

        //transform.position +=  moveDir * moveSpeed * Time.deltaTime;

        // turn player acording to witch side he is going
        if(directionToPlayer != Vector2.zero){    
            isWalking = true;        
            if(directionToPlayer.x > 0){
                transform.eulerAngles = new Vector2(0, 0);
            }else{
                transform.eulerAngles = new Vector2(0, 180);                
            }
        }else{
            isWalking = false;
        }
        transform.position += moveDir * moveSpeed * Time.deltaTime;

    }

    public bool IsWalking(){
        return isWalking;
    }
    
}
