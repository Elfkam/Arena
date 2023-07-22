using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string IS_ATTACKING = "IsAttacking";
    private const string IS_DYING = "IsDying";
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
            animator.SetBool(IS_ATTACKING, false);
            animator.SetBool(IS_WALKING, true);
        }
        if(enemy.GetState() == Enemy.State.Attack)
        {
            animator.SetBool(IS_ATTACKING, true);
            animator.SetBool(IS_WALKING, false);
        }
        if (enemy.GetState() == Enemy.State.Death)
        {
            animator.SetBool(IS_DYING, true);
            animator.SetBool(IS_ATTACKING, false);
            animator.SetBool(IS_WALKING, false);
        }
        if (enemy.GetState() == Enemy.State.Charge)
        {
            animator.SetBool(IS_WALKING, true);
            animator.SetBool(IS_PREPARING_TO_CHARGE, false);
        }
        if (enemy.GetState() == Enemy.State.PrepareToCharge)
        {
            animator.SetBool(IS_PREPARING_TO_CHARGE, true);
            animator.SetBool(IS_WALKING, false);
        }          
    }
}
