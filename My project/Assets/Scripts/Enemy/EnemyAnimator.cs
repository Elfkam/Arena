using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string IS_ATTACKING = "IsAttacking";
    private const string IS_DYING = "IsDying";
    private const string IS_CHARGING = "IsCharging";
    private const string IS_PREPARING_TO_CHARGE = "IsPreparingToCharge";

    [SerializeField] private Enemy enemy;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Update(){
        HandleAnimation();
    }

    private void HandleAnimation(){
        if (enemy.GetState() == Enemy.State.ChasePlayer)
        {
            animator.SetBool(IS_WALKING, true);
        }
        if(state == Enemy.State.Attack)
        {
            animator.SetBool(IS_ATTACKING, true);
        }
        if (state == Enemy.State.Death)
        {
            animator.SetBool(IS_DYING, true);
        }
        if (state == Enemy.State.Charge)
        {
            animator.SetBool(IS_CHARGING, true);
        }
        if (state == Enemy.State.PrepareToCharge)
        {
            animator.SetBool(IS_PREPARING_TO_CHARGE, true);
        }          
    }
}
