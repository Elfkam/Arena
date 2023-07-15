using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 0.4f;
    private Rigidbody2D playerRigidBody2d;
    private bool isWalking;

    private void Awake() {
        playerRigidBody2d = GetComponent<Rigidbody2D>();
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
}
