using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 0.4f;
    private bool isWalking;
    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement(){
        Vector2 inputVector = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
        transform.position +=  moveDir * moveSpeed * Time.deltaTime;

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
    }

    public bool IsWalking(){
        return isWalking;
    }
}
